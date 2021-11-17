# txapi
Simple api in C# for the TX console app (https://github.com/doczi-dominik/tx)<br>
Note that the program was written in C# 10.0 and the .NET 6.0 framework!

<b>Endpoints:</b>
* POST /api/uploadfile
  - Upload a json string to the uploads folder, the api will send the filename (SyncId) as a response.
* GET/PUT /api/uploads/<filename>
  - A GET request will send the entire file back as a response. A PUT request appends to the file.
