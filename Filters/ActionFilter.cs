using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Filters {
    public class ActionFilter : IActionFilter {
	private readonly ILogger<ActionFilter> log;

	public ActionFilter(ILogger<ActionFilter> log) {
	    this.log = log;
	}

	public void OnActionExecuting(ActionExecutingContext context) {
	    string log_string = $@"Got request {context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
	    log.LogInformation("Before Action\n" + log_string);
	}

	public void OnActionExecuted(ActionExecutedContext context) {
	    log.LogInformation("After Action");
	}
    }
}
