using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightProject.PageObjectModels.Components
{
    public class CartComponent
    {
        private readonly IPage _page;
        public readonly ILocator _cartIcon;

        public CartComponent(IPage page)
        {
            _page = page;
            _cartIcon = page.Locator(".shopping_cart_link");
        }

        public ILocator CartIcon => _cartIcon;

        public async Task GoToCartAsync()
        {
            await _cartIcon.ClickAsync();
        }
    }
}
