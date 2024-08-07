using CTFServerSide.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar serviços da aplicação
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionar configuração do Startup
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Configurar o CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin(); // Permitir requisições de qualquer origem
    options.AllowAnyMethod(); // Permitir requisições de qualquer método (GET, POST, etc.)
    options.AllowAnyHeader(); // Permitir quaisquer cabeçalhos na requisição
});

app.MapControllers();

// Configurar a aplicação no Startup
startup.Configure(app, app.Environment);

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CTFContext>();
    try
    {
        context.Database.EnsureCreated();
        Console.WriteLine("Conexão com o banco de dados bem-sucedida.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
    }
}

app.Run();
