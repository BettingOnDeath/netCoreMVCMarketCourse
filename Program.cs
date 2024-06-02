using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


//app.MapGet("/", (HttpContext context) =>{

//    string html = 
//    @"<html>
//                    <body>
//<h1>hello world<h1>
//<br/>Welcome to this new world!
//</body>
//</html>";
//    WriteHtml(context, html);
//});

//app.Run();

//void WriteHtml(HttpContext context , string html)
//{
//    context.Response.ContentType = MediaTypeNames.Text.Html;
//    context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
//    context.Response.WriteAsync(html);
//}