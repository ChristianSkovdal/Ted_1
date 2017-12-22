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
    [Migration("20171222093022_initial1")]
    partial class initial1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ted.Server.Models.Group", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("createdBy");

                    b.Property<DateTime>("createdTime");

                    b.Property<bool>("deleted");

                    b.Property<string>("description");

                    b.Property<int>("modifiedBy");

                    b.Property<DateTime>("modifiedTime");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Ted.Server.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("createdBy");

                    b.Property<DateTime>("createdTime");

                    b.Property<bool>("deleted");

                    b.Property<string>("email");

                    b.Property<string>("fullName");

                    b.Property<bool>("isSuperUser");

                    b.Property<int>("modifiedBy");

                    b.Property<DateTime>("modifiedTime");

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

                    b.Property<int?>("Userid");

                    b.Property<string>("componentModifiers");

                    b.Property<string>("componentTree");

                    b.Property<int>("createdBy");

                    b.Property<DateTime>("createdTime");

                    b.Property<bool>("deleted");

                    b.Property<string>("description");

                    b.Property<string>("eventHandlers");

                    b.Property<int>("modifiedBy");

                    b.Property<DateTime>("modifiedTime");

                    b.Property<string>("name");

                    b.Property<string>("securityGroups");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("Workspaces");
                });

            modelBuilder.Entity("Ted.Server.Models.UsersInGroups", b =>
                {
                    b.HasOne("Ted.Server.Models.Group", "group")
                        .WithMany("usersInGroups")
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ted.Server.Models.User", "user")
                        .WithMany("usersInGroups")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ted.Server.Models.Workspace", b =>
                {
                    b.HasOne("Ted.Server.Models.User")
                        .WithMany("myWorkspaces")
                        .HasForeignKey("Userid");
                });
#pragma warning restore 612, 618
        }
    }
}
