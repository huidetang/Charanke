#!/usr/bin/env bash

echo $GOOGLE_SERVICES_JSON | base64 --decode > $APPCENTER_SOURCE_DIRECTORY/Charanke.Mobile/Charanke.Android/google-services.json