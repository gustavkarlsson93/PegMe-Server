using API.Helpers;
using Entity.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using API.Middleware;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<ClubDbContext>(
    o => o.UseSqlite(builder.Configuration.GetConnectionString("SqlServer"))
    );
    builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
        {
            policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
                .WithOrigins("https://192.168.1.28:7288");
        });
});


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//SeedData
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var logger = services.GetRequiredService<ILogger<Program>>();
try{
    var context = services.GetRequiredService<ClubDbContext>();
    await context.Database.MigrateAsync();
    await ClubContextSeed.SeedAsync(context, logger);
}catch (Exception ex)
{
    logger.LogError(ex, "Somthing wrong happend during migration");
}
app.Run();
