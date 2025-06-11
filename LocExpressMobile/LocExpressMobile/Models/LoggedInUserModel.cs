using System.Security.Claims;

namespace LocExpressMobile.Models
{
    public record LoggedInUserModel(int Id, string Email, string Name)
    {
        public Claim[] ToClaims() =>
        [
            new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
            new Claim(ClaimTypes.Name, Name),
            new Claim(ClaimTypes.Email, Email)
        ];
    }
}
