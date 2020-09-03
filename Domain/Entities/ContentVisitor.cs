using System;
using Misty.Domain.Entities.Content;
using Misty.Domain.Entities.Users;

namespace Misty.Domain.Entities
{
    public class ContentVisitor
    {
        private ContentVisitor()
        {
        }

        public ContentVisitor(Content.Content content, Visitor visitor, Ad ad = null)
        {
            Content = content;
            Visitor = visitor;
            VisitedAd = DateTime.UtcNow;
            Ad = ad;
        }

        public Content.Content Content { get; }
        public Visitor Visitor { get; }
        public DateTime VisitedAd { get; }
        public Ad Ad { get; }
        public int VisitorId { get; private set; }
        public int ContentId { get; private set; }
    }
}