CRUD with MySQL in .NET -
Step-by-Step Guide
1. Create a New .NET Project
dotnet new webapi -n CrudWithMySQL
cd CrudWithMySQL


2. Add Required NuGet Packages
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Relational
dotnet add package Pomelo.EntityFrameworkCore.MySql



3. Create the Database Context
Create a new folder Data and add a AppDbContext.cs file.
using Microsoft.EntityFrameworkCore;
namespace CrudWithMySQL.Data
{
public class AppDbContext : DbContext
{
public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
public DbSet<User> Users { get; set; }
}
}



4. Configure Database Connection in
appsettings.json
"ConnectionStrings": {
"DefaultConnection":
"server=localhost;database=crud_db;user=root;password=yourpassword"
}



5. Register the Database Context in Program.cs
using CrudWithMySQL.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
);
var app = builder.Build();
app.Run();



6. Create Model (e.g., User.cs)
Create a Models folder and add User.cs
namespace CrudWithMySQL.Models
{
public class User
{
public int Id { get; set; }
public string Name { get; set; }
public string Email { get; set; }
}
}



7. Create a Migration and Update Database
dotnet ef migrations add InitialCreate
dotnet ef database update



8. Create a Controller
Create a Controllers folder and add UsersController.cs
using CrudWithMySQL.Data;
using CrudWithMySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
private readonly AppDbContext _context;
public UsersController(AppDbContext context)
{
_context = context;
}
[HttpGet]
public async Task<ActionResult<IEnumerable<User>>> GetUsers()
{
return await _context.Users.ToListAsync();
}
[HttpPost]
public async Task<ActionResult<User>> CreateUser(User user)
{
_context.Users.Add(user);
await _context.SaveChangesAsync();
return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
}
}


9. Run the Project
dotnet run


10. Test the API
Use Postman or cURL:
curl -X GET http://localhost:5000/api/users
curl -X POST http://localhost:5000/api/users -H "Content-Type: application/json" -d
'{"name":"John Doe","email":"john@example.com"}'
Now, your CRUD API is working! 🚀
Step 1 - dotnet new webapi -n CrudWithMySQL
Step 2 - cd CrudWithMySQL
Step 3 - install database packages
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql
Step 4 - appsettings.json
"ConnectionStrings": {
"DefaultConnection":
"Server=localhost;Database=cscrud;User=magesh;Password=User@123;"
},