using System;
namespace NatureShot.Web.ViewModels.Recaptcha
{
    public class RecaptchaData
    {
        public RecaptchaData()
        {
        }

        public string response { get; set; }

        public string secret { get; set; }
    }
}
