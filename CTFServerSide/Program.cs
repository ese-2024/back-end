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
    options.AllowAnyOrigin(); // Permitir requisições de qualquer origem
    options.AllowAnyMethod(); // Permitir requisições de qualquer método (GET, POST, etc.)
    options.AllowAnyHeader(); // Permitir quaisquer cabeçalhos na requisição
});

app.MapControllers();

app.Run();
