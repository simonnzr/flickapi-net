using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace flickapi
{
    public class FlickAPI
    {
        public static Token GetToken(TokenRequest tokenRequest)
        {
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

           StringBuilder postData = new StringBuilder();
            AppendUrlEncoded(postData, "client_id", tokenRequest.client_id);
            AppendUrlEncoded(postData, "client_secret", tokenRequest.client_secret);
            AppendUrlEncoded(postData, "grant_type", tokenRequest.grant_type);
            AppendUrlEncoded(postData, "password", tokenRequest.password);
            AppendUrlEncoded(postData, "username", tokenRequest.username);
            var byteResult = client.UploadData(Constants.TokenEndpoint, "POST", Encoding.ASCII.GetBytes(postData.ToString()));
            var jsonToken = JsonConvert.DeserializeObject<Token>(Encoding.ASCII.GetString(byteResult));
            return jsonToken;
        }

        public static MarketPrice GetMarketPrice(Token t)
        {
            var client = new WebClient();
            client.Headers.Add("Authorization", "Bearer " + t.id_token);
            var byteResult = client.DownloadData(Constants.MarketDataEndpoint);
            var json = Encoding.ASCII.GetString(byteResult);
            return JsonConvert.DeserializeObject<MarketPrice>(json);
        }


        public static void AppendUrlEncoded(StringBuilder sb, string name, string value)
        {
            if (sb.Length != 0) sb.Append("&");
            sb.Append(HttpUtility.UrlEncode(name));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode(value));
        }
    }
}
