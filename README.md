# About the Project
Using GitLab [runner](https://docs.gitlab.com/runner/) to setup [CI/CD Pipelines](https://www.redhat.com/en/topics/devops/what-cicd-pipeline) for a Containerized Dotnet 6 Web Application.

## Run the Project 
- **Debug mode**:
  - `appsetting.json`: Change MSQL Server for `TodoItemConnectionString` with a valid server name.   
    - visual studio: select `TodoItem.WebAPI` and run the project.    
    - using dotnet CLI : navigate to `TodoItem.WebAPI`, then `dotnet run` command.   
  
- **Docker**:
  - Navigate to root folder... where docker compose files are located, and : 
    - `docker-compose -f docker-compose.yml -f docker-compose.override.yml build`
      - `TodoItem.WebAPI` : [todoitemwebapi](localhost:8001/swagger)
      - `Portainer` : [Portainer](localhost:9000)
      - `TodoItem Sql Server Db` : [TodoItemDb](localhost:1433), **User: sa, Password: Bob12345678**
  
## Used Tech
- (dotnet 6)[https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6]
- (C# 10)[https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10]
- (Automapper)[https://automapper.org/]
- (EF Core 6)[https://docs.microsoft.com/en-us/ef/core/]
- (MSQL Server)[https://www.microsoft.com/en-us/sql-server/sql-server-downloads]
- (GitLab Runner)[https://docs.gitlab.com/runner/]
- (Docker)[https://www.docker.com/]
- (Docker compose)[https://docs.docker.com/compose/]
- (Portainer)[https://www.portainer.io/]