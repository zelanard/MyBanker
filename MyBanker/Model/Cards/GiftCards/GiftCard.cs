using MyBanker.Util;
using System;
using System.Collections.Generic;

namespace MyBanker.Model.Cards.GiftCards
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class GiftCard : Card
    {
        /// <summary>
        /// The balance on the card
        /// </summary>
        public uint Balance { get; private set; }

        protected GiftCard(CardTypes cardType, DateTime expirationDate, string cardHolder, int securityNumber, string password, List<string> countries, bool canPayInStore, bool onlineTrade, Area areaOfUse, string cardNumber, uint balance)
            : base(cardType, expirationDate, cardHolder, securityNumber, password, countries, canPayInStore, onlineTrade, areaOfUse, cardNumber)
        {
            this.Balance = balance;
        }

        /// <summary>
        /// Reduce the balance on the card
        /// </summary>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public bool Reduce(Sint Amount)
        {
            int balance = (int)Balance;
            int amount = Amount;
            if (balance + amount > -1)
            {
                balance += amount;
                Balance = (uint)balance;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Balance: {Balance}\n\r" +
                    $"{base.ToString()}";
        }
    }
}
