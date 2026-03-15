variable "project_id" {
  description = "GCP project ID"
  type        = string
  default     = "oldschoolrunescapetool"
}

variable "region" {
  description = "GCP region for Cloud Run"
  type        = string
  default     = "us-central1"
}

variable "image_tag" {
  description = "Docker image tag to deploy (typically the git commit SHA)"
  type        = string
  default     = "latest"
}
