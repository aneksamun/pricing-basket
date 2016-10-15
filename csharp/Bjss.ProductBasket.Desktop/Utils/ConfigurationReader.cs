namespace Bjss.ProductBasket.Desktop.Utils
{
    using Core.Extensions;
    using System.Configuration;

    internal static class ConfigurationReader
    {
        internal static string GetDatabaseFileName()
        {
            const string key = "databaseFileName";

            var fileName = ConfigurationManager.AppSettings[key];
            if (fileName.IsNullEmptyOrWhiteSpace())
                throw new ConfigurationErrorsException("No database file name found. Please check and update configuration.");

            return fileName;
        }
    }
}
