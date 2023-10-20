using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the SwaggerUI
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Configure .env
if(String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING"))) {
    DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] {"../.env"}));
}

Console.WriteLine("---> " + Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") == null);
Console.WriteLine(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
