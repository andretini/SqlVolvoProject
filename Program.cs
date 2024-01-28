using Projeto_SQL.Model;

var optionsBuilder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

optionsBuilder.Services.AddControllers();
optionsBuilder.Services.AddDbContext<Hotel2Context>();
optionsBuilder.Services.AddEndpointsApiExplorer();
optionsBuilder.Services.AddSwaggerGen();

var app = optionsBuilder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


