using System.Security.Claims;
using Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security;

public class UserAccessor : IUserAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public string GetUserId()
    {
        return _httpContextAccessor.HttpContext != null ? _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid) : null;
    }

}
