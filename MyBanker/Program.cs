using MyBanker.Controller;

namespace MyBanker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.Run();
        }
    }
}