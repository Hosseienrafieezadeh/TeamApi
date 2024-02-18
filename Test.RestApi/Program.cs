using Tavv.Contract;
using Test.Persistence.EF;
using Test.Persistence.EF.EntitisMaps;
using Test.Persistence.EF.Play;
using Test.Persistence.EF.Teams;
using Test.Service.play;
using Test.Service.play.Contracts;
using Test.Service.Play.Contracts;
using Test.Service.Teams;
using Test.Service.Teams.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDataContext>();
builder.Services.AddScoped<TeamRepozitory, EfTeamRepozitory>();
builder.Services.AddScoped<TeamService, TeamAppService>();
builder.Services.AddScoped<playersRepozitory, EFPlayersRepozitory>();
builder.Services.AddScoped<playersService, PlyersAppService>();
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();

var app = builder.Build();

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
