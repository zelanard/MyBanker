using MyBanker.Util;
using System;
using System.Collections.Generic;

namespace MyBanker.Model.Cards.BankCards
{
    /// <summary>
    /// <c>CreditCard</c> models a credit card.
    /// </summary>
    public class CreditCard : Credit
    {
        public CreditCard(Sint minBalance, CardTypes cardType, DateTime expirationDate, string cardHolder, int securityNumber, string password, List<string> countries, bool canPayInStore, bool onlineTrade, Area areaOfUse, string cardNumber, ushort age, string accountNumber, uint maxDay = 0, uint maxMonth = 0, uint maxYear = 0)
            : base(minBalance, cardType, expirationDate, cardHolder, securityNumber, password, countries, canPayInStore, onlineTrade, areaOfUse, cardNumber, age, accountNumber, maxDay, maxMonth, maxYear)
        { }

        public override string ToString()
        {
            return $"===== Credit Card =====\n\r" +
                $"{base.ToString()}";
        }
    }
}
