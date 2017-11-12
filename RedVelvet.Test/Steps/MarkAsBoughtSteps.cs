﻿using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace RedVelvet.Test
{
    [Binding]
    public class MarkAsBoughtSteps : StepsBase
    {
        [When(@"I press as bought")]
        public void IPressAsBought()
        {
            app.WaitForElement(shoppingItemScreen.BoughtToggle);
            app.Tap(shoppingItemScreen.BoughtToggle);
        }

        [Then(@"I should see ""(.*)"" marked as (.*) in my shopping list")]
        public void ThenIShouldSeeItemMarkedAsStateInMyShoppingList(string name, string state)
        {
            var expectedState = state.ToLowerInvariant().Equals("bought") ? true : false;
            var bougth = app.Query(x => x.Marked(name).Parent().Class("ViewCellRenderer_ViewCellContainer").Child().Class("ImageRenderer")).Length == 2;

            Assert.AreEqual(expectedState, bougth);
        }
    }
}