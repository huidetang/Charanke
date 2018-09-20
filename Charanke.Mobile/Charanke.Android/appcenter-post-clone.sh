#!/usr/bin/env bash

echo $GOOGLE_SERVICES_JSON | base64 --decode --ignore-garbage > $APPCENTER_SOURCE_DIRECTORY/google-services.json