using ecommerce.app.contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace ecommerce.api.Attrupiets
{
    public class RedisCasheAttribute:ActionFilterAttribute
    {        private readonly int Durationinsec;

        public RedisCasheAttribute(int durationinsec=90)
        {
            Durationinsec = durationinsec;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<ICasheService>();
            var cacheKey = CreateCashKey(context.HttpContext.Request);
            var cached = await cacheService.GetAsync(cacheKey);

            if (!string.IsNullOrEmpty(cached))
            {
                context.Result = new ContentResult
                {
                    Content = cached,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK
                };

                return;
            }
                var executed = await next.Invoke();
                if (executed.Result is OkObjectResult { Value: not null } ok)
                    await cacheService.SetAsync(cacheKey, ok.Value, TimeSpan.FromSeconds(Durationinsec));
            
        }

private string CreateCashKey(HttpRequest request)
        {
            var key = new StringBuilder();
            key.Append(request.Path).Append('?');
            foreach (var (k, v) in request.Query.OrderBy(q => q.Key))
                key.Append(k).Append('=').Append(v).Append('&');
            return key.ToString();
        }
    }
}
