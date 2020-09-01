﻿using System.Collections.Generic;
using MediatR;
using Misty.Domain.Entities.Content;

namespace Misty.Queries
{
    public class GetArticleComments : IRequest<IEnumerable<Comment>>
    {
        public int ArticleId { get; set; }
    }
}