using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Core.Repositories;
using SMS.WebApp.Data;
using SMS.WebApp.Services.IServices;
using SMS.WebApp.Services.Services;

namespace SMS.WebApp.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
            //get connection string
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            // add db context
            builder.Services.AddDbContext<SMSDbContext>(options =>
                options.UseSqlServer(connectionString));
            // used user and roles for token
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SMSDbContext>();
            builder.Services.AddTransient<IAccountRepositories, AccountRepositories>();
            builder.Services.AddTransient<IAccountServices, AccountServices>();
            builder.Services.AddTransient<IStudentRepositories, StudentRepositories>();
            builder.Services.AddTransient<IStudentServices, StudentServices>();
            builder.Services.AddTransient<ITeacherRepositories, TeacherRepositories>();
            builder.Services.AddTransient<ITeacherServicesr, TeacherServices>();
            builder.Services.AddTransient<ICourseRepositories, CourseRepositories>();
            builder.Services.AddTransient<ICourseServices, CourseServices>();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}