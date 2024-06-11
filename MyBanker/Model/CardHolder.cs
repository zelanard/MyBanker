using MyBanker.Model.Cards;
using System.Collections.Generic;

namespace MyBanker.Model
{
    /// <summary>
    /// <c>CardHolder</c> models a card holder.
    /// </summary>
    public class CardHolder
    {
        /// <summary>
        /// The CardHolders Age.
        /// </summary>
        public ushort Age { get; set; }
        
        /// <summary>
        /// A list of all the users cards.
        /// </summary>
        public List<ICard> Cards { get; private set; }
        
        /// <summary>
        /// Construct the CardHolder
        /// </summary>
        public CardHolder(ushort age)
        {
            Age = age;
            Cards = new List<ICard>();
        }
    }
}
