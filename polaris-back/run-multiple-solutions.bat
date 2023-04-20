@echo off

cd "C:\GIT\polaris\polaris\polaris-back\Polaris.Endereco"

start cmd /c "dotnet build & dotnet run"

cd "C:\GIT\polaris\polaris\polaris-back\Polaris.Servico"

start cmd /c "dotnet build & dotnet run"

cd "C:\GIT\polaris\polaris\polaris-back\Polaris.Conteiner"

start cmd /c "dotnet build & dotnet run" 