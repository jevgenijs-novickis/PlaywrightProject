using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightProject.PageObjectModels.Pages
{
    public class CheckoutPage
    {
        private readonly IPage _page;
        private readonly ILocator _firstNameField;
        private readonly ILocator _lastNameField;
        private readonly ILocator _postalCodeField;
        private readonly ILocator _continueButton;
        private readonly ILocator _checkoutSummaryContainer;
        private readonly ILocator _checkoutItemName;
        private readonly ILocator _checkoutItemPrice;
        private readonly ILocator _checkoutItemQuantity;
        private readonly ILocator _finishButton;
        private readonly ILocator _checkoutCompleteContainer;
        private readonly ILocator _confirmationHeader;

        public CheckoutPage(IPage page)
        {
            _page = page;
            _firstNameField = page.Locator("#first-name");
            _lastNameField = page.Locator("#last-name");
            _postalCodeField = page.Locator("#postal-code");
            _continueButton = page.Locator("#continue");
            _checkoutSummaryContainer = page.Locator("#checkout_summary_container");
            _checkoutItemName = page.Locator(".inventory_item_name");
            _checkoutItemPrice = page.Locator(".inventory_item_price");
            _checkoutItemQuantity = page.Locator(".cart_quantity");
            _finishButton = page.Locator("#finish");
            _checkoutCompleteContainer = page.Locator("#checkout_complete_container");
            _confirmationHeader = page.Locator(".complete-header");
        }

        public ILocator CheckoutSummaryContainer => _checkoutSummaryContainer;

        public async Task FillCheckoutInformationAsync(string firstName, string lastName, string postalCode)
        {
            await _firstNameField.FillAsync(firstName);
            await _lastNameField.FillAsync(lastName);
            await _postalCodeField.FillAsync(postalCode);
        }

        public async Task ContinueAsync()
        {
            await _continueButton.ClickAsync();
        }

        public async Task VerifyOrderSummaryAsync(string itemName, string itemPrice, string itemQuantity) 
        {
            Assert.That(await _checkoutItemName.InnerTextAsync(), Is.EqualTo(itemName), "The item name on checkout page is incorrect.");
            Assert.That(await _checkoutItemPrice.InnerTextAsync(), Is.EqualTo(itemPrice), "The item price on checkout page is incorrect.");
            Assert.That(await _checkoutItemQuantity.InnerTextAsync(), Is.EqualTo(itemQuantity), "The item quantity on checkout page is incorrect.");
        }

        public async Task FinishAsync() 
        {
            await _finishButton.ClickAsync();
        }

        public async Task VerifyOrderConfirmationIsDisplayedAsync() 
        {
            await _checkoutCompleteContainer.IsDisabledAsync();
            await _confirmationHeader.IsDisabledAsync();

            Assert.That(await _confirmationHeader.InnerTextAsync(), Is.EqualTo("Thank you for your order!"), "Confirmation message assertion failed.");
        }
    }
}
