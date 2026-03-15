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
