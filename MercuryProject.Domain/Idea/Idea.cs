﻿using MercuryProject.Domain.Common.Models;
using MercuryProject.Domain.Product.ValueObjects;
using MercuryProject.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.Idea.ValueObjects;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using MercuryProject.Domain.Enums;

namespace MercuryProject.Domain.Idea
{
    public sealed class Idea : AggregateRoot<IdeaId>
    {
        private readonly List<string> _ideaImageUrls = new();
        public User.User User { get; set; }
        public UserId OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IdeaStatus Status { get; set; }
        public double Goal { get; set; }
        public double Collected {get; set; }
        public string Category { get; set; }
        public IReadOnlyList<string> IdeaImageUrls => _ideaImageUrls.AsReadOnly();
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public Idea(IdeaId ideaId, UserId ownerId, string title, string description, double goal, string category, List<string> ideaImageUrls, DateTime createdDateTime, DateTime updatedDateTime, double collected = 0, IdeaStatus ideaStatus = IdeaStatus.Review) : base(ideaId)
        {
            OwnerId = ownerId;
            Title = title;
            Description = description;
            Goal = goal;
            Category = category;
            _ideaImageUrls = ideaImageUrls;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            Collected = collected;
            Status = ideaStatus;
        }

        public static Idea Create
            (UserId ownerId, string title, string description, double goal, string category, List<string> ideaImageUrls)
        {
            return new(IdeaId.CreateUnique(), ownerId, title, description, goal, category, ideaImageUrls, DateTime.UtcNow,
                DateTime.UtcNow);
        }

        public Idea()
        {
        }
    }
}