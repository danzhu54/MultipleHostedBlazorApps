var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/apps"), spa =>
//{
//    spa.UseBlazorFrameworkFiles("/first");
//    spa.UseStaticFiles("/first");
//});

//app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/apps"), spa =>
//{
//    spa.UseBlazorFrameworkFiles("/second");
//    spa.UseStaticFiles("/second");

//    spa.UseRouting();
//    spa.UseEndpoints(endpoints =>
//    {
//        endpoints.MapControllers();
//        endpoints.MapFallbackToFile("/second/{*path:nonfile}",
//            "/apps/secondapp");
//    });
//});

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles("/apps/firstapp");
app.UseBlazorFrameworkFiles("/apps/secondapp");

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();
