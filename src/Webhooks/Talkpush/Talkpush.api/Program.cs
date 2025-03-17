var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

// ----------------  Add services to the container ---------------------.
builder.Services.AddApplicationServices(assembly);
// ---------------- END ---------------------.


// ----------------  Build the app ---------------------.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter(); // Scan all the ICarterModule in the project and map the necessary route


// use exception handler after register
app.UseExceptionHandler(options => { });

app.Run();
