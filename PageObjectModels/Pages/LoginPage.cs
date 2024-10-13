using Microsoft.Playwright;

namespace PlaywrightProject.PageObjectModels.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        private readonly ILocator _usernameField;
        private readonly ILocator _passwordField;
        private readonly ILocator _loginForm;
        private readonly ILocator _loginButton;

        public LoginPage(IPage page)
        {
            _page = page;
            _usernameField = page.Locator("#user-name");
            _passwordField = page.Locator("#password");
            _loginForm = page.Locator("#login_button_container");
            _loginButton = page.Locator("#login-button");
        }

        public async Task GotoAsync()
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task PerformLoginAsync(string username, string password)
        {
            await _usernameField.FillAsync(username);
            await _passwordField.FillAsync(password);
            await _loginButton.ClickAsync();
        }

        public async Task VerifyUserIsOnLoginPageAsync()
        {
            await _loginForm.IsDisabledAsync();
        }
    }
}
