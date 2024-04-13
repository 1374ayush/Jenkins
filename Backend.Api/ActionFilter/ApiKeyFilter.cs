using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Backend.Api.ActionFilter
{
    public class ApiKeyFilter:ActionFilterAttribute
    {
        private IConfiguration _config;
      
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(" Action Executed");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (_config == null)
            {
                _config = context.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;
                if (_config == null)
                {
                    throw new InvalidOperationException("IConfiguration not available");
                }
            }

            string key = context.HttpContext.Request.Headers["api-key"];
            string keyToCheck = _config["Api-Key"];

            if (key == keyToCheck)
            {
                Console.WriteLine("Match!");
            }
            else
            {
                throw new UnauthorizedAccessException();
            }

            Console.WriteLine(" Action Executing");
        }
    }
}
