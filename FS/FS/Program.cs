using FS.Hubs;
using tusdotnet;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins(new string[] { "http://localhost:3000", "http://localhost:3010" })
            .AllowCredentials();
    });
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.MapTus("/files", async httpContext => new()
{
    // This method is called on each request so different configurations can be returned per user, domain, path etc.
    // Return null to disable tusdotnet for the current request.

    // Where to store data?
    Store = new tusdotnet.Stores.TusDiskStore(@"D:\tusfiles\"),
    Events = new()
    {
        // What to do when file is completely uploaded?
        OnFileCompleteAsync = async eventContext =>
        {
            tusdotnet.Interfaces.ITusFile file = await eventContext.GetFileAsync();
            Dictionary<string, tusdotnet.Models.Metadata> metadata = await file.GetMetadataAsync(eventContext.CancellationToken);
            using Stream content = await file.GetContentAsync(eventContext.CancellationToken);

            //await DoSomeProcessing(content, metadata);
        }
    }
});
app.UseCors(options => options.AllowCredentials().AllowAnyHeader().AllowAnyMethod().WithOrigins(new string[] { "http://localhost:3000", "http://localhost:3010" }));
//app.MapControllers();
app.MapHub<MainHub>("/hubs/main");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.MapGet("/", () => "Hello World!");

app.Run();
