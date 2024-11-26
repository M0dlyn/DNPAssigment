using BlazorApp.Auth;
using BlazorApp.Components;
using BlazorApp.Services;
using EfcRepositories;
using Microsoft.AspNetCore.Components.Authorization;
using RepositoryContracts;
using AppContext = EfcRepositories.AppContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5250") });

builder.Services.AddScoped<IPostService, HttpPostService>();
builder.Services.AddScoped<IUserService, HttpUserService>();
builder.Services.AddScoped<ICommentService, HttpCommentService>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthProvider>();
builder.Services.AddScoped<IPostRepository, EfcPostRepository>();
builder.Services.AddScoped<IUserRepository, EfcUserRepository>();
builder.Services.AddScoped<ICommentRepository, EfcCommentRepository>();
builder.Services.AddDbContext<AppContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();