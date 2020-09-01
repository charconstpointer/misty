using System.Collections.Generic;
using System.Linq;
using Misty.Domain.Entities.Users;
using Misty.Domain.Enums;

namespace Misty.Domain.Entities.Content
{
    //TODO impl missing functionality
    public abstract class Content
    {
        public int Id { get; }
        public Category Category { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool AdsEnabled { get; private set; }
        private readonly ICollection<Tag> _tags;
        public IEnumerable<Tag> Tags => _tags.ToList();
        private readonly ICollection<Ad> _ads;
        public IEnumerable<Ad> Ads => _ads.ToList();
        private readonly ICollection<Comment> _comments;
        public IEnumerable<Comment> Comments => _comments.ToList();
        public Creator Creator { get; private set; }
        public ContentState State { get; private set; }

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