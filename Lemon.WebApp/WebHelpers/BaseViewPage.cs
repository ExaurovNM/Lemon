namespace Lemon.WebApp.WebHelpers
{
    using System.Web.Mvc;

    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }
}