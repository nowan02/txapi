WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

static string Randint(int Lenght)
{
    string _FileName = "";
    Random rnd = new Random();

    for (int i = 0; i < Lenght; i++)
    {
        _FileName += $"{rnd.Next(0, 10)}";
    }
    return _FileName;
}

static async void FileWriterAsync(string FileName, HttpContext ctx, FileMode f)
{
    FileStream fs = new FileStream($"uploads/{FileName}.json", f);
    using (StreamReader sr = new(ctx.Request.Body))
    {
        using (StreamWriter sw = new(fs))
        {
            _ = sw.WriteLineAsync(await sr.ReadLineAsync());
        }
    }
    fs.Close();
    _ = fs.DisposeAsync();
}

app.MapGet("/mindenfasza", async () => "Minden fasza!");

app.MapPost("/api/uploadfile/{syncid:required}", async ctx =>
{
    string _FileName = Randint(32);

    _ = ctx.Response.WriteAsync($"SyncId: {_FileName}\n");
    FileWriterAsync(_FileName, ctx, FileMode.Create);
});

app.MapGet("/api/uploads/{filename:required}", async ctx => 
{
    var _FileName = ctx.Request.RouteValues["filename"];
    try
    {
        _ = ctx.Response.SendFileAsync($"uploads/{_FileName}.json");
        Console.WriteLine($"File sent!\n");
    }
    catch
    {
        _ = ctx.Response.WriteAsync($"No file named {_FileName}\n");
    }
});

app.MapPut("/api/uploads/{filename:required}", async ctx => 
{
    var _FileName = ctx.Request.RouteValues["filename"];
    try
    {  
        FileWriterAsync($"uploads/{_FileName}.json", ctx, FileMode.Append);
    }
    catch
    {
        _ = ctx.Response.WriteAsync($"No file named {_FileName}\n");
    }
});

app.Run();