using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BugTracker.BlazorComponents.Pages
{
    public class LoginModel : PageModel
    {
        public async Task OnGet(string redirectUri)
        {
            await HttpContext.ChallengeAsync("Oidc", new AuthenticationProperties
            {
                RedirectUri = redirectUri
            });
        }
    }
}
