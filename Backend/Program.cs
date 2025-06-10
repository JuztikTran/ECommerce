using Backend.Data;
using Backend.IRepository;
using Backend.Repository;
using BusinessObjetcs.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options
    => options.UseNpgsql(builder.Configuration["ConnectionStrings:DB"]));
var odataBuilder = new ODataConventionModelBuilder();
odataBuilder.EntitySet<Account>("account");
odataBuilder.EntitySet<User>("user");
odataBuilder.EntitySet<Address>("address");
odataBuilder.EntitySet<Category>("category");
builder.Services.AddControllers()
    .AddOData(options => options
        .SetMaxTop(100)
        .Filter()
        .OrderBy()
        .Count()
        .Expand()
        .Select()
        .AddRouteComponents("odata", odataBuilder.GetEdmModel())
        );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseODataRouteDebug();

app.UseAuthorization();

app.MapControllers();

app.Run();
