﻿using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Infrastructure.EF;
using SocialNetwork.Infrastructure.Repositories;
using SocialNetwork.Infrastructure.Repositories.Account;
using SocialNetwork.Infrastructure.Repositories.Category;
using SocialNetwork.Infrastructure.Repositories.Data;
using SocialNetwork.Infrastructure.Repositories.Post;
using SocialNetwork.Infrastructure.Repositories.RefreshToken;
using SocialNetwork.Infrastructure.Repositories.Role;
using SocialNetwork.Infrastructure.Repositories.User;

namespace SocialNetwork.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IPostRepository, PostRepository>()
                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IDataContext, DataContext>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
           , IConfiguration configuration)
        {
            return services.AddDbContext<SocialNetworkDbContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("SocialNetworkConnectionString")));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services
           )
        {
            return services.AddSingleton<SocialNetwork.Infrastructure.Dapper.DapperContext>(); ;
        }
    }
}
