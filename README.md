<!-- <div align="center">
  <a href="https://github.com/hoangkhang12789/NHK_MP3/blob/main/assets/image/avataSmall.jpg">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>
</div> -->

# Running ASP.NET Core with Docker for EClinic API
This guide will show you how to run an EClinic API built with ASP.NET Core using Docker.

## Prerequisites
* Docker installed on your local machine.
## Run on Windows
### 1. Generate Https Certificate
* cmd
```sh
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p Eclinic123
dotnet dev-certs https --trust
  ```
### 2. Run Docker Compose
* Run docker compose.
 ```sh
docker compose up
  ```
* Run docker compose in background.
 ```sh
docker compose up -d
  ```
### 3 Install dotnet ef tool
* cmd
```sh
dotnet tool install --global dotnet-ef --version 6.*
  ```
### 4 Instal sqlcmd command
* In windows when you install sql server you will have sqlcmd command
### 5 Run file bat
* In the `bash` folder double click on the file `EClinic.bat` or open a terminal there and run the command.
 ```sh
 .\EClinic.bat
  ```
* Running this bat file is to update the database and add data to the tables.

## Run on macOS or Linux
### 1. Generate Https Certificate
* shell
```sh
sudo dotnet dev-certs https -ep .aspnet/https/aspnetapp.pfx -p Eclinic123
dotnet dev-certs https --trust
  ```
### 2. Run Docker Compose
* Run docker compose.
 ```sh
docker compose up
  ```
* Run docker compose in background.
 ```sh
docker compose up -d
  ```
### 3 Install dotnet ef tool
* shell
```sh
dotnet tool install --global dotnet-ef
  ```
### 4 Instal sqlcmd command
 ```
 sudo apt-get install mssql-tools
  ```
  ```
 sudo ls /opt/mssql-tools/bin/sqlcmd*
  ```
  ```
 sudo ln -sfn /opt/mssql-tools/bin/sqlcmd /usr/bin/sqlcmd
  ```
### 5 Run file bat
* In `bash` folder open terminal and run command.
 ```sh
 sh EClinic.sh
  ```
* Running this bat file is to update the database and add data to the tables.
# Api Information
| Service | Url | Description |
| -------- | -------- | -------- |
| API gateway | https://localhost:8888 | This is the API gateway used to run all services in the system |
| Identity Service | https://localhost:1111/swagger/index.html | This is Swagger UI showing you all the Identity Service Api |
| Profile Service | https://localhost:2222/swagger/index.html | This is Swagger UI showing you all the Profile Service Api |
| Forum Service | https://localhost:3333/swagger/index.html | This is Swagger UI showing you all the Forum Service Api |
| Notification Service | https://localhost:4444/swagger/index.html | This is Swagger UI showing you all the Notification Service Api |