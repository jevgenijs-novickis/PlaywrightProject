using Microsoft.Playwright;

namespace PlaywrightProject.PageObjectModels.Pages
{
    public class CartPage
    {
        private readonly IPage _page;
        private readonly ILocator _cartItemName;
        private readonly ILocator _cartItemPrice;
        private readonly ILocator _cartItemQuantity;
        private readonly ILocator _checkoutButton;

        public CartPage(IPage page)
        {
            _page = page;
            _cartItemName = page.Locator(".inventory_item_name");
            _cartItemPrice = page.Locator(".inventory_item_price");
            _cartItemQuantity = page.Locator(".cart_quantity");
            _checkoutButton = page.Locator("#checkout");
        }

        public async Task VerifyCartAsync(string itemName, string expectedPrice, string expectedQuantity)
        {
            Assert.That(await _cartItemName.InnerTextAsync(), Is.EqualTo(itemName), "The item name in the cart is incorrect.");
            Assert.That(await _cartItemPrice.InnerTextAsync(), Is.EqualTo(expectedPrice), "The item price in the cart is incorrect.");
            Assert.That(await _cartItemQuantity.InnerTextAsync(), Is.EqualTo(expectedQuantity), "The item quantity in the cart is incorrect.");
        }

        public async Task ProceedToCheckoutAsync()
        {
            await _checkoutButton.ClickAsync();
        }
    }
}
