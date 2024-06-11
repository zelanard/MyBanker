using MyBanker.Util;
using System;
using System.Collections.Generic;

namespace MyBanker.Model.Cards
{
    /// <summary>
    /// <c>ICard</c> creates a template for cards.
    /// </summary>
    public interface ICard
    {
        CardTypes CardType { get; }
        DateTime ExpirationDate { get; }
        string CardHolder { get; }
        int SecurityNumber { get; }
        string Password { get; }
        string CardNumber { get; }
        Area AreaOfUse { get; }
        bool OnlineTrade { get; }
        bool CanPayInStore { get; }
        List<string> Countries { get; }

    }
}
