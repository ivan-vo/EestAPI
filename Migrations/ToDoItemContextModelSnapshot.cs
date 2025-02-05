﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ToDoWebAPI.Migrations
{
    [DbContext(typeof(ToDoItemContext))]
    partial class ToDoItemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Item", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("item_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("done")
                        .HasColumnType("boolean")
                        .HasColumnName("done");

                    b.Property<DateTime?>("dueDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("due_date");

                    b.Property<int>("taskListId")
                        .HasColumnType("integer")
                        .HasColumnName("task_list_id");

                    b.Property<string>("title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("itemId")
                        .HasName("pk_list_items");

                    b.HasIndex("taskListId")
                        .HasDatabaseName("ix_list_items_task_list_id");

                    b.ToTable("list_items");
                });

            modelBuilder.Entity("TaskList", b =>
                {
                    b.Property<int>("taskListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("task_list_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("taskListId")
                        .HasName("pk_task_lists");

                    b.ToTable("task_lists");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.HasOne("TaskList", "TaskList")
                        .WithMany("listItems")
                        .HasForeignKey("taskListId")
                        .HasConstraintName("fk_list_items_task_lists_task_list_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskList");
                });

            modelBuilder.Entity("TaskList", b =>
                {
                    b.Navigation("listItems");
                });
#pragma warning restore 612, 618
        }
    }
}
