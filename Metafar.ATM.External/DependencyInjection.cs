﻿using Metafar.ATM.Application.External;
using Metafar.ATM.External.GetTokenJwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Metafar.ATM.External;

public static class DependencyInjection
{
    public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKeyJwt"] ?? string.Empty)),
                ValidIssuer = configuration["Issuer"],
                ValidAudience = configuration["Audience"]
            };
        });

        return services;
    }
}
