using BlogAppAPI.Models;
using BlogAppAPI.Repository.Auth;
using BlogAppAPI.Services.ControllerService;
using BlogAppAPI.Services.Sendmail;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOptions();

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.WriteIndented = true;
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//
//them dbcontext
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogAppAPI"));
});

//them service send mail
builder.Services.AddTransient<ISendMailService, SendMailService>();
//them config  vao
var mailConfig = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailConfig>(mailConfig);

//add identity
builder.Services.AddIdentity<CustomUser, IdentityRole>()
    .AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders();
//config identity
builder.Services.Configure<IdentityOptions>(options =>
{
    // Paswoord instellingen
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Gebruiker instellingen
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters =
      "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@1234567890@."; // here is the issue

    // Lockout instellingen
    options.Lockout = new LockoutOptions
    {
        AllowedForNewUsers = true,
        DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
        MaxFailedAccessAttempts = 5
    };
});
//add authenticate bang jwt
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwtOption => {
        jwtOption.SaveToken = true;
        jwtOption.RequireHttpsMetadata = false;
        jwtOption.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true, // cap phep
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:IssuerSigningKey"]))

        };
    });


//
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddCors(p => p.AddPolicy("CrossOrigin", build =>
{
    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    //build.WithOrigins("*");
})) ;


//--------------app
var app = builder.Build();

app.Use(async (context,next) =>
{
    if(context.Request.Method == "GET")
    {
        Console.WriteLine("This is a get method");
    }
    await next();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CrossOrigin");

app.MapControllers();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(enpoint => {
    enpoint.MapGet("/test-send-mail", async(context) => {
        //ylmqtnsyywyozctl
        string rel = await SendMailSMTP.SendMail("luffschloss@gmail.com","factyel.bttn@gmail.com","TEST","Xin chao day la Tanngoc","luffscholoss@gmail.com", "NgoccogN2103");
        await context.Response.WriteAsync(rel);
    });
    enpoint.MapGet("/send-mail-service", async(context) => {
        var sendMail = app.Services.GetService<ISendMailService>();
        var rel = await sendMail.SendMail(new MailContent() { To = "factyel.bttn@gmail.com", Subject="TEST", Body="<h1>Test email</h1>"});
        await context.Response.WriteAsync(rel);
    });
});

app.Run(async (HttpContext context) =>
{
    context.Response.StatusCode = StatusCodes.Status404NotFound;
    await context.Response.WriteAsync("Page not found");
});

app.Run();
