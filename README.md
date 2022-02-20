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

## GitLab
  - **How to run GitLab CE + GitLab Runner**:
    - navigate to the project root where ... docker compose files are located and run the following command:
    ```
     docker-compose -f docker-compose.gitlab.yml up -d
    ```
    - Open GitLab via the browser : [Gitlab UI](http://localhost:9090)
    - Follow this suggested [solution](https://stackoverflow.com/a/55747403) to reset *Root*'s password.
    - After creating new repo, navigate to `http://localhost:9090/{username|root}/{projectname}/-/settings/ci_cd`, and expend runners.
    - Then, disable `Enable shared runners for this project`
    - Use your cmd to register GitLab Runner to GitLab, by executing the following script:
    ```
     docker-compose exec gitlab-runner \
    gitlab-runner register \
    --non-interactive \
    --url "http://gitlab-web:9090" \
    --registration-token "-DSusq3xsRtrGHGyqznc" \
    --executor docker \
    --description "Dotnet 6 Web.API Runner" \
    --docker-image "docker:stable" \
    --docker-volumes /var/run/docker.sock:/var/run/docker.sock
    ```


## Used Tech
- [dotnet 6](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6)
- [C# 10](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10)
- [Automapper](https://automapper.org/)
- [EF Core 6](https://docs.microsoft.com/en-us/ef/core/)
- [MSQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [GitLab Runner](https://docs.gitlab.com/runner/)
- [Docker](https://www.docker.com/)
- [Docker compose](https://docs.docker.com/compose/)
- [Portainer](https://www.portainer.io/)

## References
- [Self-Host GitLab and GitLab runner](https://medium.com/@rukeith/how-to-use-docker-to-build-a-self-host-gitlab-and-gitlab-runner-781981dc4d03)
- [How to install GitLab using Docker Compose?](https://www.czerniga.it/2021/11/14/how-to-install-gitlab-using-docker-compose/)
- [Reset GitLab Username and PWD](https://www.youtube.com/watch?v=NgNoTVL9PRw&ab_channel=LinuxHelp)
- [Reset GitLab Username and PWD](https://stackoverflow.com/a/55747403)
