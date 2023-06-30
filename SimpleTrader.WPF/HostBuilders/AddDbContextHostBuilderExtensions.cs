using GameWorldDAL.Data.Identity;
using GameWorldDomain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;

namespace SimpleTrader.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddDbContext<DbContextIdentity>(options =>
                {
                    options.UseSqlServer(context.Configuration.GetConnectionString("IdentityConnection"));
                });

                services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DbContextIdentity>();

                services.AddScoped(sqlConnection => new SqlConnection(context.Configuration.GetConnectionString("ForumConnection")));
                services.AddScoped<IDbTransaction>(sqlConnection =>
                {
                    SqlConnection connection = sqlConnection.GetRequiredService<SqlConnection>();

                    connection.Open();

                    return connection.BeginTransaction();
                });
            });

            return host;
        }
    }
}