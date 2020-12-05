namespace NatureShot.Services
{
    using System;
    using System.Threading.Tasks;

    using NatureShot.Web.ViewModels.Recaptcha;

    public interface IGoogleRecapchaService
    {
        Task<RecaptchaRespnse> Verify(string _Token);
    }
}
