using Microsoft.AspNetCore.Identity;
using TodoIstProject.Business.Abstract;
using TodoIstProject.Business.Concrete;
using TodoIstProject.DataAccess.Abstract;
using TodoIstProject.DataAccess.Concrete;
using TodoIstProject.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddScoped<ITodoIstService, TodoIstManager>();
builder.Services.AddScoped<ITodoIstDal, EfTodoIstDal>();

builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();

builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddScoped<IRoleDal, EfRoleDal>();

builder.Services.AddScoped<ILoginService, LoginManager>();
builder.Services.AddScoped<ILoginDal, EfLoginDal>();

//builder.Services.AddScoped<SignInManager<T>>();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", z => z.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Json Serialize Kütüphane --> Microsoft.AspNetCore.Mvc.NewtonsoftJson
//builder.Services.AddControllersWithViews
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._+";
    options.User.RequireUniqueEmail = false;
});
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<AppUser, UserRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(z => z.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
