﻿// <auto-generated />
using System;
using EduHome.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EduHome.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220302120242_AddColumn-Description-toTable-Testimional")]
    partial class AddColumnDescriptiontoTableTestimional
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EduHome.Models.DbTables.About", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Blog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BlogImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Writer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("id");

                    b.HasIndex("BlogId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Compaign", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountPercent")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CourseId");

                    b.ToTable("Compaigns");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("PinterestUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkypeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("TwitterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Certification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.CourseFeature", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Assesment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassDuration")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("SkilLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentCount")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseFeatures");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Event", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Month")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("İmage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.EventSpeaker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Eventid")
                        .HasColumnType("int");

                    b.Property<int>("Speakerid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Eventid");

                    b.HasIndex("Speakerid");

                    b.ToTable("EventSpeakers");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Faculty", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Hobby", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Notice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.NoticeSecond", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("NoticeSeconds");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Skill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Communication")
                        .HasColumnType("int");

                    b.Property<int>("Design")
                        .HasColumnType("int");

                    b.Property<int>("Development")
                        .HasColumnType("int");

                    b.Property<int>("Innovation")
                        .HasColumnType("int");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<int>("Leader")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Slider", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.SliderImage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LineOrdeer")
                        .HasColumnType("int");

                    b.Property<int>("SliderId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("SliderId");

                    b.ToTable("SliderImages");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Speaker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsibility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("İmage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Teacher", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.TeacherFaculty", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherFaculties");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.TeacherHobby", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("HobbyId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("HobbyId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherHobbies");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Testimional", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsibility")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Testimionals");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Comment", b =>
                {
                    b.HasOne("EduHome.Models.DbTables.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Compaign", b =>
                {
                    b.HasOne("EduHome.Models.DbTables.Course", "Course")
                        .WithMany("Compaigns")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Contact", b =>
                {
                    b.HasOne("EduHome.Models.DbTables.Teacher", "Teacher")
                        .WithMany("Contacts")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Course", b =>
                {
                    b.HasOne("EduHome.Models.DbTables.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.CourseFeature", b =>
                {
                    b.HasOne("EduHome.Models.DbTables.Course", "Course")
                        .WithMany("CourseFeatures")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.EventSpeaker", b =>
                {
                    b.HasOne("EduHome.Models.DbTables.Event", "Event")
                        .WithMany("EventSpeakers")
                        .HasForeignKey("Eventid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduHome.Models.DbTables.Speaker", "Speaker")
                        .WithMany("EventSpeakers")
                        .HasForeignKey("Speakerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Skill", b =>
                {
                    b.HasOne("EduHome.Models.DbTables.Teacher", "Teacher")
                        .WithMany("Skills")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.SliderImage", b =>
                {
                    b.HasOne("EduHome.Models.DbTables.Slider", "Slider")
                        .WithMany("SliderImages")
                        .HasForeignKey("SliderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slider");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.TeacherFaculty", b =>
                {
                    b.HasOne("EduHome.Models.DbTables.Faculty", "Faculty")
                        .WithMany("TeacherFaculties")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduHome.Models.DbTables.Teacher", "Teacher")
                        .WithMany("TeacherFaculties")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.TeacherHobby", b =>
                {
                    b.HasOne("EduHome.Models.DbTables.Hobby", "Hobby")
                        .WithMany("TeacherHobbies")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EduHome.Models.DbTables.Teacher", "Teacher")
                        .WithMany("TeacherHobbies")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hobby");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Blog", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Course", b =>
                {
                    b.Navigation("Compaigns");

                    b.Navigation("CourseFeatures");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Event", b =>
                {
                    b.Navigation("EventSpeakers");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Faculty", b =>
                {
                    b.Navigation("TeacherFaculties");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Hobby", b =>
                {
                    b.Navigation("TeacherHobbies");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Slider", b =>
                {
                    b.Navigation("SliderImages");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Speaker", b =>
                {
                    b.Navigation("EventSpeakers");
                });

            modelBuilder.Entity("EduHome.Models.DbTables.Teacher", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Skills");

                    b.Navigation("TeacherFaculties");

                    b.Navigation("TeacherHobbies");
                });
#pragma warning restore 612, 618
        }
    }
}
