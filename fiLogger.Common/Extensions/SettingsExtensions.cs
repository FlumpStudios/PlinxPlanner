using PlinxPlanner.Common.Settings;
using System;

namespace PlinxPlanner.Common.Extensions
{
    public static class SettingsExtensions
    {
       /// <summary>
       /// Extension method to check the validaty of the appsettings. 
       /// </summary>
       /// <param name="data"></param>
       /// <returns></returns>
        public static Tuple<bool, string> IsValid(this AppSettings data)
        {                       
            if (data == null)
            {
                return new Tuple<bool, string> (false,"Appsettings appear to be empty or corrupt");
            }

            if (data.Swagger == null)
            {
                return new Tuple<bool, string>(false, "No swagger settings have been set in the appsettings.json");
            }

            if (data.Swagger.Auth == null)
            {
                return new Tuple<bool, string>(false, "No swagger Auth options have been set in the appsettings.json");
            }

            if (data.Swagger.Auth.Scopes == null)
            {
                return new Tuple<bool, string>(false, "No swagger Auth scopes have been set in the appsettings.json");
            }

            if (data.API == null)
            {
                return new Tuple<bool, string>(false, "No API details have been entered in the appsettings.json");
            }

            if (data.Database == null)
            {
                return new Tuple<bool, string>(false, "No Database information has been added to the appsettings.json");
            }            

            if (data.Authentication == null)
            {
                return new Tuple<bool, string>(false, "No Authentication information has been added to the appsettings.json");
            }

            if (data.Caching == null)
            {
                return new Tuple<bool, string>(false, "No Caching information has been added to the appsettings.json");
            }

            if (string.IsNullOrEmpty(data.API.Title))
            {
                return new Tuple<bool, string>(false, "The API has not been given a title in the appsettings.json");
            }

            if (string.IsNullOrEmpty(data.Database.ConnectionString))
            {
                return new Tuple<bool, string>(false, "No ConnectionString has been specified in the appsettings.json (This should be added under the Database object)");
            }
            
            return new Tuple<bool, string>(true, "Appsettings OK");
        }
    }
}
