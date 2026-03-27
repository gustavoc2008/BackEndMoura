using ConnectPlus.WebAPI.Data;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

//1. Configurar o contexto do Banco de Dados
builder.Services.AddDbContext<ConnectPlusContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,

            ValidateAudience = true,

            ValidateLifetime = true,

            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventplus-chave-autenticacao-webapi-dev")),

            ClockSkew = TimeSpan.FromMinutes(5),
            ValidIssuer = "api-eventos",
            ValidAudience = "api-eventos",
        };
    });


//Adiciona Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api de contatos",
        Description = "Aplicação para gerenciamento de contatos",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Gustavo Costa",
            Url = new Uri("https://www.linkedin.com/in/marcaumdev")
        },
        License = new OpenApiLicense
        {
            Name = "Licensa de Exemplo",
            Url = new Uri("https://example.com/license")
        }
    });

    //Usando a autenticacao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "Jwt",
        In = ParameterLocation.Header,
        Description = "Insira o Token Jwt:"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger(options => { });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
