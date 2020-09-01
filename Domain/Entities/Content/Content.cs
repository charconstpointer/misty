using System.Collections.Generic;
using System.Linq;
using Misty.Domain.Entities.Users;
using Misty.Domain.Enums;

namespace Misty.Domain.Entities.Content
{
    //TODO impl missing functionality
    public abstract class Content
    {
        private readonly ICollection<Ad> _ads;
        private readonly ICollection<Comment> _comments;
        private readonly ICollection<Tag> _tags;

        protected Content()
        {
        }

        protected Content(string title, string description, Category category = null)
        {
            Title = title;
            Description = description;
            Category = category;
            _comments = new List<Comment>();
            _ads = new HashSet<Ad>();
            _tags = new HashSet<Tag>();
            State = ContentState.Created;
            AdsEnabled = true;
        }

        public int Id { get; }
        public Category Category { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public bool AdsEnabled { get; protected set; }
        public IEnumerable<Tag> Tags => _tags.ToList();
        public IEnumerable<Ad> Ads => _ads.ToList();
        public IEnumerable<Comment> Comments => _comments.ToList();
        public Creator Creator { get; private set; }
        public ContentState State { get; protected set; }

        public void AddTags(params string[] tags)
        {
            foreach (var tag in tags)
            {
                var t = new Tag(tag);
                _tags.Add(t);
            }
        }

        public void AddAd(Ad ad)
        {
            _ads.Add(ad);
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
    }
}