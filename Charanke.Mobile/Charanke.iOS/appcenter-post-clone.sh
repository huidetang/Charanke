#!/usr/bin/env bash

echo $GOOGLESERVICEINFO_PLIST | base64 --decode > $APPCENTER_SOURCE_DIRECTORY/Charanke.Mobile/Charanke.iOS/GoogleService-Info.plist