using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PlinxPlanner.IoC.Config.OperationFilters
{    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            const string UNAUTHORISED_CODE = "401";
            const string FORBIDDEN_CODE = "403";

            var hasAuthorize =
                 context.MethodInfo.DeclaringType.GetCustomAttributes(typeof(AuthorizeAttribute)).Any();
            if (hasAuthorize)
            {
                if (!operation.Responses.Keys.Contains(UNAUTHORISED_CODE)) operation.Responses.Add(UNAUTHORISED_CODE, new Response { Description = "Unauthorized" });
                if (!operation.Responses.Keys.Contains(FORBIDDEN_CODE)) operation.Responses.Add(FORBIDDEN_CODE, new Response { Description = "Forbidden" });

                operation.Security = new List<IDictionary<string, IEnumerable<string>>> {
                    new Dictionary<string, IEnumerable<string>> {{"oauth2", new[] {"demo_api"}}}
            };
            }
        }
    }
}
