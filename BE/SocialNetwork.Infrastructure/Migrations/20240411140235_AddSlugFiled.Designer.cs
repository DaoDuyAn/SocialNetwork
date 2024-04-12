﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.Infrastructure.EF;

#nullable disable

namespace SocialNetwork.Infrastructure.Migrations
{
    [DbContext(typeof(SocialNetworkDbContext))]
    [Migration("20240411140235_AddSlugFiled")]
    partial class AddSlugFiled
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SocialNetwork.Domain.Entities.AccountEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7a2346c5-45b6-48f2-9dbd-aae06a701701"),
                            Password = "123123",
                            RoleId = new Guid("a600280d-e519-41d5-998f-82fd428af9f3"),
                            UserId = new Guid("bf33c1a4-8330-4c60-ba0b-2a91f6fb95bb"),
                            UserName = "duyan"
                        },
                        new
                        {
                            Id = new Guid("7a2346c5-45b6-48f2-9dbd-aae06a701702"),
                            Password = "123123",
                            RoleId = new Guid("a02a928b-425c-45dc-9441-82cae13dc44a"),
                            UserId = new Guid("b3d6e9a2-3b26-46a9-8a10-642ab9fd8d91"),
                            UserName = "buihieu"
                        });
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentAllowed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6f906c89-37a4-4dfc-bd4f-2c2b6b3b17af"),
                            CategoryName = "Quan điểm - Tranh luận",
                            ContentAllowed = "Các nội dung thể hiện góc nhìn, quan điểm đa chiều về các vấn đề kinh tế, văn hoá – xã hội trong và ngoài nước.",
                            CoverImagePath = "",
                            Slug = "quan-diem-tranh-luan"
                        },
                        new
                        {
                            Id = new Guid("d3f820ec-7e1d-4c57-bf2c-5212d8c5db65"),
                            CategoryName = "Khoa học - Công nghệ",
                            ContentAllowed = "Những tri thức, hiểu biết có liên quan tới các phát minh, xu hướng, lý thuyết trong tất cả các lĩnh vực khoa học cơ bản, tâm lý học, triết học, công nghệ...",
                            CoverImagePath = "",
                            Slug = "khoa-hoc-cong-nghe"
                        },
                        new
                        {
                            Id = new Guid("a7b7fd22-97f7-4ae0-8f11-7fe83c22d812"),
                            CategoryName = "Thể thao",
                            ContentAllowed = "Tất cả những nội dung và trao đổi liên quan tới thể thao trong nước và quốc tế.",
                            CoverImagePath = "",
                            Slug = "the-thao"
                        },
                        new
                        {
                            Id = new Guid("9d1b2b4a-932d-45e0-bf39-8acbf3f727a6"),
                            CategoryName = "Sách",
                            ContentAllowed = "Tổng hợp tất cả những nội dung liên quan tới sách: review, thảo luận về nội dung sách và văn hoá đọc.",
                            CoverImagePath = "",
                            Slug = "sach"
                        },
                        new
                        {
                            Id = new Guid("0e48f9c1-912f-4268-b82f-05ec8b1c77e9"),
                            CategoryName = "Game",
                            ContentAllowed = "Review, walkthrough và phân tích game dành cho các game thủ thực thụ.",
                            CoverImagePath = "",
                            Slug = "game"
                        });
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.CommentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RepliedCommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("RepliedCommentId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.FollowerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("UserId");

                    b.ToTable("Followers");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.FollowingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FollowingId");

                    b.HasIndex("UserId");

                    b.ToTable("Followings");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.LikeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PostEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CommentsCount")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikesCount")
                        .HasColumnType("int");

                    b.Property<int>("SavedCount")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbnailImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e7d47232-8178-487a-8a39-57dfe86b0ad7"),
                            CategoryId = new Guid("6f906c89-37a4-4dfc-bd4f-2c2b6b3b17af"),
                            CommentsCount = 0,
                            Content = "Hi, tôi là fan hâm mộ của Chelsea Fc được đến nay 11 năm.",
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Này kia",
                            LikesCount = 0,
                            SavedCount = 0,
                            Slug = "hom-qua",
                            ThumbnailImagePath = "",
                            Title = "Hôm qua Eden giải nghệ.",
                            UserId = new Guid("b3d6e9a2-3b26-46a9-8a10-642ab9fd8d91")
                        });
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a600280d-e519-41d5-998f-82fd428af9f3"),
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("a02a928b-425c-45dc-9441-82cae13dc44a"),
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.SavedPostEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("SavedPosts");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.UserCategoryFollowingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCategoryFollowings");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CoverImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToltalFollower")
                        .HasColumnType("int");

                    b.Property<int>("TotalFollowing")
                        .HasColumnType("int");

                    b.Property<int>("TotalPost")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bf33c1a4-8330-4c60-ba0b-2a91f6fb95bb"),
                            Address = "",
                            AvatarImagePath = "",
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CoverImagePath = "",
                            Description = "",
                            Email = "duyan@gmail.com",
                            FullName = "Duy An",
                            Gender = 0,
                            Phone = "",
                            ToltalFollower = 0,
                            TotalFollowing = 0,
                            TotalPost = 0,
                            UserName = "duyan"
                        },
                        new
                        {
                            Id = new Guid("b3d6e9a2-3b26-46a9-8a10-642ab9fd8d91"),
                            Address = "",
                            AvatarImagePath = "",
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CoverImagePath = "",
                            Description = "",
                            Email = "buihieu@gmail.com",
                            FullName = "Bùi Xuân Hiếu",
                            Gender = 0,
                            Phone = "",
                            ToltalFollower = 0,
                            TotalFollowing = 0,
                            TotalPost = 0,
                            UserName = "buihieu"
                        });
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.AccountEntity", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.RoleEntity", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.UserEntity", "User")
                        .WithOne("Account")
                        .HasForeignKey("SocialNetwork.Domain.Entities.AccountEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.CommentEntity", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.PostEntity", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.CommentEntity", "RepliedComment")
                        .WithMany()
                        .HasForeignKey("RepliedCommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("RepliedComment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.FollowerEntity", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.UserEntity", "Follower")
                        .WithMany()
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.FollowingEntity", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.UserEntity", "Following")
                        .WithMany()
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Following");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.LikeEntity", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.PostEntity", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PostEntity", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.CategoryEntity", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.UserEntity", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.SavedPostEntity", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.PostEntity", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.UserCategoryFollowingEntity", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.RoleEntity", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
