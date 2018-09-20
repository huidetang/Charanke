#!/usr/bin/env bash

echo $GOOGLE_SERVICES_JSON | base64 --decode --ignore-garbage > ./google-services.json