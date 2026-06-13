using CRM_Ticket_management_system.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Content root fix — Build() AGADI
builder.Environment.ContentRootPath = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
builder.Environment.WebRootPath = Path.Combine(
    builder.Environment.ContentRootPath, "wwwroot");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();