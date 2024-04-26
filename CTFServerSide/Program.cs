var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Configurar o CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin(); // Permitir requisi��es de qualquer origem
    options.AllowAnyMethod(); // Permitir requisi��es de qualquer m�todo (GET, POST, etc.)
    options.AllowAnyHeader(); // Permitir quaisquer cabe�alhos na requisi��o
});

app.MapControllers();

app.Run();
