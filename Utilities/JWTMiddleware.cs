using MCExercise.Services.UserService;
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

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJWTUtils jwtUtils) 
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJWTToken(token);

            if (userId != Guid.Empty)
            {
                httpContext.Items["User"] = await userService.GetUserById(userId);
            }
            await _next(httpContext);
        }
    }
}
