using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using Devs.Application.Features.Auths.AuthServıce;
using Devs.Application.Features.GithubProfiles.Rules;
using Devs.Application.Features.OperationClaims.Rules;
using Devs.Application.Features.ProgrammingLanguages.Rules;
using Devs.Application.Features.Technologies.Rules;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Features.Users.Rules;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<TechnologyBusinessRules>();
            services.AddScoped<GithubBusinessRules>();
            services.AddScoped<UserOperationClaimBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<UserBusinessRules>();

            services.AddScoped<IAuthService, AuthManager>();

            return services;
        }
    }
}
