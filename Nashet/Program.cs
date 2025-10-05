using Microsoft.EntityFrameworkCore;
using Nashet.Business.Domain;
using Nashet.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Nashet.Data.Models.NashetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NashetContext")));

builder.Services.AddScoped<MembershipRepository>();
builder.Services.AddScoped<MembershipDomain>();
builder.Services.AddScoped<AnnouncementRepository>();
builder.Services.AddScoped<AnnouncementDomain>();
builder.Services.AddScoped<SystemRoleRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserDomain>();
builder.Services.AddScoped<KFUuserRepository>();
builder.Services.AddScoped<KfuUserDomain>();
builder.Services.AddScoped<ActivityRequestRepository>();
builder.Services.AddScoped<ActivityRequestDomain>();
builder.Services.AddScoped<ReportDomain>();
builder.Services.AddScoped<ReportRepository>();
builder.Services.AddScoped<SystemNotificationDomain>();
builder.Services.AddScoped<SystemNotificationRepository>();
builder.Services.AddScoped<ClubRepository>();
builder.Services.AddScoped<ClubDomain>();
builder.Services.AddScoped<ClubRoleRepository>();
builder.Services.AddScoped<ClubRoleDomain>();
builder.Services.AddScoped<SiteRepository>();
builder.Services.AddScoped<SiteDomain>();
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<StudentDomain>();
builder.Services.AddScoped<TeamRepository>();
builder.Services.AddScoped<TeamDomain>();
builder.Services.AddScoped<ActivityRepository>();
builder.Services.AddScoped<ActivityDomain>();
builder.Services.AddScoped<PositionRequestRepository>();
builder.Services.AddScoped<PositionRequestDomain>();
builder.Services.AddScoped<MembershipRequestRepository>();
builder.Services.AddScoped<MembershipRequestRepository>();
builder.Services.AddScoped<EmailNotificationDomain>();
builder.Services.AddScoped<EmailNotificationRepository>();
builder.Services.AddScoped<SystemLogsRepository>();
builder.Services.AddScoped<SystemLogsDomain>();




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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "ActivitiesSupervisor",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "ClubSupervisor",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "ClubLeader",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Student",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
