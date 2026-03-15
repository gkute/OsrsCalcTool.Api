using OsrsCalcTool.Api.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:4200",
                "https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Register services — GE service is a singleton so the 5-minute price cache is shared across requests
builder.Services.AddSingleton<OsrsGrandExchangeService>();
builder.Services.AddHttpClient<OsrsGrandExchangeService>();
builder.Services.AddHttpClient<OsrsHiscoreService>();
builder.Services.AddHttpClient<ItemImageService>();
builder.Services.AddHttpClient<SkillIconService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseCors("Angular");
app.MapControllers();

app.Run();

