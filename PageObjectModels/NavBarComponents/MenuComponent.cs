using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightProject.PageObjectModels.Components
{
    public class MenuComponent
    {
        private readonly IPage _page;
        private readonly ILocator _menuIcon;
        private readonly ILocator _logoutOption;

        public MenuComponent(IPage page) 
        {
            _page = page;
            _menuIcon = page.Locator("#react-burger-menu-btn");
            _logoutOption = page.Locator("#logout_sidebar_link");
        }

        public async Task PerformLogoutAsync()
        {
            await _menuIcon.ClickAsync();
            await _logoutOption.ClickAsync();
        } 
    }
}
