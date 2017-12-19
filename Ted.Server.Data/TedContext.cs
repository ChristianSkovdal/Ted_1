﻿using Microsoft.EntityFrameworkCore;
using System;
using Ted.Server.Models;

namespace Ted.Server.Data
{
    public class TedContext : DbContext
    {

        public TedContext(DbContextOptions<TedContext> options)
            : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Workspace> Workspaces { get; set; }

    }
}