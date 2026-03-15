locals {
  image = "us-central1-docker.pkg.dev/${var.project_id}/osrs-api/osrs-api:${var.image_tag}"
}

# Dedicated service account for the API container — principle of least privilege
resource "google_service_account" "api" {
  account_id   = "osrs-api-sa"
  display_name = "OSRS API Cloud Run Service Account"
  project      = var.project_id
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
}
