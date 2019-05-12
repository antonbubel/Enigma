namespace Enigma.Infrastructure.Configuration.Properties
{
    using System;

    using Common.ApplicationSettings;

    internal sealed class IdentitySettings : ApplicationSettingsBase
    {
        public static IdentitySettings Default
        {
            get
            {
                return new IdentitySettings("identity.settings.json");
            }
        }

        private IdentitySettings(string jsonFile)
            : base(jsonFile)
        {
        }

        public string JwtIssuer
        {
            get
            {
                return sections["jwt-issuer"].Value;
            }
        }

        public string JwtIssuerAudience
        {
            get
            {
                return sections["jwt-issuer-audience"].Value;
            }
        }

        public string SecretKey
        {
            get
            {
                return sections["secret-key"].Value;
            }
        }

        public int PasswordRequiredLength
        {
            get
            {
                return Convert.ToInt32(
                    sections["password-required-length"].Value
                );
            }
        }
    }
}
