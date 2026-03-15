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
