﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BookingSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(BookingSystemDbContext))]
    [Migration("20250319154152_updateUser")]
    partial class updateUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookingSystem.Domain.Entities.Hotel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<float>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f)
                        .HasColumnName("rating");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "BookingSystem.Domain.Entities.Hotel.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Building")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("address_building");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("character varying(128)")
                                .HasColumnName("address_city");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("character varying(40)")
                                .HasColumnName("address_postal_code");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("character varying(128)")
                                .HasColumnName("address_street");
                        });

                    b.HasKey("Id")
                        .HasName("pk_hotels");

                    b.ToTable("hotels", (string)null);
                });

            modelBuilder.Entity("BookingSystem.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("password_hash");

                    b.ComplexProperty<Dictionary<string, object>>("Phone", "BookingSystem.Domain.Entities.User.Phone#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("character varying(10)")
                                .HasColumnName("phoneNumber");
                        });

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
