using Newtonsoft.Json;

namespace flickapi
{
    public class Program
    {
        static void Main()
        {
            var tokenRequest = new TokenRequest("your email address","your password");
            var token = FlickAPI.GetToken(tokenRequest);
            var marketPrice = FlickAPI.GetMarketPrice(token);
            System.Console.Out.Write(JsonConvert.SerializeObject(marketPrice));
        }
    }

}
