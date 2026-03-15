variable "project_id" {
  description = "GCP project ID — must be supplied explicitly; no default to prevent accidental local applies against production"
  type        = string
}

variable "region" {
  description = "GCP region for Cloud Run — must be supplied explicitly; no default to prevent configuration drift"
  type        = string
}

variable "registry_region" {
  description = "Region of the Artifact Registry repository (used to build the image hostname). Defaults to var.region but can be set independently if the registry lives in a different region."
  type        = string
  default     = ""
}

variable "image_tag" {
  description = "Docker image tag to deploy (typically the git commit SHA)"
  type        = string
  default     = "latest"
}

variable "manage_apis" {
  description = <<-EOT
    When true, Tofu will enable the required GCP APIs via google_project_service.
    Requires the WIF service account to have roles/serviceusage.serviceUsageAdmin
    (or a custom role with serviceusage.services.enable + serviceusage.services.list).

    The canonical list of services is defined in local.required_apis in main.tf.

    Set to false if the APIs are already enabled or if you prefer to manage them
    out-of-band. To enable them manually, run:
      gcloud services enable $(tofu output -raw required_apis_csv) --project=<project_id>
    or inspect local.required_apis in main.tf and enable each service listed there.
  EOT
  type        = bool
  default     = true
}

variable "invoker_principals" {
  description = <<-EOT
    List of IAM member strings (e.g. "serviceAccount:foo@project.iam.gserviceaccount.com")
    that should be granted roles/run.invoker on this service.

    NOTE: the osrs-ui Cloud Run service account is granted invoker by the UI
    infra module (osrs-calc-ui/infra/main.tf) using a data source, so it does
    not need to be listed here. Use this variable for any additional principals
    (e.g. developers or other services) that need direct invoke access.
  EOT
  type        = list(string)
  default     = []
}
