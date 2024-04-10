using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Hotel.WebPortal.Models
{
    public class TimeElaps : Attribute, IActionFilter

    {
        private Stopwatch timer;
        private readonly ILogger<TimeElaps> _logger; 

        public TimeElaps(ILogger<TimeElaps> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = "Elipsed time: " + timer.ElapsedMilliseconds;
            _logger.LogInformation(result);
        }
         
        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();  
        }
    }
}
