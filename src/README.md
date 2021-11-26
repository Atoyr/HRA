
# EF Migration
execute HRA\WEB Folder

```
dotnet ef migrations add init --project ..\HRA.EF
dotnet ef database update --project ..\HRA.EF
```

https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli