locals {
  registry_region  = var.registry_region != "" ? var.registry_region : var.region
  repository_id    = "osrs-api"
  image            = "${local.registry_region}-docker.pkg.dev/${var.project_id}/${local.repository_id}/osrs-api:${var.image_tag}"

  required_apis = toset([
    "artifactregistry.googleapis.com",
    "iam.googleapis.com",
    "run.googleapis.com",
  ])
}

# Enable required GCP APIs — in a new project these are off by default and
# resources will fail to create without them.
# disable_on_destroy = false so that a `tofu destroy` doesn't break other
# workloads in the same project that depend on these APIs.
resource "google_project_service" "apis" {
  for_each = var.manage_apis ? local.required_apis : toset([])

  project                    = var.project_id
  service                    = each.value
  disable_on_destroy         = false
  disable_dependent_services = false
}

# Artifact Registry repository — must exist before the CI build/push job runs.
# Defined here so a fresh project is fully bootstrapped by a single `tofu apply`.
resource "google_artifact_registry_repository" "api" {
  project       = var.project_id
  location      = local.registry_region
  repository_id = local.repository_id
  format        = "DOCKER"
  description   = "Docker images for the OSRS API service"

  depends_on = [google_project_service.apis]
}

# Dedicated service account for the API container — principle of least privilege
resource "google_service_account" "api" {
  account_id   = "osrs-api-sa"
  display_name = "OSRS API Cloud Run Service Account"
  project      = var.project_id

  depends_on = [google_project_service.apis]
}

resource "google_cloud_run_v2_service" "api" {
  name     = "osrs-api"
  location = var.region

  # Restrict to internal traffic only — not reachable from the public internet.
  # Same-project Cloud Run services (UI) can still reach this URL when they
  # present a valid SA identity token (roles/run.invoker granted in the UI infra).
  ingress = "INGRESS_TRAFFIC_INTERNAL_ONLY"

  template {
    service_account = google_service_account.api.email

    scaling {
      # Scale down to zero when idle
      min_instance_count = 0
      max_instance_count = 10
    }

    containers {
      image = local.image

      ports {
        container_port = 8080
      }

      resources {
        limits = {
          cpu    = "1"
          memory = "512Mi"
        }
        # Release CPU when not processing a request (enables scale-to-zero billing)
        cpu_idle = true
        # Boost CPU during container startup to reduce cold-start latency
        startup_cpu_boost = true
      }
    }
  }

  depends_on = [google_artifact_registry_repository.api]
}

# ---------------------------------------------------------------------------
# Invoker IAM
# The primary caller (osrs-ui-sa) is bound by the UI infra module
# (osrs-calc-ui/infra/main.tf → google_cloud_run_v2_service_iam_member.ui_invokes_api)
# using a data source, keeping cross-repo SA email references out of this module.
# Additional principals (e.g. developers, test runners) can be passed via
# var.invoker_principals.
# ---------------------------------------------------------------------------
resource "google_cloud_run_v2_service_iam_member" "invokers" {
  for_each = toset(var.invoker_principals)

  project  = var.project_id
  location = var.region
  name     = google_cloud_run_v2_service.api.name
  role     = "roles/run.invoker"
  member   = each.value
}
