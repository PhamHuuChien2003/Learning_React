﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.CommentContentPic", b =>
                {
                    b.Property<int>("CommentContentPicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentContentPicID"));

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CommentPostID")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentContentPicID");

                    b.HasIndex("CommentPostID");

                    b.ToTable("CommentContentPic");
                });

            modelBuilder.Entity("api.Models.CommentContentVideo", b =>
                {
                    b.Property<int>("CommentContentVideoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentContentVideoID"));

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CommentPostID")
                        .HasColumnType("int");

                    b.Property<string>("VideoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentContentVideoID");

                    b.HasIndex("CommentPostID");

                    b.ToTable("CommentContentVideo");
                });

            modelBuilder.Entity("api.Models.CommentContentWOL", b =>
                {
                    b.Property<int>("CommentContentWOLID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentContentWOLID"));

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CommentPostID")
                        .HasColumnType("int");

                    b.HasKey("CommentContentWOLID");

                    b.HasIndex("CommentPostID");

                    b.ToTable("CommentContentWOL");
                });

            modelBuilder.Entity("api.Models.CommentPost", b =>
                {
                    b.Property<int>("CommentPostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentPostID"));

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CommentPostID");

                    b.HasIndex("PostId");

                    b.HasIndex("UserID");

                    b.ToTable("CommentPost");
                });

            modelBuilder.Entity("api.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RelationshipMemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SendMessageTime")
                        .HasColumnType("datetime2");

                    b.HasKey("MessageId");

                    b.HasIndex("RelationshipMemberId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("api.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<DateTime>("Posttime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("api.Models.PostDetailAlbum", b =>
                {
                    b.Property<int>("PostDetailAlbumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostDetailAlbumID"));

                    b.Property<string>("AlbumURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.HasKey("PostDetailAlbumID");

                    b.HasIndex("PostID");

                    b.ToTable("PostDetailAlbum");
                });

            modelBuilder.Entity("api.Models.PostDetailSGPicWithCaption", b =>
                {
                    b.Property<int>("PostDetailSGPicWithCaptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostDetailSGPicWithCaptionID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.HasKey("PostDetailSGPicWithCaptionID");

                    b.HasIndex("PostID");

                    b.ToTable("PostDetailSGPicWithCaption");
                });

            modelBuilder.Entity("api.Models.PostDetailVideoAndCaption", b =>
                {
                    b.Property<int>("PostDetailVideoAndCaptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostDetailVideoAndCaptionID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.Property<string>("VideoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostDetailVideoAndCaptionID");

                    b.HasIndex("PostID");

                    b.ToTable("PostDetailVideoAndCaption");
                });

            modelBuilder.Entity("api.Models.PostDetailVote", b =>
                {
                    b.Property<int>("PostDetailVoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostDetailVoteID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.HasKey("PostDetailVoteID");

                    b.HasIndex("PostID");

                    b.ToTable("PostDetailVote");
                });

            modelBuilder.Entity("api.Models.PostDetailWOL", b =>
                {
                    b.Property<int>("PostDetailWOLID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostDetailWOLID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.HasKey("PostDetailWOLID");

                    b.HasIndex("PostID");

                    b.ToTable("PostDetailWOL");
                });

            modelBuilder.Entity("api.Models.ReactPost", b =>
                {
                    b.Property<int>("ReactPostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReactPostID"));

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ReactPostID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("ReactPost");
                });

            modelBuilder.Entity("api.Models.Relationship", b =>
                {
                    b.Property<int>("RelationshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RelationshipId"));

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RelationshipId");

                    b.ToTable("Relationship");
                });

            modelBuilder.Entity("api.Models.RelationshipMember", b =>
                {
                    b.Property<int>("RelationshipMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RelationshipMemberId"));

                    b.Property<int?>("RelationshipId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RelationshipMemberId");

                    b.HasIndex("RelationshipId");

                    b.HasIndex("UserId");

                    b.ToTable("RelationshipMember");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("api.Models.UserAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserAccount");
                });

            modelBuilder.Entity("api.Models.VoteResult", b =>
                {
                    b.Property<int>("VoteResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoteResultID"));

                    b.Property<int?>("PostDetailVoteID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("VotesectionID")
                        .HasColumnType("int");

                    b.HasKey("VoteResultID");

                    b.HasIndex("PostDetailVoteID");

                    b.HasIndex("UserID");

                    b.HasIndex("VotesectionID");

                    b.ToTable("VoteResult");
                });

            modelBuilder.Entity("api.Models.Votesection", b =>
                {
                    b.Property<int>("VotesectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VotesectionID"));

                    b.Property<int?>("PostDetailVoteID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("VoteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VotesectionID");

                    b.HasIndex("PostDetailVoteID");

                    b.HasIndex("UserID");

                    b.ToTable("Votesection");
                });

            modelBuilder.Entity("api.Models.CommentContentPic", b =>
                {
                    b.HasOne("api.Models.CommentPost", "CommentPost")
                        .WithMany()
                        .HasForeignKey("CommentPostID");

                    b.Navigation("CommentPost");
                });

            modelBuilder.Entity("api.Models.CommentContentVideo", b =>
                {
                    b.HasOne("api.Models.CommentPost", "CommentPost")
                        .WithMany()
                        .HasForeignKey("CommentPostID");

                    b.Navigation("CommentPost");
                });

            modelBuilder.Entity("api.Models.CommentContentWOL", b =>
                {
                    b.HasOne("api.Models.CommentPost", "CommentPost")
                        .WithMany()
                        .HasForeignKey("CommentPostID");

                    b.Navigation("CommentPost");
                });

            modelBuilder.Entity("api.Models.CommentPost", b =>
                {
                    b.HasOne("api.Models.Post", "Post")
                        .WithMany("CommentPosts")
                        .HasForeignKey("PostId");

                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Message", b =>
                {
                    b.HasOne("api.Models.RelationshipMember", "RelationshipMember")
                        .WithMany("Messages")
                        .HasForeignKey("RelationshipMemberId");

                    b.Navigation("RelationshipMember");
                });

            modelBuilder.Entity("api.Models.Post", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.PostDetailAlbum", b =>
                {
                    b.HasOne("api.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("api.Models.PostDetailSGPicWithCaption", b =>
                {
                    b.HasOne("api.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("api.Models.PostDetailVideoAndCaption", b =>
                {
                    b.HasOne("api.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("api.Models.PostDetailVote", b =>
                {
                    b.HasOne("api.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("api.Models.PostDetailWOL", b =>
                {
                    b.HasOne("api.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("api.Models.ReactPost", b =>
                {
                    b.HasOne("api.Models.Post", "Post")
                        .WithMany("ReactPosts")
                        .HasForeignKey("PostID");

                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.RelationshipMember", b =>
                {
                    b.HasOne("api.Models.Relationship", "Relationship")
                        .WithMany("RelationshipMembers")
                        .HasForeignKey("RelationshipId");

                    b.HasOne("api.Models.User", "User")
                        .WithMany("RelationshipMembers")
                        .HasForeignKey("UserId");

                    b.Navigation("Relationship");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.UserAccount", b =>
                {
                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.VoteResult", b =>
                {
                    b.HasOne("api.Models.PostDetailVote", "PostDetailVote")
                        .WithMany()
                        .HasForeignKey("PostDetailVoteID");

                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.HasOne("api.Models.Votesection", "Votesection")
                        .WithMany()
                        .HasForeignKey("VotesectionID");

                    b.Navigation("PostDetailVote");

                    b.Navigation("User");

                    b.Navigation("Votesection");
                });

            modelBuilder.Entity("api.Models.Votesection", b =>
                {
                    b.HasOne("api.Models.PostDetailVote", "PostDetailVote")
                        .WithMany("Votesections")
                        .HasForeignKey("PostDetailVoteID");

                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("PostDetailVote");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Post", b =>
                {
                    b.Navigation("CommentPosts");

                    b.Navigation("ReactPosts");
                });

            modelBuilder.Entity("api.Models.PostDetailVote", b =>
                {
                    b.Navigation("Votesections");
                });

            modelBuilder.Entity("api.Models.Relationship", b =>
                {
                    b.Navigation("RelationshipMembers");
                });

            modelBuilder.Entity("api.Models.RelationshipMember", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("RelationshipMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
