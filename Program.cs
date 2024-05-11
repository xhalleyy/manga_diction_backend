using manga_diction_backend.Services;
using manga_diction_backend.Services.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<ClubService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<MemberService>();
builder.Services.AddScoped<LikesService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<FriendService>();
builder.Services.AddScoped<NotificationService>();

var connectionString = builder.Configuration.GetConnectionString("MangaDiction");

builder.Services.AddDbContext<DataContext>(Options => Options.UseSqlServer(connectionString));

builder.Services.AddCors(options => options.AddPolicy("MangaPolicy",
    builder => {
        builder.WithOrigins("http://localhost:5037", "http://localhost:3000", "http://localhost:3001", "https://manga-diction.vercel.app")
        .AllowAnyHeader()
        .AllowAnyMethod();
    }
 ));

builder.Services.AddControllers();
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

// app.UseHttpsRedirection();
app.UseCors("MangaPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
