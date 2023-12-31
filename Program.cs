using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Set up the application to use views and controllers.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
});

var app = builder.Build();

// Middleware to handle HTTP to HTTPS redirection.
app.UseHttpsRedirection();

// Middleware to serve static files such as images, CSS, and JavaScript.
app.UseStaticFiles();

// Use the session middleware
app.UseSession();

// Middleware to set up endpoint routing.
app.UseRouting();

// Middleware for authorization.
app.UseAuthorization();

// Route requests to the appropriate controller.
app.MapControllers();

// Start listening for HTTP requests.
app.Run();
