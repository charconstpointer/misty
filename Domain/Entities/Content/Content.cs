using System;
using System.Collections.Generic;
using System.Linq;
using Misty.Domain.Entities.Users;
using Misty.Domain.Enums;

namespace Misty.Domain.Entities.Content
{
    //TODO impl missing functionality
    public abstract class Content
    {
        protected Content()
        {
        }

        protected Content(string title, string description, Creator creator, Category category = null)
        {
            Title = title;
            Description = description;
            Category = category;
            _comments = new List<Comment>();
            _ads = new HashSet<Ad>();
            _tags = new HashSet<Tag>();
            Creator = creator;
            State = ContentState.Created;
            AdsEnabled = true;

            creator.AddContent(this);
        }

        public int Id { get; }
        public Category Category { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }

        public bool AdsEnabled { get; protected set; }

        private readonly ICollection<Ad> _ads = new HashSet<Ad>();
        private readonly ICollection<Comment> _comments = new List<Comment>();

        private readonly ICollection<Tag> _tags = new HashSet<Tag>();
        private readonly ICollection<ContentVisitor> _contentVisitors = new List<ContentVisitor>();

        //TODO fix tags
        public IEnumerable<Tag> Tags => Enumerable.Empty<Tag>();
        public IEnumerable<Ad> Ads => _ads.ToList();
        public IEnumerable<Comment> Comments => _comments.ToList();
        public IEnumerable<ContentVisitor> ContentVisitors => _contentVisitors.ToList();
        public Creator Creator { get; private set; }
        public ContentState State { get; protected set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastModifiedAt { get; private set; }

        public void AddTags(params string[] tags)
        {
            foreach (var tag in tags)
            {
                var t = new Tag(tag);
                _tags.Add(t);
            }
        }

        public void AddVisitor(ContentVisitor contentVisitor)
        {
            if (_contentVisitors.Contains(contentVisitor))
            {
                return;
            }
            _contentVisitors.Add(contentVisitor);
            contentVisitor.Visitor.AddVisitor(contentVisitor);
        }

        public Ad GetRandomAd()
        {
            if (!AdsEnabled) return null;
            if (!_ads.Any()) return null;
            var random = new Random();
            var ad = _ads?.ElementAtOrDefault(random.Next(_ads.Count));
            return ad;
        }

        public void AddAd(Ad ad)
        {
            _ads.Add(ad);
        }

        public void AddAds(IEnumerable<Ad> ads)
        {
            var adsList = ads.ToList();
            if (adsList == null)
            {
                throw new ArgumentException("Ads cannot be null");
            }

            if (!adsList.Any())
            {
                throw new ArgumentException("Ads cannot be empty");
            }

            foreach (var ad in ads)
            {
                AddAd(ad);
            }
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
    }
}