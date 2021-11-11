namespace BugTracker.BlazorComponents
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;

    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                var challengeUri = "/login?redirectUri=" + System.Net.WebUtility.UrlEncode(this.NavigationManager.Uri);
                this.NavigationManager.NavigateTo(challengeUri, true);
            }
        }
    }
}
