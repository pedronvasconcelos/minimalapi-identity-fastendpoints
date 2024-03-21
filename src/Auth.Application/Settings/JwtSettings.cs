

namespace Auth.Application.IdentitySettings
{
    public class JwtSettings
    {
        public string Secret { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public int ExpiryInMinutes { get; set; }
        public int RefreshTokenExpiryInMinutes { get; set; }   

         public JwtSettings()
        {
        }

    }
}
