using Filmes.WebAPI.BdContectFilme;
using Filmes.WebAPI.Interface;
using Filmes.WebAPI.Repositores;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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

            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

            ClockSkew = TimeSpan.FromMinutes(5),
            ValidIssuer = "api_filmes",
            ValidAudience = "api_filmes",
        };
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Version = "v1",
        Title = "Filmes API",
        Description = "Uma API com um catalogos de filmes",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new Microsoft.OpenApi.OpenApiContact
        {
            Name = "marcaumdev",
            Url = new Uri("https://example.com/license")
        },
        License = new Microsoft.OpenApi.OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/License")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token Jwt:"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//Adiciona os controladores ao serviço
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => { });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors("CorsPolicy");

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
