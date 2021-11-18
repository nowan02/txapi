# txapi
Simple api in C# for the TX console app (https://github.com/doczi-dominik/tx)<br>

# Endpoints
* **POST** /api/uploadfile
  - Upload a json string to the uploads folder, the api will send the filename (SyncId) as a response.
* **GET/PUT** /api/uploads/<filename>
  - A GET request will send the entire file back as a response. A PUT request appends to the file.

Right now, it is only recommended to use this through a local network,<br>
as no authentication or https is implemented. I plan to add it as an optional feature.

# SETUP
Note that the program was written in C# 10.0 and the .NET 6.0 framework.<br>
You'll need the correct packages to build the app.
  
* Create a new 'web' project using the following command:
  > dotnet new console -n project_name
  Run this in the desired folder to create the build files.
* Copy the files into **Program.cs**, then build and run the project:
  > dotnet run
* You can test the API by sending data to the **/api/uploadfile** endpoint.
  The default host adress is: localhost:5081.
  > curl http://localhost:5081/api/uploadfile -d "a json (or just a) string"
* The API should reply with a 32 number filename.
