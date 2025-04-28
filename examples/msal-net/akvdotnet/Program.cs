// <directives>
using System;
using System.Threading;
using Azure.Security.KeyVault.Secrets;
using Azure.Data.AppConfiguration;

// <directives>

namespace akvdotnet
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program P = new Program();

            //Retrieving permissions using workload identity
            MyClientAssertionCredential myClientAssertionCredential = new MyClientAssertionCredential();

            //key-vault
            string keyvaultURL = Environment.GetEnvironmentVariable("KEYVAULT_URL");
            if (string.IsNullOrEmpty(keyvaultURL)) {
                Console.WriteLine("KEYVAULT_URL environment variable not set");
                return;
            }

            string secretName = Environment.GetEnvironmentVariable("SECRET_NAME");
            if (string.IsNullOrEmpty(secretName)) {
                Console.WriteLine("SECRET_NAME environment variable not set");
                return;
            }

            SecretClient client = new SecretClient(
                new Uri(keyvaultURL),
                new MyClientAssertionCredential());

            Console.WriteLine($"{Environment.NewLine}START {DateTime.UtcNow} ({Environment.MachineName})");

            // <getsecret>
            var keyvaultSecret = client.GetSecret(secretName).Value;
            Console.WriteLine("Your secret is " + keyvaultSecret.Value);

            //app-configuration
            string appConfigEndpoint = Environment.GetEnvironmentVariable("APPCONFIG_ENDPOINT");

            // Nome da chave que você quer ler
            string key = Environment.GetEnvironmentVariable("APPCONFIG_KEY");

            // Cria um cliente de configuração
            var clientApp = new ConfigurationClient(new Uri(appConfigEndpoint), myClientAssertionCredential);

            // Lê a chave do Azure App Configuration
            ConfigurationSetting setting = clientApp.GetConfigurationSetting(key);

            // Exibe o valor da chave
            Console.WriteLine($"Valor da chave '{key}': {setting.Value}");
        }
    }
}
