using CommentManagement.Domain.CommentAgg;
using CommentManagment.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace CommentManagment.Infrastructure.EFCore
{
    public class CommnetContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public CommnetContext(DbContextOptions<CommnetContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CommentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
