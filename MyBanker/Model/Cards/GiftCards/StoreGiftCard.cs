using MyBanker.Util;
using System;
using System.Collections.Generic;

namespace MyBanker.Model.Cards.GiftCards
{
    /// <summary>
    /// <c>StoreGiftCard</c> Models a gift card for a spesific store.
    /// </summary>
    internal class StoreGiftCard : GiftCard
    {
        /// <summary>
        /// The stores ID
        /// </summary>
        public string StoreID { get; private set; }

        public StoreGiftCard(string storeID, CardTypes cardType, DateTime expirationDate, string cardHolder, int securityNumber, string password, List<string> countries, bool canPayInStore, bool onlineTrade, Area areaOfUse, string cardNumber, uint balance)
            : base(cardType, expirationDate, cardHolder, securityNumber, password, countries, canPayInStore, onlineTrade, areaOfUse, cardNumber, balance)
        {
            StoreID = storeID;
        }
        public override string ToString()
        {
            return $"===== Store Gift Card =====\n\r" +
                $"StoreID: {StoreID},\n\r" +
                $"{base.ToString()}";
        }
    }
}
