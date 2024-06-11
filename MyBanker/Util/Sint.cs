using System;

namespace MyBanker.Util
{
    /// <summary>
    /// <c>Sint</c> This is an integer which must always be signed.
    /// </summary>
    public class Sint
    {
        private int _value;

        /// <summary>
        /// Property to ensure the value is always negative.
        /// </summary>
        public int Value
        {
            get { return _value; }
            private set
            {
                if (value > 0)
                    throw new ArgumentException("a signed integer must be negative.");
                _value = value;
            }
        }

        /// <summary>
        /// Implicit conversion from int to Sint.
        /// This gives us the ability to set an sint = to an int, so long as the int is signed.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Sint(int value)
        {
            if (value > 0)
                throw new ArgumentException("a signed integer must be negative.");
            return new Sint { _value = value };
        }

        /// <summary>
        /// Implicit conversion from Sint to int.
        /// This gives us the ability to set an int = to an sint.
        /// </summary>
        /// <param name="sint"></param>
        public static implicit operator int(Sint sint)
        {
            return sint._value;
        }

        /// <summary>
        /// Make sure that the value of the sint is returned as a string when the sint is ToStringed.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _value.ToString();
        }
    }

}
