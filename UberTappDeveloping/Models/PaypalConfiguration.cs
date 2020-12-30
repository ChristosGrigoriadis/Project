using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace UberTappDeveloping.Models
{
    public static class PaypalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];

        } // static PaypalConfiguration() END //

        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();

        } //  public static Dictionary<string, string> GetConfig() END //

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;

        } // private static string GetAccessToken() END //

        public static APIContext GetAPIContext()
        {
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;

        } // public static APIContext GetAPIContext() END //

    } // public static class PaypalConfiguration END //

} // namespace UberTappDeveloping.Models END //