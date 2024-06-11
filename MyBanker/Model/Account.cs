using System.Runtime.Remoting.Channels;

namespace MyBanker.Model
{
    /// <summary>
    /// <c>Account</c> models a bank account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The accounts accountnumber
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// the accounts balance
        /// </summary>
        public int Balance { get; set; }

        public Account(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
    }
}
