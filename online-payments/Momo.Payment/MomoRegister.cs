using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Momo.Payment
{
    public static class MomoRegisters
    {
        public static void MomoRegister(this IServiceCollection services)
        {
            services.AddScoped<IMomoService, MomoService>();
        }
    }
}
