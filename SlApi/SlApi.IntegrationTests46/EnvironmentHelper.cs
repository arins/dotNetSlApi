using System;

namespace SlApi.IntegrationTests
{
    public class EnvironmentHelper
    {
        public static string GetEnvironmentVariable(string variable)
        {
            var variableValue  = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.User);
            if (variableValue != null)
            {
                return variableValue;
            }
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
        }
    }
}
