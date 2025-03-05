using Carter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();

ContactManager.Contracts.Dependencies.ConfigureServices(builder.Configuration, builder.Services);
ContactManager.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);
ContactManager.Application.Dependencies.ConfigureServices(builder.Configuration, builder.Services);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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

app.MapCarter();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();


