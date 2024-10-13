using Microsoft.Playwright.NUnit;
using PlaywrightProject.PageObjectModels.Pages;
using PlaywrightProject.PageObjectModels.Components;
using System.Text.RegularExpressions;

namespace PlaywrightProject.Tests
{
    public class BuyItemTest : PageTest
    {
        private string Username => Environment.GetEnvironmentVariable("SAUCE_USERNAME") ?? "standard_user";
        private string Password => Environment.GetEnvironmentVariable("SAUCE_PASSWORD") ?? "secret_sauce";

        [Test]
        [TestCase("Sauce Labs Bolt T-Shirt", "$15.99", "1")]
        public async Task PurchaseItem_ShouldCompleteCheckoutSuccessfully(string itemName, string expectedPrice, string expectedQuantity)
        {
            var loginPage = new LoginPage(Page);
            var inventoryPage = new InventoryPage(Page);
            var itemPage = new ItemPage(Page);
            var cartComponent = new CartComponent(Page);
            var cartPage = new CartPage(Page);
            var checkoutPage = new CheckoutPage(Page);
            var menuComponent = new MenuComponent(Page);

            await loginPage.GotoAsync();
            await loginPage.PerformLoginAsync(Username, Password);

            await Expect(Page).ToHaveURLAsync(new Regex(".*inventory\\.html"));
            await Expect(Page.Locator(".title")).ToHaveTextAsync("Products");

            await inventoryPage.SelectItemAsync(itemName);

            await Expect(Page).ToHaveURLAsync(new Regex(".*inventory-item\\.html"));
            await Expect(Page.Locator(".inventory_details_desc_container > .inventory_details_name"))
                .ToContainTextAsync(itemName);

            await itemPage.AddToCartAsync();

            await Expect(cartComponent.CartIcon).ToContainTextAsync(expectedQuantity);

            await cartComponent.GoToCartAsync();

            await Expect(Page).ToHaveURLAsync(new Regex(".*cart\\.html"));
            await Expect(Page.Locator(".title")).ToHaveTextAsync("Your Cart");

            await cartPage.VerifyCartAsync(itemName, expectedPrice, expectedQuantity);
            await cartPage.ProceedToCheckoutAsync();

            await Expect(Page).ToHaveURLAsync(new Regex(".*checkout.*\\.html$"));
            await Expect(Page.Locator(".title")).ToHaveTextAsync("Checkout: Your Information");

            await checkoutPage.FillCheckoutInformationAsync("John", "Smith", "1234");
            await checkoutPage.ContinueAsync();

            await Expect(checkoutPage.CheckoutSummaryContainer).ToBeVisibleAsync();

            await checkoutPage.VerifyOrderSummaryAsync(itemName, expectedPrice, expectedQuantity);
            await checkoutPage.FinishAsync();
            await checkoutPage.VerifyOrderConfirmationIsDisplayedAsync();

            await menuComponent.PerformLogoutAsync();

            await loginPage.VerifyUserIsOnLoginPageAsync();
        }
    }
}
