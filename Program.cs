var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//to config the routing
app.UseRouting();

app.UseAuthorization();

//to create a single Route (default route), puù essere sostituito da app.MapDefaultControllerRoute
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/* old version of Asp.Net
 * but first of this we need to add in Startup.cs =>
 *  public void ConfigureServices(IserviceCollection services)
 *  {
 *  services.AddMvc();
 *  }
app.UseMvc(routeBuilder =>
{
                                        /courses  /detail  /5
    routeBuilder.MapRoute("default", "{controller}/{action}/ {id?}");
});
*/

app.Run();
