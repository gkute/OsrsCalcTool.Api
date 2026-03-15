terraform {
  required_version = ">= 1.8.0"

  required_providers {
    google = {
      source  = "hashicorp/google"
      version = "~> 6.0"
    }
  }

  backend "gcs" {
    # This bucket must exist before running `tofu init`.
    # Create it once with: gcloud storage buckets create gs://oldschoolrunescapetool-tofu-state --project=oldschoolrunescapetool --location=us-central1
    bucket = "oldschoolrunescapetool-tofu-state"
    prefix = "osrs-api/state"
  }
}
