namespace MyBanker.Model.Cards
{
    /// <summary>
    /// Creates a template for the maximum withdrawal of money
    /// </summary>
    public interface IMaxUse
    {
        uint MaxDay { get; }
        uint MaxMonth { get; }
        uint MaxYear { get; }
        uint Today { get; }
        uint ThisMonth { get; }
        uint ThisYear { get; }
    }
}
