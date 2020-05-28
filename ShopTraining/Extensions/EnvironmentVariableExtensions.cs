using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTraining.Extensions
{
    public static class EnvironmentVariableExtensions
    {
        // public static string GetConnectionStringFromEnvironment(this IConfiguration configuration, string name = null)
        // {
        //     if(string.IsNullOrEmpty(name))
        //     {
        //         return Environment.GetEnvironmentVariable("shopTrainingConnectionString");
        //     } else
        //     {
        //         return Environment.GetEnvironmentVariable(name);
        //     }
        // }

        // public static string GetConnectionString(this IConfiguration configuration, string name)
        // {
        //     return configuration?.GetSection("ConnectionStrings")?[name];
        // }

    }
}
