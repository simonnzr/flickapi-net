namespace flickapi
{
    public class TokenRequest
    {
        public string grant_type = "password";
        public string client_id = Constants.ClientId;
        public string client_secret = Constants.ClientSecret;
        public string username;
        public string password;

        public TokenRequest(string user, string pass)
        {
            username = user;
            password = pass;
        }
    }
}
