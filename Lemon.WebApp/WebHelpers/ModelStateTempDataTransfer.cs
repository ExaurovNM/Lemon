namespace Lemon.WebApp.WebHelpers
{
    using System.Web.Mvc;

    public abstract class ModelStateTempDataTransfer : ActionFilterAttribute
    {
        protected static readonly string Key = typeof(ModelStateTempDataTransfer).FullName;
    }
}