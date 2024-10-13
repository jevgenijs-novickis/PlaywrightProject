using Microsoft.Playwright;

namespace PlaywrightProject.PageObjectModels.Pages
{
    public class ItemPage
    {
        private readonly IPage _page;
        private readonly ILocator _addToCartButton;

        public ItemPage(IPage page)
        {
            _page = page;
            _addToCartButton = page.Locator("#add-to-cart");
        }

        public async Task AddToCartAsync()
        {
            await _addToCartButton.ClickAsync();
        }
    }
}
