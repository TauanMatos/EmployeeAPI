using API.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;

namespace API.Extensions
{
    public static class SimulateLatencyExtension
    {
        public static IApplicationBuilder UseSimulatedLatency(this IApplicationBuilder app, TimeSpan min, TimeSpan max)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware(
                typeof(SimulatedLatencyMiddleware),
                min,
                max
            );
        }
    }
}
