#!/usr/bin/env bash

ls $APPCENTER_SOURCE_DIRECTORY

ls $APPCENTER_SOURCE_DIRECTORY/Charanke.Mobile/Charanke.Android/

echo $GOOGLE_SERVICES_JSON | base64 --decode > $APPCENTER_SOURCE_DIRECTORY/google-services.json