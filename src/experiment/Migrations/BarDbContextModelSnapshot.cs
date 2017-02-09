using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Bar.Models;

namespace experiment.Migrations
{
    [DbContext(typeof(BarDbContext))]
    partial class BarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bar.Models.Beer", b =>
                {
                    b.Property<int>("BeerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<byte[]>("Picture");

                    b.Property<int>("Price");

                    b.Property<string>("Type");

                    b.HasKey("BeerId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("Bar.Models.BeerPatron", b =>
                {
                    b.Property<int>("BeerPatronId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BeerId");

                    b.Property<int>("PatronId");

                    b.HasKey("BeerPatronId");

                    b.HasIndex("BeerId");

                    b.HasIndex("PatronId");

                    b.ToTable("BeerPatron");
                });

            modelBuilder.Entity("Bar.Models.Patron", b =>
                {
                    b.Property<int>("PatronId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Tab");

                    b.HasKey("PatronId");

                    b.ToTable("Patrons");
                });

            modelBuilder.Entity("Bar.Models.BeerPatron", b =>
                {
                    b.HasOne("Bar.Models.Beer", "Beer")
                        .WithMany("BeerPatrons")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bar.Models.Patron", "Patron")
                        .WithMany("BeerPatrons")
                        .HasForeignKey("PatronId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
