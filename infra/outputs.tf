output "registry_url" {
  description = "Artifact Registry repository URL (use as the Docker image prefix in CI)"
  value       = "${local.registry_region}-docker.pkg.dev/${var.project_id}/${local.repository_id}"
}

output "service_url" {
  description = "Internal URL of the Cloud Run service"
  value       = google_cloud_run_v2_service.api.uri
}

output "service_name" {
  description = "Cloud Run service name"
  value       = google_cloud_run_v2_service.api.name
}

output "service_account_email" {
  description = "Service account email running the API container"
  value       = google_service_account.api.email
}
