using Misty.Domain.Entities.Users;

namespace Misty.Domain.Entities
{
    public class ContentVisitor
    {
        public Content.Content Content { get; set; }
        public Visitor Visitor { get; set; }
        public string IpAddress { get; set; }
        public int ContentId { get; set; }

        public ContentVisitor(Content.Content content, Visitor visitor)
        {
            Content = content;
            Visitor = visitor;
        }
    }
}