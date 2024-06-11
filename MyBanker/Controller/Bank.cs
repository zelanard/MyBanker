using MyBanker.Model.Cards.BankCards;
using MyBanker.Model.Cards.GiftCards;
using MyBanker.Model;
using MyBanker.Util;
using System;
using System.Collections.Generic;

namespace MyBanker.Controller
{
    /// <summary>
    /// The Bank class simulates the operations of a bank by generating various types of cards.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Runs the bank operations by generating and displaying new cards.
        /// </summary>
        public void Run()
        {
            CardHolder holder = new CardHolder(18);
            Account account = new Account(Generator.GetAccountNumber());
            
            GiftCard giftCard = NewGiftCard();
            Console.WriteLine(giftCard);
            giftCard.Reduce(-50);
            Console.WriteLine();

            DebitCreditCard MasterCard = NewMasterCard(account.AccountNumber);
            Console.WriteLine(MasterCard);
            Console.WriteLine();
        }

        /// <summary>
        /// Creates a new gift card with random properties.
        /// </summary>
        /// <returns>A new StoreGiftCard instance.</returns>
        public GiftCard NewGiftCard()
        {
            Random rnd = new Random();
            return new StoreGiftCard(
                Generator.getRandomStore(),
                CardTypes.Gift,
                DateTime.Now.AddYears((int)Generator.ExpirationDates[CardList.GiftCard]),
                Generator.getName(),
                Generator.getSecurityNumber(),
                Generator.getPassword(),
                new List<string>() { "Denmark" },
                true,
                true,
                Area.National,
                Generator.getCardNumber(CardList.GiftCard),
                (uint)(rnd.Next(5, 1000)) * 10);
        }

        /// <summary>
        /// Creates a new Mastercard with predefined properties.
        /// </summary>
        /// <returns>A new DebitCreditCard instance representing a Mastercard.</returns>
        public DebitCreditCard NewMasterCard(string an)
        {
            return new DebitCreditCard(
                -40000,
                DateTime.Now.AddYears((int)Generator.ExpirationDates[CardList.Mastercard]),
                Generator.getName(),
                Generator.getSecurityNumber(),
                Generator.getPassword(),
                new List<string>() { "Denmark" },
                true,
                true,
                Area.National,
                Generator.getCardNumber(CardList.Mastercard),
                18,
                an,
                5000,
                30000
                );
        }
    }
}
