using Microsoft.EntityFrameworkCore;
using MyCompany;
using MyCompany.Interfaceis;

var builder = WebApplication.CreateBuilder(args);


var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(conn));

builder.Services.AddTransient<IOrganization, OrganizationRepository>();
builder.Services.AddTransient<ISotrudnik, SotrudnikRepository>();




builder.Services.AddMvc();

// Add services to the container.
builder.Services.AddControllersWithViews();

void Configuration(IApplicationBuilder app, IWebHostEnvironment evn)
{
	if (evn.IsDevelopment())
	{
		app.UseDeveloperExceptionPage();
	}
	else
	{
		app.UseExceptionHandler("/Home/Error");
		app.UseHsts();
	}
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
