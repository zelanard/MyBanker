using MyBanker.Util;
using System;
using System.Collections.Generic;

namespace MyBanker.Model.Cards.BankCards
{
    /// <summary>
    /// <c>Credit</c> models a generic credit card.
    /// </summary>
    public abstract class Credit : BankCard
    {
        private Sint minBalance;

        /// <summary>
        /// Lent cannot be lower than minimum balance.
        /// todo: rename to MaxLoan.
        /// </summary>
        public Sint MinBalance { get; set; }

        /// <summary>
        /// The value lent this month.
        /// </summary>
        public Sint Lent { get; set; }

        protected Credit(Sint minBalance, CardTypes cardType, DateTime expirationDate, string cardHolder, int securityNumber, string password, List<string> countries, bool canPayInStore, bool onlineTrade, Area areaOfUse, string cardNumber, ushort age, string accountNumber, uint maxDay = 0, uint maxMonth = 0, uint maxYear = 0)
            : base(cardType, expirationDate, cardHolder, securityNumber, password, countries, canPayInStore, onlineTrade, areaOfUse, cardNumber, age, accountNumber, maxDay, maxMonth, maxYear)
        {
            MinBalance = minBalance;
            Lent = 0;
        }

        /// <summary>
        /// Loan money from the bank.
        /// </summary>
        /// <param name="amount">The negative value to be added to the lent value</param>
        /// <param name="account">The account to which the card belongs</param>
        /// <returns>true if the loan was successfull, else false</returns>
        public virtual bool Loan(Sint amount, Account account)
        {
            uint pamount = (uint)(amount * -1);
            if (account.AccountNumber == this.AccountNumber &&
                Lent - amount < MinBalance
                )
            {
                Lent += amount;
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

        /// <summary>
        /// Make up the Saldo
        /// </summary>
        /// <param name="account">The account to which the card belongs</param>
        /// <returns>true if the saldo was made up succesfully, else false</returns>
        public bool Saldo(Account account)
        {
            if (account.AccountNumber == this.AccountNumber)
            {
                account.Balance += Lent;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"MinBalance: {MinBalance}\n\r" +
                $"Lent: {Lent}\n\r" +
                $"{base.ToString()}";
        }
    }
}
