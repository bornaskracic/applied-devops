# CI/CD example with a simple Web API application 

## Overview

This solution contains two projects:
1. TicketApi
> Simple Web API application that exposes only one endpoint: `GET /api/tickets/health`.
2. TicketApp.Tests
> XUnit project that contains three unit tests for testing the behavior of the TicketApp functionality. 


They were created using the following `dotnet` commands:
```
dotnet new sln -n TicketApp

dotnet new webapi -n TicketApi
dotnet new xunit -n TicketApi.Tests

dotnet sln add TicketApi/TicketApi.csproj
dotnet sln add TicketApi.Tests/TicketApi.Tests.csproj

dotnet add TicketApi.Tests/TicketApi.Tests.csproj reference TicketApi/TicketApi.csproj
```

To run the tests:
```
dotnet restore
dotnet build
dotnet test
```

If you want to play around with this source code, do not forget to:

1. make sure to have `dotnet==8.0.0` and `docker` installed locally on your machine
2. provision available server instance (my recommendation is cheap Hetzner VPS instance)
3. setup required GitHub Action secret variables that will be used by the workflow
    + REGISTRY_USERNAME \
    Identification for registry instance, in this case GHCR.
    + REGISTRY_ACCESS_TOKEN \
    Access token for GHCR.
    + SSH_PRIVATE_KEY \
    Private SSH key for the `github` user that will access the target server instance.

## Github Actions Workflow

The workflow is divded into two jobs: 

1. build
2. deploy

### Build

This job builds the application's Docker image and then publishes it to `ghcr.io` (Github Container Registry).

### Deploy

This job connects to remote server instance and using remote Docker context (over SSH) pulls and runs the previously pushed Docker image.


## Things to improve

Fork this repository and see if you can set it up to work with your GitHub secrets and provisioned server (or a local instance if you are using self-hosted runners!). Then try to improve the following things in the CI/CD workflow:

1. programatically detect the current version of the application and automatically increment it when the application is built and deployed
2. test the code before building the Docker image
3. add one more service (e.g. Postgres database) that is the dependency for the main Web API application (define a `docker-compose` that needs to be copied into the server environment)

## Note
If you have a suggestion on how to improve this example, please open an issue and describe your idea!