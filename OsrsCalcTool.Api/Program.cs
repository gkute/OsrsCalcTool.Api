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

// HTTPS redirection is intentionally omitted: the API runs on HTTP inside Cloud Run
// (port 8080) and TLS is terminated by Cloud Run's frontend before requests reach the
// container.  Adding UseHttpsRedirection() here would cause the container to issue 301
// redirects for every inbound request, breaking the nginx BFF proxy.
app.UseCors("Angular");
app.MapControllers();

app.Run();

