var builder = WebApplication.CreateBuilder(args);

//added gateway proxy yarp.json file
builder.Configuration.AddJsonFile("yarp.json", optional: false, reloadOnChange: true);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
  

var app = builder.Build();

app.MapReverseProxy();

app.MapGet("/", () => "Hello World!");

app.Run();

