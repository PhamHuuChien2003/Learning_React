using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<UserAccount>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<User> User { get; set;}
        public DbSet<Relationship> Relationship { get; set;}
        public DbSet<RelationshipMember> RelationshipMember { get; set;}
        public DbSet<Message> Message { get; set;}
        public DbSet<Post> Post { get; set;}
        public DbSet<PostDetailWOL> PostDetailWOL { get; set;}
        public DbSet<PostDetailSGPicWithCaption> PostDetailSGPicWithCaption { get; set;}
        public DbSet<PostDetailVideoAndCaption> PostDetailVideoAndCaption { get; set;}
        public DbSet<PostDetailAlbum> PostDetailAlbum { get; set;}
        public DbSet<PostDetailVote> PostDetailVote { get; set;}
        public DbSet<Votesection> Votesection { get; set;}
        public DbSet<VoteResult> VoteResult { get; set;}
        public DbSet<CommentPost> CommentPost { get; set;}
        public DbSet<CommentContentWOL> CommentContentWOL { get; set;}
        public DbSet<CommentContentPic> CommentContentPic { get; set;}
        public DbSet<CommentContentVideo> CommentContentVideo { get; set;}
        public DbSet<ReactPost> ReactPost { get; set;}
    }
}