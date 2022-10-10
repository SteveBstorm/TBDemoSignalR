using DemoSignalR.Hubs;
using DemoSignalR.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MessageManager>();

builder.Services.AddSignalR();

builder.Services.AddCors(o =>
{
    o.AddPolicy("SignalRCorsPolicy",
        o => o.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("SignalRCorsPolicy");
app.MapControllers();
app.MapHub<ChatHub>("chathub");

app.Run();
