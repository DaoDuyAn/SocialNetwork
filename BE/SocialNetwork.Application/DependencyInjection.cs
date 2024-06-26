﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services
                .AddMediatR(ctg =>
                {
                    ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                })
                .AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
