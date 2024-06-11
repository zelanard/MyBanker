using MyBanker.Util;
using System;
using System.Collections.Generic;

namespace MyBanker.Model.Cards.BankCards
{
    /// <summary>
    /// <c>Debit</c> Models a generic Debit Card
    /// </summary>
    public abstract class Debit : BankCard
    {
        protected Debit(CardTypes cardType, DateTime expirationDate, string cardHolder, int securityNumber, string password, List<string> countries, bool canPayInStore, bool onlineTrade, Area areaOfUse, string cardNumber, ushort age, string accountNumber, uint maxDay = 0, uint maxMonth = 0, uint maxYear = 0)
            : base(cardType, expirationDate, cardHolder, securityNumber, password, countries, canPayInStore, onlineTrade, areaOfUse, cardNumber, age, accountNumber, maxDay, maxMonth, maxYear)
        { }

        /// <summary>
        /// Withdraw money from the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="account"></param>
        /// <returns>true if the withdrawal was successful</returns>
        public bool Withdrawal(Sint amount, Account account)
        {
            uint pamount = (uint)(amount * -1);
            if (account.AccountNumber == this.AccountNumber && account.Balance > amount)
            {
                account.Balance += amount;
                Today += pamount;
                ThisMonth += pamount;
                ThisYear += pamount;

                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
