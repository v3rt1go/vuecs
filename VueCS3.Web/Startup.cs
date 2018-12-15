using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueCS3.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VueCliMiddleware;
using System;
using VueCS3.Web.Services;
using Microsoft.AspNetCore.Routing;

namespace VueCS3.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				// The default consent cookie name is ".AspNet.Consent". cookie names starting with a . act funny
				// when setting them with document.cookie
				options.ConsentCookie.Name = "VueCS.Consent";
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDefaultIdentity<IdentityUser>()
				.AddDefaultUI(UIFramework.Bootstrap4)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddNodeServices();
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "wwwroot/dist";
			});

			// DI configuration
			services.AddTransient<MenuService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
				app.UseHttpsRedirection();
			}

			// app.UseStaticFiles();
			app.UseSpaStaticFiles();
			app.UseCookiePolicy();
			app.UseAuthentication();
			app.UseMvc();
			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "./";
				spa.Options.StartupTimeout = TimeSpan.FromSeconds(30);
				if (env.IsDevelopment())
				{
					spa.UseVueCli(npmScript: "serve", port: 8080);
				}
			});
		}
	}
}
