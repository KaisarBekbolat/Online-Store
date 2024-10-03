using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SporteStore___2nd_try;
using SporteStore___2nd_try.Controllers;
using SporteStore___2nd_try.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opts
=>
{ opts.UseNpgsql(builder.Configuration["ConnectionStrings:Default"]); });
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

builder.Services.AddMemoryCache(); // For storing session data
builder.Services.AddSession();     // Registers required Dependencies for session

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles(); // TODO if that part is not specified -then wwwroot and css WILL NOT WORK

app.Routing(); // TODO make sure you have determined how it works, why link accepts {productPage} - and it is not ANYWHERE - it is not VARIABLE

app.UseSession(); // allows the session system to automatically associate requests with sessions when they arrive from the client.

app.MapDefaultControllerRoute();  // TODO - if i put "MapControllerRoute" after "MapDefaultControllerRoute" then 
                                  // it will create DEFAULT link and MapControllerRoute will NOT APPLIED

app.MapControllers(); // TODO this 2 line of codes ".MapControllers();" and ".MapRazorPages()"
                      // they are responsiable for creating "DEFAULT ENDOINTS" that could be navigted by CONVENTION

app.MapRazorPages();

//app.MapGet("/", () => "Hello World!");

app.Run();
