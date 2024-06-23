using Microsoft.EntityFrameworkCore;
using TodoList.Components;
using TodoList.Data;

var builder = WebApplication.CreateBuilder(args);


// Lấy chuỗi kết nối từ cấu hình
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Thêm ApplicationDbContext với PostgreSQL
builder.Services.AddDbContext<TodoDbContext >(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
