using MCExercise.Services.UserService;
using MCExercise.Services.UniversityService;
using MCExercise.Utilities.JWTUtils;
using Microsoft.Extensions.Options;

namespace MCExercise.Utilities
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JWTMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings.Value;
            _next = next; 
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IUniversityService universityService, IJWTUtils jwtUtils) 
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var path = httpContext.Request.Path.ToString().Split("/")[1];
            var id = jwtUtils.ValidateJWTToken(token);
            if ( path == "universities" && id != Guid.Empty)
            {
                httpContext.Items["User"] = await universityService.GetById(id);
            }

            if ( path == "users" && id != Guid.Empty)
            {
                httpContext.Items["User"] = await userService.GetById(id);
            }
            await _next(httpContext);
        }
    }
}
