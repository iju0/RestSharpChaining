namespace DomainLayer
{
    public interface IEmail
    {
        string Content { get; set; }
        string Receiver { get; set; }
        string Sender { get; set; }
        string Title { get; set; }
    }
}