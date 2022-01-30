using MCExercise.Models;
using MCExercise.Models.Relations.One_to_One;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MCExercise.Utilities.Attributes
{
    public class AuthorizationAttribute: Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public AuthorizationAttribute(params Role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusCodeObject = new JsonResult(new { Meesage = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized};
            if (_roles == null)
            {
                context.Result = unauthorizedStatusCodeObject;
            }

            var user = (User) context.HttpContext.Items["User"];

            if (user == null || !_roles.Contains(user.Role))
            {
                context.Result = unauthorizedStatusCodeObject;
            }
        }
    }
}
