using ERP.DataBase;
using ERP.Middlewares;
using ERP.Common.Services;
using ERP.Core.DataAccess;
using ERP.HRAdmin.Service;
using Microsoft.OpenApi.Models;
using ERP.Candidate.CRM.Mapper;
using ERP.Notification.Service;
using ERP.Authentication.Domain;
using CandidateCRM.Configurations;
using ERP.CustomerCare.Repository;
using ERP.HRAdminSttaf.Repository;
using ERP.Notifications.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CRM.Authentication.Repository;
using ERP.TaskManagement.Repository;
using ERP.ProfileManagement.Service;
using System.Text.Json.Serialization;
using ERP.CRM.CaseManagement.Service;
using ERP.CRM.TaskManagement.Service;
using ERP.ContactManagement.Repository;
using ERP.ProfileManagement.Repository;
using ERP.DocumentManagement.Repository;
using ERP.CRM.ContactManagement.Service;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using ERP.CRM.DocumentManagement.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ERPDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"), x => x.MigrationsAssembly(typeof(Program).Assembly.FullName)));

builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ERPDb>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IPasswordReset_Repo, PasswordReset_Repo>();
builder.Services.AddScoped<IPasswordReset_Service, PasswordReset_Service>();
builder.Services.AddScoped<IEmail_Service, Email_Service>();
builder.Services.AddScoped<IContactDetails_Repo,    ContactDetails_Repo>();
builder.Services.AddScoped<IEmergencyContacts_Repo, EmergencyContacts_Repo>();
builder.Services.AddScoped<ICaseCommetns_Repo, CaseCommetns_Repo>();
builder.Services.AddScoped<ICase_Repo, Case_Repo>();
builder.Services.AddScoped<IAssetManager_Repo, AssetManager_Repo>();
builder.Services.AddScoped<IAttachments_Repo, Attachments_Repo>();
builder.Services.AddScoped<IHRNotes_Repo, HRNotes_Repo>();
builder.Services.AddScoped<INotifications_Repo, Notifications_Repo>();
builder.Services.AddScoped<ICandidate_Repo,     Candidate_Repo>();
builder.Services.AddScoped<IEducation_Repo,     Education_Repo>();
builder.Services.AddScoped<IJobExperience_Repo, JobExperience_Repo>();
builder.Services.AddScoped<IProfessionalLicense_Repo, ProfessionalLicense_Repo>();
builder.Services.AddScoped<IPersonal_Repo,      Personal_Repo>();
builder.Services.AddScoped<IGeneralTask_Repo,   GeneralTask_Repo>();
builder.Services.AddScoped<ICaseComments_Service,CaseComments_Service>();
builder.Services.AddScoped<ICaseManagment_Service, CaseManagment_Service>();
builder.Services.AddScoped<IContactDetails_Service, ContactDetails_Service>();
builder.Services.AddScoped<IEmergencyContact_Service, EmergencyContact_Service>();
builder.Services.AddScoped<IAssetManager_Service, AssetManager_Service>();
builder.Services.AddScoped<IAttachments_Service, Attachments_Service>();
builder.Services.AddScoped<IGeneralTask_Service, GeneralTask_Service>();
builder.Services.AddScoped<IHRNotes_Service, HRNotes_Service>();
builder.Services.AddScoped<INotifications_Service, Notifications_Service>();
builder.Services.AddScoped<ICandidate_Service, Candidate_Service>();
builder.Services.AddScoped<IEducations_Service, Educations_Service>();
builder.Services.AddScoped<IJobExperience_Repo, JobExperience_Repo>();
builder.Services.AddScoped<IJobExperience_Service, JobExperience_Service>();
builder.Services.AddScoped<IProfile_Service, Profile_Service>();
builder.Services.AddScoped<IProfessionalLicense_Service, ProfessionalLicense_Service>();
builder.Services.AddScoped<IDependent_Repo, Dependent_Repo>();
builder.Services.AddScoped<IDependent_Service, Dependent_Service>();
builder.Services.ConfigureIdentity();
builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(typeof(ConfigureDTOS));
builder.Services.ConfigureJwt(builder.Configuration);



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 3L * 1024 * 1024 * 1024; // 3GB in bytes
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter Bearer and space with valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        In = ParameterLocation.Header
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins("https://sapientmedical.web.app", "http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var env = serviceProvider.GetRequiredService<IWebHostEnvironment>();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseRouting();
var uploadedImagesPath = Path.Combine(builder.Environment.ContentRootPath, "UploadedImages");

if (!Directory.Exists(uploadedImagesPath))
{
    Directory.CreateDirectory(uploadedImagesPath);
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadedImagesPath),
    RequestPath = "/UploadedImages"
});

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();




