using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BackendAssessment.Repositories.Common.Contexts
{
    public class BaseContext : DbContext
    {
        public IHttpContextAccessor HttpContextAccessor { get; }

        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        public BaseContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public virtual Guid GetUserId()
        {
            Guid userId = Guid.Empty;
            if (HttpContextAccessor != null
                && HttpContextAccessor.HttpContext != null
                && HttpContextAccessor.HttpContext.User != null
                && HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var rawKey = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Guid.TryParse(rawKey, out userId);
            }
            return userId;
        }
    }
}