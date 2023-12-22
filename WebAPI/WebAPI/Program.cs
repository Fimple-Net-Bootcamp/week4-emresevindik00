using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using Core;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contexts;
using Entities.Dtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IUserDal, EfUserDal>();

builder.Services.AddSingleton<IPetService, PetManager>();
builder.Services.AddSingleton<IPetDal, EfPetDal>();

builder.Services.AddSingleton<IHealthService, HealthManager>();
builder.Services.AddSingleton<IHealthDal, EfHealthDal>();

builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IUserDal, EfUserDal>();

builder.Services.AddSingleton<INutrientService, NutrientManager>();
builder.Services.AddSingleton<INutrientDal, EfNutrientDal>();

builder.Services.AddSingleton<IEducationService, EducationManager>();
builder.Services.AddSingleton<IEducationDal, EfEducationDal>();

builder.Services.AddSingleton<ISocialInteractionService, SocialInteractionManager>();
builder.Services.AddSingleton<ISocialInteractionDal, EfSocialInteractionDal>();

builder.Services.AddSingleton<IActivityService, ActivityManager>();
builder.Services.AddSingleton<IActivityDal, EfActivityDal>();

builder.Services.AddDbContext<PetContext>();

builder.Services.AddSingleton<IValidator<ActivityDto>, ActivityValidator>();
builder.Services.AddSingleton<IValidator<HealthDto>, HealthValidator>();
builder.Services.AddSingleton<IValidator<PetDto>, PetValidator>();
builder.Services.AddSingleton<IValidator<NutrientDto>, NutrientValidator>();
builder.Services.AddSingleton<IValidator<UserDto>, UserValidator>();
builder.Services.AddSingleton<IValidator<EducationDto>, EducationValidator>();
builder.Services.AddSingleton<IValidator<SocialInteractionDto>, SocialInteractionValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
