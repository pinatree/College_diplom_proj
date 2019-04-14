﻿using System.Data.Entity;

using bzgd_dr.EntityFramework.DataTypes;

namespace bzgd_dr.EntityFramework.Contexts
{
    public class DataModelContext : DbContext
    {
        public DataModelContext() : base("PostgreSql")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // I had removed this
                                                /// Rest of on model creating here.
        }

        public DbSet<User> Users { get; set; }

        public DbSet<SystemRole> SystemRoles { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<AttachmentType> AttachmentTypes { get; set; }

        public DbSet<AttachmentData> AttachmentDatas { get; set; }

        public DbSet<RequestStatus> RequestStatuses { get; set; }

    }
}
