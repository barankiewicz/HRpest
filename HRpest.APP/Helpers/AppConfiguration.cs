using Microsoft.Extensions.Configuration;
using System;

namespace HRpest.APP.Helpers
{
    public static class AppConfiguration
    {
        private static IConfiguration currentConfig;

        public static void SetConfiguration(IConfiguration configuration)
        {
            currentConfig = configuration;
        }


        public static string GetConfiguration(string configKey)
        {
            try
            {
                string connectionString = currentConfig.GetConnectionString(configKey);
                return connectionString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
