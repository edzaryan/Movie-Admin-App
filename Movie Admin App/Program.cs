using Movie_Admin_App.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

DbInitializer.Seed(app);

app.Run();
