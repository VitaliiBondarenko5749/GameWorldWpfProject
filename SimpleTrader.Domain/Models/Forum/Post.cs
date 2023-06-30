using AutoMapper.Configuration.Annotations;
using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;

namespace GameWorldDomain.Models.Forum
{
    public class Post : DomainObject
    {
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}