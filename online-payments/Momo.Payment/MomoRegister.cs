using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Momo.Payment.AppOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Momo.Payment
{
    public static class MomoRegisters
    {
        public static void MomoRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMomoService, MomoService>();


        }
    }
}
