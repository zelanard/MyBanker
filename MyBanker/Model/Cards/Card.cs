using MyBanker.Util;
using System.Collections.Generic;
using System;
using System.Text;

namespace MyBanker.Model.Cards
{
    /// <summary>
    /// <c>Card</c> models a generic card.
    /// </summary>
    public abstract class Card : ICard
    {
        /// <summary>
        /// The type of card
        /// </summary>
        public virtual CardTypes CardType { get; private set; }

        /// <summary>
        /// The cards expiration date
        /// </summary>
        public virtual DateTime ExpirationDate { get; private set; }

        /// <summary>
        /// The owner of the card
        /// </summary>
        public virtual string CardHolder { get; private set; }

        /// <summary>
        /// the security number on the back of the card
        /// </summary>
        public virtual int SecurityNumber { get; private set; }

        /// <summary>
        /// The cards Passcode
        /// </summary>
        public virtual string Password { get; private set; }

        /// <summary>
        /// List of countries in which the card can be used. If the list is empty the card can be used anywhere.
        /// </summary>
        public virtual List<string> Countries { get; private set; }

        /// <summary>
        /// Whether or not the card can be used as a payment method in a store.
        /// </summary>
        public virtual bool CanPayInStore { get; private set; }

        /// <summary>
        /// Whether or not the card can be used as a payment method for online purchases.
        /// </summary>
        public virtual bool OnlineTrade { get; private set; }

        /// <summary>
        /// Which type of area the card can be used in.
        /// </summary>
        public virtual Area AreaOfUse { get; private set; }

        /// <summary>
        /// The cards uid number
        /// </summary>
        public virtual string CardNumber { get; private set; }

        protected Card(CardTypes cardType, DateTime expirationDate, string cardHolder, int securityNumber, string password, List<string> countries, bool canPayInStore, bool onlineTrade, Area areaOfUse, string cardNumber)
        {
            CardType = cardType;
            ExpirationDate = expirationDate;
            CardHolder = cardHolder;
            SecurityNumber = securityNumber;
            Password = password;
            Countries = countries;
            CanPayInStore = canPayInStore;
            OnlineTrade = onlineTrade;
            AreaOfUse = areaOfUse;
            CardNumber = cardNumber;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string country in Countries)
            {
                stringBuilder.Append(country);
                stringBuilder.Append(", ");
            }
            stringBuilder.Remove(stringBuilder.Length - 2, 2); //-2 because we want to remove both a space and a comma.

            return $"CardType: {CardType},\n\r" +
                    $"ExpirationDate: {ExpirationDate},\n\r" +
                    $"CardHolder: {CardHolder},\n\r" +
                    $"SecurityNumber: {SecurityNumber},\n\r" +
                    $"Password: {Password},\n\r" +
                    $"Countries: {stringBuilder},\n\r" +
                    $"CanPayInStore: {CanPayInStore},\n\r" +
                    $"OnlineTrade: {OnlineTrade},\n\r" +
                    $"AreaOfUse: {AreaOfUse},\n\r" +
                    $"CardNumber: {CardNumber}";
        }
    }
}