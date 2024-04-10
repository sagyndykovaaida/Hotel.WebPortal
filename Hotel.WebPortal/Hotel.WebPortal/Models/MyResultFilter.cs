using Microsoft.AspNetCore.Mvc.Filters;

namespace Hotel.WebPortal.Models
{
    public class MyResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(" Custom Header", "MyCustomValue");
        }
    }
}
