#!/bin/bash

docker run --rm \
  -p 27017-27019:27017-27019 \
  -e MONGO_INITDB_ROOT_USERNAME=mongoadmin \
  -e MONGO_INITDB_ROOT_PASSWORD=secret \
  --name mongodb mongo
