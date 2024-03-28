using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    RelationshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.RelationshipId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Posttime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RelationshipMember",
                columns: table => new
                {
                    RelationshipMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RelationshipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipMember", x => x.RelationshipMemberId);
                    table.ForeignKey(
                        name: "FK_RelationshipMember_Relationship_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationship",
                        principalColumn: "RelationshipId");
                    table.ForeignKey(
                        name: "FK_RelationshipMember_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAccount_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommentPost",
                columns: table => new
                {
                    CommentPostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPost", x => x.CommentPostID);
                    table.ForeignKey(
                        name: "FK_CommentPost_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId");
                    table.ForeignKey(
                        name: "FK_CommentPost_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostDetailAlbum",
                columns: table => new
                {
                    PostDetailAlbumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostDetailAlbum", x => x.PostDetailAlbumID);
                    table.ForeignKey(
                        name: "FK_PostDetailAlbum_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostId");
                });

            migrationBuilder.CreateTable(
                name: "PostDetailSGPicWithCaption",
                columns: table => new
                {
                    PostDetailSGPicWithCaptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostDetailSGPicWithCaption", x => x.PostDetailSGPicWithCaptionID);
                    table.ForeignKey(
                        name: "FK_PostDetailSGPicWithCaption_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostId");
                });

            migrationBuilder.CreateTable(
                name: "PostDetailVideoAndCaption",
                columns: table => new
                {
                    PostDetailVideoAndCaptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostDetailVideoAndCaption", x => x.PostDetailVideoAndCaptionID);
                    table.ForeignKey(
                        name: "FK_PostDetailVideoAndCaption_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostId");
                });

            migrationBuilder.CreateTable(
                name: "PostDetailVote",
                columns: table => new
                {
                    PostDetailVoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashTag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostDetailVote", x => x.PostDetailVoteID);
                    table.ForeignKey(
                        name: "FK_PostDetailVote_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostId");
                });

            migrationBuilder.CreateTable(
                name: "PostDetailWOL",
                columns: table => new
                {
                    PostDetailWOLID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashTag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostDetailWOL", x => x.PostDetailWOLID);
                    table.ForeignKey(
                        name: "FK_PostDetailWOL_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostId");
                });

            migrationBuilder.CreateTable(
                name: "ReactPost",
                columns: table => new
                {
                    ReactPostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactPost", x => x.ReactPostID);
                    table.ForeignKey(
                        name: "FK_ReactPost_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostId");
                    table.ForeignKey(
                        name: "FK_ReactPost_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendMessageTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelationshipMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_RelationshipMember_RelationshipMemberId",
                        column: x => x.RelationshipMemberId,
                        principalTable: "RelationshipMember",
                        principalColumn: "RelationshipMemberId");
                });

            migrationBuilder.CreateTable(
                name: "CommentContentPic",
                columns: table => new
                {
                    CommentContentPicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPostID = table.Column<int>(type: "int", nullable: true),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentContentPic", x => x.CommentContentPicID);
                    table.ForeignKey(
                        name: "FK_CommentContentPic_CommentPost_CommentPostID",
                        column: x => x.CommentPostID,
                        principalTable: "CommentPost",
                        principalColumn: "CommentPostID");
                });

            migrationBuilder.CreateTable(
                name: "CommentContentVideo",
                columns: table => new
                {
                    CommentContentVideoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPostID = table.Column<int>(type: "int", nullable: true),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentContentVideo", x => x.CommentContentVideoID);
                    table.ForeignKey(
                        name: "FK_CommentContentVideo_CommentPost_CommentPostID",
                        column: x => x.CommentPostID,
                        principalTable: "CommentPost",
                        principalColumn: "CommentPostID");
                });

            migrationBuilder.CreateTable(
                name: "CommentContentWOL",
                columns: table => new
                {
                    CommentContentWOLID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPostID = table.Column<int>(type: "int", nullable: true),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentContentWOL", x => x.CommentContentWOLID);
                    table.ForeignKey(
                        name: "FK_CommentContentWOL_CommentPost_CommentPostID",
                        column: x => x.CommentPostID,
                        principalTable: "CommentPost",
                        principalColumn: "CommentPostID");
                });

            migrationBuilder.CreateTable(
                name: "Votesection",
                columns: table => new
                {
                    VotesectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostDetailVoteID = table.Column<int>(type: "int", nullable: true),
                    VoteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votesection", x => x.VotesectionID);
                    table.ForeignKey(
                        name: "FK_Votesection_PostDetailVote_PostDetailVoteID",
                        column: x => x.PostDetailVoteID,
                        principalTable: "PostDetailVote",
                        principalColumn: "PostDetailVoteID");
                    table.ForeignKey(
                        name: "FK_Votesection_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VoteResult",
                columns: table => new
                {
                    VoteResultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostDetailVoteID = table.Column<int>(type: "int", nullable: true),
                    VotesectionID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteResult", x => x.VoteResultID);
                    table.ForeignKey(
                        name: "FK_VoteResult_PostDetailVote_PostDetailVoteID",
                        column: x => x.PostDetailVoteID,
                        principalTable: "PostDetailVote",
                        principalColumn: "PostDetailVoteID");
                    table.ForeignKey(
                        name: "FK_VoteResult_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VoteResult_Votesection_VotesectionID",
                        column: x => x.VotesectionID,
                        principalTable: "Votesection",
                        principalColumn: "VotesectionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentContentPic_CommentPostID",
                table: "CommentContentPic",
                column: "CommentPostID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentContentVideo_CommentPostID",
                table: "CommentContentVideo",
                column: "CommentPostID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentContentWOL_CommentPostID",
                table: "CommentContentWOL",
                column: "CommentPostID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPost_PostId",
                table: "CommentPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPost_UserID",
                table: "CommentPost",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_RelationshipMemberId",
                table: "Message",
                column: "RelationshipMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostDetailAlbum_PostID",
                table: "PostDetailAlbum",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostDetailSGPicWithCaption_PostID",
                table: "PostDetailSGPicWithCaption",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostDetailVideoAndCaption_PostID",
                table: "PostDetailVideoAndCaption",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostDetailVote_PostID",
                table: "PostDetailVote",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostDetailWOL_PostID",
                table: "PostDetailWOL",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_ReactPost_PostID",
                table: "ReactPost",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_ReactPost_UserID",
                table: "ReactPost",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RelationshipMember_RelationshipId",
                table: "RelationshipMember",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationshipMember_UserId",
                table: "RelationshipMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_UserID",
                table: "UserAccount",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_VoteResult_PostDetailVoteID",
                table: "VoteResult",
                column: "PostDetailVoteID");

            migrationBuilder.CreateIndex(
                name: "IX_VoteResult_UserID",
                table: "VoteResult",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_VoteResult_VotesectionID",
                table: "VoteResult",
                column: "VotesectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Votesection_PostDetailVoteID",
                table: "Votesection",
                column: "PostDetailVoteID");

            migrationBuilder.CreateIndex(
                name: "IX_Votesection_UserID",
                table: "Votesection",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentContentPic");

            migrationBuilder.DropTable(
                name: "CommentContentVideo");

            migrationBuilder.DropTable(
                name: "CommentContentWOL");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "PostDetailAlbum");

            migrationBuilder.DropTable(
                name: "PostDetailSGPicWithCaption");

            migrationBuilder.DropTable(
                name: "PostDetailVideoAndCaption");

            migrationBuilder.DropTable(
                name: "PostDetailWOL");

            migrationBuilder.DropTable(
                name: "ReactPost");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "VoteResult");

            migrationBuilder.DropTable(
                name: "CommentPost");

            migrationBuilder.DropTable(
                name: "RelationshipMember");

            migrationBuilder.DropTable(
                name: "Votesection");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropTable(
                name: "PostDetailVote");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
