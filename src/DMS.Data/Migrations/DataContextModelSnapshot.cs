using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DMS.Data;

namespace DMS.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("DMS.Core.Entities.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("HappendDate");

                    b.Property<int>("HostId");

                    b.Property<int>("UserId");

                    b.HasKey("ActivityId");
                });

            modelBuilder.Entity("DMS.Core.Entities.Container", b =>
                {
                    b.Property<string>("ContainerId");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ContainerName");

                    b.Property<int>("HostId");

                    b.Property<string>("JSONDetail");

                    b.Property<bool>("Status");

                    b.Property<int>("UserId");

                    b.HasKey("ContainerId");
                });

            modelBuilder.Entity("DMS.Core.Entities.ContainerImage", b =>
                {
                    b.Property<string>("ContainerImageId");

                    b.Property<DateTime>("GetTime");

                    b.Property<int>("HostId");

                    b.Property<string>("JSONDetail");

                    b.Property<int>("UserId");

                    b.HasKey("ContainerImageId");
                });

            modelBuilder.Entity("DMS.Core.Entities.Host", b =>
                {
                    b.Property<int>("HostId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("HostName");

                    b.Property<string>("IP");

                    b.Property<bool>("IsActive");

                    b.Property<string>("OsType");

                    b.Property<string>("ServerVersion");

                    b.Property<int>("UserId");

                    b.HasKey("HostId");
                });

            modelBuilder.Entity("DMS.Core.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("RoleId");
                });

            modelBuilder.Entity("DMS.Core.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EMail");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId");
                });

            modelBuilder.Entity("DMS.Core.Entities.Activity", b =>
                {
                    b.HasOne("DMS.Core.Entities.Host")
                        .WithMany()
                        .HasForeignKey("HostId");

                    b.HasOne("DMS.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DMS.Core.Entities.Container", b =>
                {
                    b.HasOne("DMS.Core.Entities.Host")
                        .WithMany()
                        .HasForeignKey("HostId");

                    b.HasOne("DMS.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DMS.Core.Entities.ContainerImage", b =>
                {
                    b.HasOne("DMS.Core.Entities.Host")
                        .WithMany()
                        .HasForeignKey("HostId");

                    b.HasOne("DMS.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DMS.Core.Entities.Host", b =>
                {
                    b.HasOne("DMS.Core.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DMS.Core.Entities.User", b =>
                {
                    b.HasOne("DMS.Core.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
        }
    }
}
