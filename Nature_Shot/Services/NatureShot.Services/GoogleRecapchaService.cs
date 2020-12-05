namespace NatureShot.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Options;
    using NatureShot.Web.ViewModels.Recaptcha;
    using Newtonsoft.Json;

    public class GoogleRecapchaService : IGoogleRecapchaService
    {
        private readonly IOptions<RecaptchaV3> settings;

        public GoogleRecapchaService(IOptions<RecaptchaV3> settings)
        {
            this.settings = settings;
        }

        public virtual async Task<RecaptchaRespnse> Verify(string _Token)
        {
            var data = new RecaptchaData
            {
                response = _Token,
                secret = this.settings.Value.RecaptchaSiteSecret,
            };

            var client = new HttpClient();
            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={data.secret}&response={data.response}");
            var googleResp = JsonConvert.DeserializeObject<RecaptchaRespnse>(response);
            return googleResp;
        }
    }
}
