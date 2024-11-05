using peliculas.Context;
using Microsoft.EntityFrameworkCore; // Agregar esta línea

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<PeliculasDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("PeliculasConnection")));

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Permite cualquier origen
                   .AllowAnyMethod() // Permite cualquier método HTTP
                   .AllowAnyHeader(); // Permite cualquier encabezado
        });
});

builder.Services.AddDbContext<PeliculasDbContext>(options =>
    options.UseSqlServer(
        "Server=DESKTOP-3BLNNFO;Database=PRUBAS222;User Id=tom;Password=Pescado12345*;TrustServerCertificate=True;",
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null // Puedes agregar códigos de error específicos aquí si es necesario
        )));

var app = builder.Build();

// Usar la política de CORS antes de usar otros middlewares
app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();