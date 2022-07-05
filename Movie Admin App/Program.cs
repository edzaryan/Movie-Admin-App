using Movie_Admin_App.Data;
using Movie_Admin_App.IServices;
using Movie_Admin_App.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddTransient<FileOperations>();

builder.Services.AddTransient(typeof(IGenericPersonService<>), typeof(PersonService<>));

builder.Services.AddControllers().AddNewtonsoftJson();


var app = builder.Build();

app.MapControllers();

DbInitializer.Seed(app);

app.Run();
