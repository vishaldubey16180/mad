using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infosys.PackXprez.DataAccessLayer.Models
{
    public partial class PackXprezDBContext : DbContext
    {
        public PackXprezDBContext()
        {
        }

        public PackXprezDBContext(DbContextOptions<PackXprezDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AvailableDeliveryPickup> AvailableDeliveryPickup { get; set; }
        public virtual DbSet<BranchOfficer> BranchOfficer { get; set; }
        public virtual DbSet<CardDetails> CardDetails { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PickDelRepresentatives> PickDelRepresentatives { get; set; }
        public virtual DbSet<ReceivePackage> ReceivePackage { get; set; }
        public virtual DbSet<SavedCards> SavedCards { get; set; }
        public virtual DbSet<ScheduledPickUp> ScheduledPickUp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source =(localDB)\\MSSQLLocalDB;Initial Catalog=PackXprezDB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvailableDeliveryPickup>(entity =>
            {
                entity.HasKey(e => e.Pincode);

                entity.Property(e => e.Pincode).HasColumnType("numeric(6, 0)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BranchOfficer>(entity =>
            {
                entity.HasKey(e => e.Boid);

                entity.Property(e => e.Boid).HasColumnName("BOId");

                entity.Property(e => e.BoemailId)
                    .HasColumnName("BOEmailId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Boname)
                    .HasColumnName("BOName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardDetails>(entity =>
            {
                entity.HasKey(e => e.CardNumber);

                entity.Property(e => e.CardNumber).HasColumnType("numeric(16, 0)");

                entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Cvvnumber)
                    .HasColumnName("CVVNumber")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.NameOnCard)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustEmailId);

                entity.Property(e => e.CustEmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BuildingNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Locality)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode).HasColumnType("numeric(6, 0)");

                entity.Property(e => e.StreetNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.HasKey(e => new { e.EmailId, e.FeedbackType });

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FeedbackType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.FeedBack)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeedBack__EmailI__6C190EBB");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderNo);

                entity.ToTable("orders");

                entity.Property(e => e.AwbNumber).HasColumnName("AWB Number");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__EmailId__68487DD7");
            });

            modelBuilder.Entity<PickDelRepresentatives>(entity =>
            {
                entity.HasKey(e => e.RepresentativeId);

                entity.ToTable("Pick_Del_Representatives");

                entity.Property(e => e.Awbnumber).HasColumnName("AWBNumber");

                entity.Property(e => e.DeliveryAdd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PickUpAdd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaskAssign)
                    .HasColumnName("Task_Assign")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReceivePackage>(entity =>
            {
                entity.HasKey(e => e.AwbNumber);

                entity.Property(e => e.AwbNumber).HasColumnName("AWB Number");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromLocation)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SavedCards>(entity =>
            {
                entity.HasKey(e => new { e.EmailId, e.CardNumber });

                entity.ToTable("savedCards");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CardNumber).HasColumnType("numeric(16, 0)");

                entity.HasOne(d => d.CardNumberNavigation)
                    .WithMany(p => p.SavedCards)
                    .HasForeignKey(d => d.CardNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__savedCard__CardN__6383C8BA");
            });

            modelBuilder.Entity<ScheduledPickUp>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.AwbNumber).HasColumnName("AWB Number");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasColumnName("Delivery_Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryOpt)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryPinCode)
                    .HasColumnName("delivery_PinCode")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PackageBreadth).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PackageHeight).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PackageLen).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PackageWeight).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Payment)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PickupAddress)
                    .IsRequired()
                    .HasColumnName("Pickup_Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PickupPinCode)
                    .HasColumnName("Pickup_PinCode")
                    .HasColumnType("numeric(6, 0)");

                entity.Property(e => e.ShipmentType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TimeSlot).HasColumnType("datetime");

                entity.HasOne(d => d.AwbNumberNavigation)
                    .WithMany(p => p.ScheduledPickUp)
                    .HasForeignKey(d => d.AwbNumber)
                    .HasConstraintName("FK__Scheduled__AWB N__2EDAF651");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.ScheduledPickUp)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Scheduled__Email__29221CFB");
            });
        }
    }
}
