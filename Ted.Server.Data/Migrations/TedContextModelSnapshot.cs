﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Ted.Server.Data;

namespace Ted.Server.Data.Migrations
{
    [DbContext(typeof(TedContext))]
    partial class TedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ted.Server.Models.Group", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("createdBy");

                    b.Property<DateTime?>("createdTime");

                    b.Property<bool>("deleted");

                    b.Property<string>("description");

                    b.Property<int?>("modifiedBy");

                    b.Property<DateTime?>("modifiedTime");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Ted.Server.Models.Page", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Pageid");

                    b.Property<int>("WorkspaceId");

                    b.Property<int?>("createdBy");

                    b.Property<DateTime?>("createdTime");

                    b.Property<bool>("deleted");

                    b.Property<string>("iconCls");

                    b.Property<bool>("isPublic");

                    b.Property<string>("json");

                    b.Property<int?>("modifiedBy");

                    b.Property<DateTime?>("modifiedTime");

                    b.Property<string>("text");

                    b.HasKey("id");

                    b.HasIndex("Pageid");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Ted.Server.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("createdBy");

                    b.Property<DateTime?>("createdTime");

                    b.Property<bool>("deleted");

                    b.Property<string>("email");

                    b.Property<string>("fullName");

                    b.Property<bool>("isSuperUser");

                    b.Property<int?>("modifiedBy");

                    b.Property<DateTime?>("modifiedTime");

                    b.Property<string>("password");

                    b.Property<string>("token");

                    b.Property<string>("workspaceList");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ted.Server.Models.UsersInGroups", b =>
                {
                    b.Property<int>("userId");

                    b.Property<int>("groupId");

                    b.HasKey("userId", "groupId");

                    b.HasIndex("groupId");

                    b.ToTable("UsersInGroups");
                });

            modelBuilder.Entity("Ted.Server.Models.Workspace", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<int?>("createdBy");

                    b.Property<DateTime?>("createdTime");

                    b.Property<bool>("deleted");

                    b.Property<string>("description");

                    b.Property<int?>("modifiedBy");

                    b.Property<DateTime?>("modifiedTime");

                    b.Property<string>("name");

                    b.Property<int>("startPageId");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("Workspaces");
                });

            modelBuilder.Entity("Ted.Server.Models.Page", b =>
                {
                    b.HasOne("Ted.Server.Models.Page")
                        .WithMany("pages")
                        .HasForeignKey("Pageid");

                    b.HasOne("Ted.Server.Models.Workspace")
                        .WithMany("pages")
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ted.Server.Models.UsersInGroups", b =>
                {
                    b.HasOne("Ted.Server.Models.Group", "group")
                        .WithMany("usersInGroups")
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ted.Server.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ted.Server.Models.Workspace", b =>
                {
                    b.HasOne("Ted.Server.Models.User")
                        .WithMany("myWorkspaces")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
