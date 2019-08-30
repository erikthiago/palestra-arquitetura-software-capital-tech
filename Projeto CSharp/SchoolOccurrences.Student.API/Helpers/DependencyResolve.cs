using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SchoolOccurrences.School.Domain.Handlers;
using SchoolOccurrences.School.Domain.Repositories.Interfaces;
using SchoolOccurrences.School.Infra.Contexts.Dapper;
using SchoolOccurrences.School.Infra.Contexts.Entity;
using SchoolOccurrences.School.Infra.Repositories;
using SchoolOccurrences.School.Infra.UnitOfWork;
using SchoolOccurrences.Shared.Commons.Interfaces.UnitOfWork;
using System;

namespace SchoolOccurrences.Student.API.Helpers
{
    // Classe responsável por resolver a injeção de dependencias do projeto
    public class DependencyResolve
    {
        private static readonly Func<IServiceProvider, EntityContext> repoFactoryEntity = (_) =>
        {
            return new EntityContext();
        };

        private static readonly Func<IServiceProvider, DapperContext> repoFactoryDapper = (_) =>
        {
            return new DapperContext();
        };

        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain - Commands
            //services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>(); Verificar depois

            // Infra - Data
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddTransient<StudentCommandHandler, StudentCommandHandler>();

            // Infra - Contexts
            services.AddScoped<EntityContext>(repoFactoryEntity);
            services.AddScoped<DapperContext>(repoFactoryDapper);

            // Infra - Data EventSourcing

            // Infra - Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
