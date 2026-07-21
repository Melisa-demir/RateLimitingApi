using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.OnRejected = async (context, cancellationToken) =>
    {
        context.HttpContext.Response.ContentType = "application/json";

        await context.HttpContext.Response.WriteAsJsonAsync(
            new
            {
                StatusCode = 429,
                Message = "Çok fazla istek gönderdiniz. Lütfen daha sonra tekrar deneyin."
            },
            cancellationToken
        );
    };

    options.AddPolicy("products", httpContext =>
     RateLimitPartition.GetSlidingWindowLimiter(
         partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
         factory: _ => new SlidingWindowRateLimiterOptions
         {
             PermitLimit = 3,
             Window = TimeSpan.FromSeconds(10),
             SegmentsPerWindow = 5,
             QueueLimit = 0,
             QueueProcessingOrder = QueueProcessingOrder.OldestFirst
         }));

    options.AddPolicy("login", httpContext =>
    RateLimitPartition.GetFixedWindowLimiter(
        partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
        factory: _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 2,
            Window = TimeSpan.FromMinutes(1),
            QueueLimit = 0
        }));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers();

app.Run();