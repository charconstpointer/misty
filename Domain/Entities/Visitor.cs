namespace Misty.Domain.Entities
{
    public class Visitor
    {
        public Visitor(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public string IpAddress { get; }
    }
}