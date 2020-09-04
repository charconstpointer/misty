using System;
using System.Collections.Generic;

namespace Misty.Domain.Entities.Users
{
    public class Visitor
    {
        public Visitor(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        protected Visitor()
        {
        }

        public int Id { get; }
        public string IpAddress { get; protected set; }
        private readonly ICollection<ContentVisitor> _contentVisitors = new List<ContentVisitor>();

        public void AddVisit(ContentVisitor contentVisitor)
        {
            if (contentVisitor == null) throw new ArgumentNullException(nameof(contentVisitor));
            if (_contentVisitors.Contains(contentVisitor)) return;

            _contentVisitors.Add(contentVisitor);
            contentVisitor.Content.AddVisitor(contentVisitor);
        }
    }
}