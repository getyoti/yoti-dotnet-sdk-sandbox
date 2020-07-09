#!/usr/bin/env bash
set -e

exec dotnet test Yoti.Auth.Sandbox.Tests/Yoti.Auth.Sandbox.Tests.csproj -c Release --verbosity minimal
