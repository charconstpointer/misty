using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Misty.Domain.Entities.Users;
using Misty.Domain.Enums;
using Misty.Domain.ValueObjects;

namespace Misty.Domain.Entities.Content
{
    public abstract class Content
    {
        private readonly ICollection<Ad> _ads = new HashSet<Ad>();
        private readonly ICollection<Comment> _comments = new List<Comment>();
        private readonly ICollection<ContentVisitor> _contentVisitors = new List<ContentVisitor>();
        private readonly ICollection<Tag> _tags = new HashSet<Tag>();

        protected Content()
        {
        }

        protected Content(string title, string description, Creator creator, Category category = null)
        {
            Title = title;
            Description = description;
            Category = category;
            Creator = creator;
            State = ContentState.Created;
            CreatedAt = DateTime.UtcNow;
            AdsEnabled = true;

            creator.AddContent(this);
        }

        public int Id { get; }
        public Category Category { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public bool AdsEnabled { get; protected set; } = true;

        public IEnumerable<Tag> Tags => _tags.ToList();
        public IEnumerable<Ad> Ads => _ads.ToList();
        public IEnumerable<Comment> Comments => _comments.ToList();
        public IEnumerable<ContentVisitor> ContentVisitors => _contentVisitors.ToList();
        public Creator Creator { get; protected set; }
        public ContentState State { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime LastModifiedAt { get; private set; }

        /// <summary>
        ///     Adds and ad to be displayed on an content
        /// </summary>
        /// <param name="ad"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddAd(Ad ad)
        {
            if (ad == null) throw new ArgumentNullException(nameof(ad));
            _ads.Add(ad);
            LastModifiedAt = DateTime.UtcNow;
        }

        /// <summary>
        ///     Calls AddAd in a loop, used to add multiple ads with a single method call
        /// </summary>
        /// <param name="ads"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddAds(IEnumerable<Ad> ads)
        {
            if (ads == null) throw new ArgumentNullException(nameof(ads));
            var adsList = ads.ToList();
            if (adsList == null) throw new ArgumentException("Ads cannot be null");
            if (!adsList.Any()) throw new ArgumentException("Ads cannot be empty");
            foreach (var ad in adsList) AddAd(ad);
        }

        /// <summary>
        ///     Adds tags which can be used to index current content
        /// </summary>
        /// <param name="tags"></param>
        public void AddTags(params string[] tags)
        {
            if (tags == null) throw new ArgumentNullException(nameof(tags));
            foreach (var tag in tags)
            {
                var t = Tag.Create(tag);
                _tags.Add(t);
            }

            LastModifiedAt = DateTime.UtcNow;
        }

        /// <summary>
        ///     Registers a single visit on a content
        /// </summary>
        /// <param name="contentVisitor"></param>
        public void AddVisitor(ContentVisitor contentVisitor)
        {
            if (contentVisitor == null) throw new ArgumentNullException(nameof(contentVisitor));
            if (_contentVisitors.Contains(contentVisitor)) return;

            _contentVisitors.Add(contentVisitor);
            contentVisitor.Visitor.AddVisit(contentVisitor);
        }

        /// <summary>
        ///     Adds comment to content
        /// </summary>
        /// <param name="comment"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddComment(Comment comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));
            if (_comments.Contains(comment)) return;

            _comments.Add(comment);
            comment.SetContent(this);
        }

        /// <summary>
        ///     Returns random ad associated with content
        /// </summary>
        /// <returns></returns>
        public Ad GetRandomAd()
        {
            if (!AdsEnabled) return null;
            if (!_ads.Any()) return null;
            var random = new Random();
            var ad = _ads?.ElementAtOrDefault(random.Next(_ads.Count));
            return ad;
        }

        /// <summary>
        ///     This method allows you to change content state
        ///     Once the content is in deleted state you cannot revert it
        /// </summary>
        /// <param name="state"></param>
        public virtual void ChangeContentState(ContentState state)
        {
            if (!Enum.IsDefined(typeof(ContentState), state))
                throw new InvalidEnumArgumentException(nameof(state), (int) state, typeof(ContentState));
            if (state == ContentState.Created) return;

            if (State == ContentState.Deleted) return;

            State = state;
        }

        /// <summary>
        /// Performs clean up on deletion
        /// </summary>
        public void Delete()
        {
            var toDelete = _comments.ToList();
            foreach (var comment in toDelete)
            {
                _comments.Remove(comment);
                comment.Delete();
            }
        }
    }
}