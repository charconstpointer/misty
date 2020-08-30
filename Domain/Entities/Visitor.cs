namespace Misty.Domain.Entities
{
    public class Visitor
    {
        public Visitor(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public Visitor()
        {
        }

        public string IpAddress { get; }
    }
}