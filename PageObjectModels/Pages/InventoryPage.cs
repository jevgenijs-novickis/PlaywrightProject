using Microsoft.Playwright;

namespace PlaywrightProject.PageObjectModels.Pages
{
    public class InventoryPage
    {
        private readonly IPage _page;

        public InventoryPage(IPage page)
        {
            _page = page;
        }

        public ILocator Item(string itemName) => _page.Locator($"img[alt='{itemName}']");

        public async Task SelectItemAsync(string itemName)
        {
            await Item(itemName).ClickAsync();
        }
    }
}
