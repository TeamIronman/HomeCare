﻿// <auto-generated />
using System;
using HomeCare.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeCare.Data.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190313100051_Initial_3")]
    partial class Initial_3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeCare.Data.Entities.AppAdmin", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Avatar");

                    b.Property<DateTime?>("BirthDay");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AppAdmins");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.AppAdminModRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminModId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("AdminModId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppAdminModRoles");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.AppCustomer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Avatar");

                    b.Property<DateTime?>("BirthDay");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<Guid>("RoleId");

                    b.Property<int>("Status");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AppCustomers");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.AppHelper", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime?>("BirthDay")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("IDcard")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Paymoney");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<Guid>("RoleId");

                    b.Property<int>("Status");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AppHelpers");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Acreage");

                    b.Property<string>("Apartmentnumber")
                        .IsRequired();

                    b.Property<int>("BillStatus");

                    b.Property<string>("CustomerAddress")
                        .IsRequired();

                    b.Property<string>("CustomerEmail")
                        .IsRequired();

                    b.Property<string>("CustomerId");

                    b.Property<string>("CustomerMobile")
                        .IsRequired();

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("HelperId");

                    b.Property<int>("Rooms");

                    b.Property<int>("SortOrder");

                    b.Property<string>("Starttime")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("Workday")
                        .IsRequired();

                    b.Property<string>("Workinghours")
                        .IsRequired();

                    b.Property<string>("Workplace")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("HelperId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.Function", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IconCss");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ParentId")
                        .HasMaxLength(128);

                    b.Property<int>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<string>("URL")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.HelperCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillId");

                    b.Property<bool>("Firstcheck");

                    b.Property<bool>("Secondcheck");

                    b.Property<bool>("Thirdcheck");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("HelperChecks");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.HelperImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasMaxLength(250);

                    b.Property<string>("HelperId");

                    b.Property<string>("Path")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("HelperId");

                    b.ToTable("HelperImages");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanCreate");

                    b.Property<bool>("CanDelete");

                    b.Property<bool>("CanRead");

                    b.Property<bool>("CanUpdate");

                    b.Property<string>("FunctionId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("RoleId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("HelperId");

                    b.Property<int>("Starcount");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("HelperId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.AppAdminModRole", b =>
                {
                    b.HasOne("HomeCare.Data.Entities.AppAdmin", "AppAdmin")
                        .WithMany("AppAdminModRoles")
                        .HasForeignKey("AdminModId");

                    b.HasOne("HomeCare.Data.Entities.AppRole", "AppRole")
                        .WithMany("AppAdminModRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeCare.Data.Entities.AppCustomer", b =>
                {
                    b.HasOne("HomeCare.Data.Entities.AppRole", "AppRole")
                        .WithMany("AppCustomers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeCare.Data.Entities.AppHelper", b =>
                {
                    b.HasOne("HomeCare.Data.Entities.AppRole", "AppRole")
                        .WithMany("AppHelpers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeCare.Data.Entities.Bill", b =>
                {
                    b.HasOne("HomeCare.Data.Entities.AppCustomer", "AppCustomer")
                        .WithMany("Bills")
                        .HasForeignKey("CustomerId");

                    b.HasOne("HomeCare.Data.Entities.AppHelper", "AppHelper")
                        .WithMany("Bills")
                        .HasForeignKey("HelperId");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.HelperCheck", b =>
                {
                    b.HasOne("HomeCare.Data.Entities.Bill", "Bill")
                        .WithMany("HelperChecks")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeCare.Data.Entities.HelperImage", b =>
                {
                    b.HasOne("HomeCare.Data.Entities.AppHelper", "AppHelper")
                        .WithMany("HelperImages")
                        .HasForeignKey("HelperId");
                });

            modelBuilder.Entity("HomeCare.Data.Entities.Permission", b =>
                {
                    b.HasOne("HomeCare.Data.Entities.Function", "Function")
                        .WithMany("Permissions")
                        .HasForeignKey("FunctionId");

                    b.HasOne("HomeCare.Data.Entities.AppRole", "AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeCare.Data.Entities.Review", b =>
                {
                    b.HasOne("HomeCare.Data.Entities.AppCustomer", "AppCustomer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId");

                    b.HasOne("HomeCare.Data.Entities.AppHelper", "AppHelper")
                        .WithMany("Reviews")
                        .HasForeignKey("HelperId");
                });
#pragma warning restore 612, 618
        }
    }
}
