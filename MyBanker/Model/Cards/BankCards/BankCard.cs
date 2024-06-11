using MyBanker.Util;
using System;
using System.Collections.Generic;

namespace MyBanker.Model.Cards.BankCards
{
    /// <summary>
    /// <c>BankCard</c> models a generic bankcard
    /// </summary>
    public abstract class BankCard : Card, IMaxUse
    {
        protected BankCard(CardTypes cardType,
            DateTime expirationDate,
            string cardHolder,
            int securityNumber,
            string password,
            List<string> countries,
            bool canPayInStore,
            bool onlineTrade,
            Area areaOfUse,
            string cardNumber,
            ushort age,
            string accountNumber,

            uint maxDay = 0,
            uint maxMonth = 0,
            uint maxYear = 0
            )
            : base(cardType, expirationDate, cardHolder, securityNumber, password, countries, canPayInStore, onlineTrade, areaOfUse, cardNumber)
        {
            if (maxDay > 0)
            {
                MaxDay = maxDay;
            }
            if (maxMonth > 0)
            {
                MaxMonth = maxMonth;
            }
            if (maxYear > 0)
            {
                MaxYear = maxYear;
            }
            Age = age;
            AccountNumber = accountNumber;

        }

        /// <summary>
        /// The age requried to possess this card.
        /// </summary>
        public ushort Age { get; private set; }
        
        /// <summary>
        /// The Account number which this card is associated with.
        /// </summary>
        public string AccountNumber { get; set; }
        
        /// <summary>
        /// The Maximum amount which can be withdrawn in one day.
        /// </summary>
        public uint MaxDay { get; private set; }
        
        /// <summary>
        /// The Maximum amount which can be withdrawn in one month.
        /// </summary>
        public uint MaxMonth { get; private set; }
        
        /// <summary>
        /// The Maximum amount which can be withdrawn in one year.
        /// </summary>
        public uint MaxYear { get; private set; }
        
        /// <summary>
        /// How much has been withdrawn today.
        /// </summary>
        public uint Today { get; set; }
        
        /// <summary>
        /// How much has been withdrawn this month.
        /// </summary>
        public uint ThisMonth { get; set; }

        /// <summary>
        /// How much has been withdrawn this year.
        /// </summary>
        public uint ThisYear { get; set; }

        /// <summary>
        /// place money into the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool Deposit(uint amount, Account account)
        {
            if (account.AccountNumber == this.AccountNumber)
            {
                account.Balance += (int)amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Age: {Age}\n\r" +
                $"AccountNumber: {AccountNumber}\n\r" +
                $"MaxDay: {MaxDay}\n\r" +
                $"MaxMonth: {MaxMonth}\n\r" +
                $"MaxYear: {MaxYear}\n\r" +
                $"Today: {Today}\n\r" +
                $"ThisMonth: {ThisMonth}\n\r" +
                $"ThisYear: {ThisYear}\n\r" +
                $"{base.ToString()}";
        }
    }
}
