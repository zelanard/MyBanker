using MyBanker.Util;
using System;
using System.Collections.Generic;
namespace MyBanker.Model.Cards.BankCards
{
    /// <summary>
    /// <c>DebitCreditCard</c> Models a card which is both a debitcard and a credit card.
    /// </summary>
    public class DebitCreditCard
    {
        /// <summary>
        /// The Debit portion of the card
        /// </summary>
        public DebitCard DebitCard { get; set; }

        /// <summary>
        /// The credit portion of the card
        /// </summary>
        public CreditCard CreditCard { get; set; }

        public DebitCreditCard(Sint minBalance, DateTime expirationDate, string cardHolder, int securityNumber, string password, List<string> countries, bool canPayInStore, bool onlineTrade, Area areaOfUse, string cardNumber, ushort age, string accountNumber, uint maxDay = 0, uint maxMonth = 0, uint maxYear = 0)
        {
            DebitCard = new DebitCard(CardTypes.Debit, expirationDate, cardHolder, securityNumber, password, countries, canPayInStore, onlineTrade, areaOfUse, cardNumber, age, accountNumber, maxDay, maxMonth, maxYear);
            CreditCard = new CreditCard(minBalance, CardTypes.Credit, expirationDate, cardHolder, securityNumber, password, countries, canPayInStore, onlineTrade, areaOfUse, cardNumber, age, accountNumber, maxDay, maxMonth, maxYear);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return
                $"===== Master Card =====" +
                $"{DebitCard}" +
                $"\n\r\n\r" +
                $"{CreditCard}";
        }
    }
}
