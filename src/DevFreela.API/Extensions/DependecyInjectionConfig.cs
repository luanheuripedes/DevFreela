using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Consumers;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.IRepositories;
using DevFreela.Core.IServices;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.MessageBus;
using DevFreela.Infrastructure.Payments;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using DevFreela.Infrastructure.Repositories;
using MediatR;

namespace DevFreela.API.Extensions
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Adicionado o hostedService para ficar escutando indefinidamente
            services.AddHostedService<PaymentApprovedConsumer>();
            //Adiciona o MediatR
            //busca no Assembly Application todas as classes que implementem IRequest<> 
            //e associar a todos o commands handler que implementam IRequestHandler<>
            services.AddMediatR(typeof(CreateProjectCommand));

            //para construir instancias do httpClient em varias partes do sistema para fazer requisições fora
            services.AddHttpClient();

            //Repositories
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            //Services
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMessageBusService, MessageBusService>();



            return services;
        }
    }
}
