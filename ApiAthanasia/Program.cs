var builder = WebApplication.CreateBuilder(args);

//MyCors declaration
var MyAllowSpecificOrigins = "MiCors";
    builder.Services.AddCors(options =>
    {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*");
                          builder.WithHeaders("*");
                      });
    });

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

//Use of MyCors
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
