using Movie_Admin_App.Custom;
using Movie_Admin_App.Custom_Functionalities;
using Movie_Admin_App.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddTransient<IFileOperations, FileOperations>();
builder.Services.AddControllers();


var app = builder.Build();

app.MapControllers();

DbInitializer.Seed(app);

app.Run();
