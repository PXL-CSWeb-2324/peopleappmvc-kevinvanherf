using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PeopleApp.Api.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "ApiKey";
        private ContentResult GetContentResult(int statusCode  , string Content)
        {
            var result = new ContentResult();
            result.StatusCode = statusCode;
            result.Content = Content;
            return result;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
                {
                    context.Result = GetContentResult(401, "Api key was not provided");
                    return;
                }
                var appsettings= context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                if (appsettings == null)
                {
                    context.Result = GetContentResult(401, "Appsettings not found");
                    return;
                }
                var apiKey = appsettings.GetValue<string>(APIKEYNAME);
                if (apiKey == null)
                {
                    context.Result = GetContentResult(401, "Appsettings - ApiKey - not found");
                    return;
                }
               
                if (!apiKey.Equals(extractedApiKey))
                {
                    context.Result = GetContentResult(401, "Api key is nog valid");
                    return;
                }
                await next();
            }
            catch (Exception ex)
            {
                context.Result = GetContentResult(401,ex.Message );
                return;
            }
           
        }
    }
}
