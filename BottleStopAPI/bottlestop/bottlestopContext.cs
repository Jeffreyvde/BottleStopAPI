using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BottleStopAPI.BottleStop
{
    public partial class BottleStopContext : DbContext
    {
        public BottleStopContext()
        {
        }

        public BottleStopContext(DbContextOptions<BottleStopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BalanceTransaction> BalanceTransaction { get; set; }
        public virtual DbSet<Beverage> Beverage { get; set; }
        public virtual DbSet<BeveragePrice> BeveragePrice { get; set; }
        public virtual DbSet<BeverageType> BeverageType { get; set; }
        public virtual DbSet<Bottle> Bottle { get; set; }
        public virtual DbSet<BottleModel> BottleModel { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<GpsCoordinates> GpsCoordinates { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MachineAvailability> MachineAvailability { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Pin> Pin { get; set; }
        public virtual DbSet<PinMode> PinMode { get; set; }
        public virtual DbSet<Pump> Pump { get; set; }
        public virtual DbSet<PumpPin> PumpPin { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserBottle> UserBottle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=bottle-stop-database.mysql.database.azure.com;port=3306;user=BottleStopAdmin@bottle-stop-database;password=Rx4NK8x*nQc*;database=BottleStop", x => x.ServerVersion("8.0.15-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => e.AddressId)
                    .HasName("address_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CountryId)
                    .HasName("address_country_id_idx");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Additional)
                    .HasColumnName("additional")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HouseNumber)
                    .HasColumnName("house_number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postal_code")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("address_country_id");
            });

            modelBuilder.Entity<BalanceTransaction>(entity =>
            {
                entity.ToTable("balance_transaction");

                entity.HasIndex(e => e.BalanceTransactionId)
                    .HasName("balance_transaction_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("balance_transaction_user_id_idx");

                entity.Property(e => e.BalanceTransactionId)
                    .HasColumnName("balance_transaction_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Change)
                    .HasColumnName("change")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BalanceTransaction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("balance_transaction_user_id");
            });

            modelBuilder.Entity<Beverage>(entity =>
            {
                entity.ToTable("beverage");

                entity.HasIndex(e => e.BeverageId)
                    .HasName("beverage_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.BeverageTypeId)
                    .HasName("beverage_beverage_type_id_idx");

                entity.HasIndex(e => e.BrandId)
                    .HasName("beverage_brand_id_idx");

                entity.Property(e => e.BeverageId)
                    .HasColumnName("beverage_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BeverageImage)
                    .HasColumnName("beverage_image")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BeverageName)
                    .IsRequired()
                    .HasColumnName("beverage_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BeverageTypeId)
                    .HasColumnName("beverage_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.BeverageType)
                    .WithMany(p => p.Beverage)
                    .HasForeignKey(d => d.BeverageTypeId)
                    .HasConstraintName("beverage_beverage_type_id");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Beverage)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("beverage_brand_id");
            });

            modelBuilder.Entity<BeveragePrice>(entity =>
            {
                entity.ToTable("beverage_price");

                entity.HasIndex(e => e.BeverageId)
                    .HasName("beverage_price_beverage_id_idx");

                entity.HasIndex(e => e.BeveragePriceId)
                    .HasName("beverage_price_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MachineId)
                    .HasName("beverage_price_machine_id_idx");

                entity.Property(e => e.BeveragePriceId)
                    .HasColumnName("beverage_price_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BeverageId)
                    .HasColumnName("beverage_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CostPerMl).HasColumnName("cost_per_ml");

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasColumnName("machine_id")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Beverage)
                    .WithMany(p => p.BeveragePrice)
                    .HasForeignKey(d => d.BeverageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("beverage_price_beverage_id");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.BeveragePrice)
                    .HasForeignKey(d => d.MachineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("beverage_price_machine_id");
            });

            modelBuilder.Entity<BeverageType>(entity =>
            {
                entity.ToTable("beverage_type");

                entity.Property(e => e.BeverageTypeId)
                    .HasColumnName("beverage_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BeverageType1)
                    .IsRequired()
                    .HasColumnName("beverage_type")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeImage)
                    .HasColumnName("type_image")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Bottle>(entity =>
            {
                entity.ToTable("bottle");

                entity.HasIndex(e => e.BottleId)
                    .HasName("bottle_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.SerialCode)
                    .HasName("serial_code_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.BottleId)
                    .HasColumnName("bottle_id")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SerialCode)
                    .IsRequired()
                    .HasColumnName("serial_code")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<BottleModel>(entity =>
            {
                entity.ToTable("bottle_model");

                entity.HasIndex(e => e.BeverageId)
                    .HasName("bottle_model_beverage_id_idx");

                entity.HasIndex(e => e.BottleId)
                    .HasName("bottle_model_bottle_id_idx");

                entity.HasIndex(e => e.BottleModelId)
                    .HasName("bottle_model_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CetegoryId)
                    .HasName("bottle_model_category_id_idx");

                entity.Property(e => e.BottleModelId)
                    .HasColumnName("bottle_model_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BeverageId)
                    .HasColumnName("beverage_id")
                    .HasColumnType("int(11)")
                    .HasComment("for auto fill option");

                entity.Property(e => e.BottleId)
                    .IsRequired()
                    .HasColumnName("bottle_id")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BottleSizeMl)
                    .HasColumnName("bottle_size_ml")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CetegoryId)
                    .HasColumnName("cetegory_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Beverage)
                    .WithMany(p => p.BottleModel)
                    .HasForeignKey(d => d.BeverageId)
                    .HasConstraintName("bottle_model_beverage_id");

                entity.HasOne(d => d.Bottle)
                    .WithMany(p => p.BottleModel)
                    .HasForeignKey(d => d.BottleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bottle_model_bottle_id");

                entity.HasOne(d => d.Cetegory)
                    .WithMany(p => p.BottleModel)
                    .HasForeignKey(d => d.CetegoryId)
                    .HasConstraintName("bottle_model_category_id");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.HasIndex(e => e.BrandId)
                    .HasName("brand_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("brand_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("category_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryDescription)
                    .HasColumnName("category_description")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.HasIndex(e => e.CountryId)
                    .HasName("country_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.RegionId)
                    .HasName("country_region_id_idx");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("country_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RegionId)
                    .HasColumnName("region_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("country_region_id");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("favorite");

                entity.HasIndex(e => e.BeverageId)
                    .HasName("favorite_beverage_id_idx");

                entity.HasIndex(e => e.FavoriteId)
                    .HasName("favorite_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("favorite_user_id_idx");

                entity.Property(e => e.FavoriteId)
                    .HasColumnName("favorite_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BeverageId)
                    .HasColumnName("beverage_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Beverage)
                    .WithMany(p => p.Favorite)
                    .HasForeignKey(d => d.BeverageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("favorite_beverage_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favorite)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("favorite_user_id");
            });

            modelBuilder.Entity<GpsCoordinates>(entity =>
            {
                entity.ToTable("gps_coordinates");

                entity.HasIndex(e => e.GpsCoordinatesId)
                    .HasName("gps_coordinates_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.GpsCoordinatesId)
                    .HasColumnName("gps_coordinates_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("ingredient");

                entity.HasIndex(e => e.IngredientId)
                    .HasName("beverage_recipe_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IngredientId)
                    .HasColumnName("ingredient_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MixName)
                    .IsRequired()
                    .HasColumnName("mix_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.ToTable("machine");

                entity.HasIndex(e => e.GpsCoordiantesId)
                    .HasName("machine_gps_coordiantes_id_idx");

                entity.HasIndex(e => e.MachineId)
                    .HasName("machine_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.MachineId)
                    .HasColumnName("machine_id")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FilledAmount)
                    .HasColumnName("filled_amount")
                    .HasColumnType("int(11)")
                    .HasComment("In milliliters");

                entity.Property(e => e.GpsCoordiantesId)
                    .HasColumnName("gps_coordiantes_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasColumnName("model_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.GpsCoordiantes)
                    .WithMany(p => p.Machine)
                    .HasForeignKey(d => d.GpsCoordiantesId)
                    .HasConstraintName("machine_gps_coordiantes_id");
            });

            modelBuilder.Entity<MachineAvailability>(entity =>
            {
                entity.ToTable("machine_availability");

                entity.HasIndex(e => e.BeverageId)
                    .HasName("available_beverage_beverage_id_idx");

                entity.HasIndex(e => e.MachineAvailabilityId)
                    .HasName("available_beverage_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MachineId)
                    .HasName("available_beverage_machine_id_idx");

                entity.HasIndex(e => e.PumpId)
                    .HasName("machine_availability_pump_id_idx");

                entity.Property(e => e.MachineAvailabilityId)
                    .HasColumnName("machine_availability_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BeverageId)
                    .HasColumnName("beverage_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContainerSize)
                    .HasColumnName("container_size")
                    .HasColumnType("int(11)")
                    .HasComment("Milliliters");

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasColumnName("machine_id")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PumpId)
                    .HasColumnName("pump_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Beverage)
                    .WithMany(p => p.MachineAvailability)
                    .HasForeignKey(d => d.BeverageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("machine_availability_beverage_id");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.MachineAvailability)
                    .HasForeignKey(d => d.MachineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("machine_availability_machine_id");

                entity.HasOne(d => d.Pump)
                    .WithMany(p => p.MachineAvailability)
                    .HasForeignKey(d => d.PumpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("machine_availability_pump_id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.OrderId)
                    .HasName("order_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("order_user_id_idx");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderDate).HasColumnName("order_date");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_user_id");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_detail");

                entity.HasIndex(e => e.BeverageId)
                    .HasName("order_detail_beverage_id_idx");

                entity.HasIndex(e => e.OrderDetailId)
                    .HasName("order_detail_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.OrderId)
                    .HasName("order_detail_order_id_idx");

                entity.Property(e => e.OrderDetailId)
                    .HasColumnName("order_detail_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BeverageId)
                    .HasColumnName("beverage_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Beverage)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.BeverageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_detail_beverage_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_detail_order_id");
            });

            modelBuilder.Entity<Pin>(entity =>
            {
                entity.ToTable("pin");

                entity.HasIndex(e => e.PinId)
                    .HasName("pin_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PinModeId)
                    .HasName("pin_pin_mode_id_idx");

                entity.Property(e => e.PinId)
                    .HasColumnName("pin_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PinModeId)
                    .HasColumnName("pin_mode_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PinName)
                    .HasColumnName("pin_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PinNumber)
                    .HasColumnName("pin_number")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.PinMode)
                    .WithMany(p => p.Pin)
                    .HasForeignKey(d => d.PinModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pin_pin_mode_id");
            });

            modelBuilder.Entity<PinMode>(entity =>
            {
                entity.ToTable("pin_mode");

                entity.HasIndex(e => e.PinModeId)
                    .HasName("pin_mode_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PinModeId)
                    .HasColumnName("pin_mode_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PinMode1)
                    .IsRequired()
                    .HasColumnName("pin_mode")
                    .HasColumnType("varchar(45)")
                    .HasComment("INPUT, OUTPUT, or INPUT_PULLUP...")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Pump>(entity =>
            {
                entity.ToTable("pump");

                entity.HasIndex(e => e.IngredientId)
                    .HasName("pump_ingredient_id_idx");

                entity.HasIndex(e => e.PumpId)
                    .HasName("pump_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PumpId)
                    .HasColumnName("pump_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IngredientId)
                    .HasColumnName("ingredient_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PumpName)
                    .HasColumnName("pump_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PumpType)
                    .HasColumnName("pump_type")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.Pump)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pump_ingredient_id");
            });

            modelBuilder.Entity<PumpPin>(entity =>
            {
                entity.ToTable("pump_pin");

                entity.HasIndex(e => e.PinId)
                    .HasName("pump_pin_pin_id_idx");

                entity.HasIndex(e => e.PumpId)
                    .HasName("pump_pin_pump_id_idx");

                entity.HasIndex(e => e.PumpPinId)
                    .HasName("pump_pin_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PumpPinId)
                    .HasColumnName("pump_pin_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PinId)
                    .HasColumnName("pin_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PumpId)
                    .HasColumnName("pump_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Pin)
                    .WithMany(p => p.PumpPin)
                    .HasForeignKey(d => d.PinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pump_pin_pin_id");

                entity.HasOne(d => d.Pump)
                    .WithMany(p => p.PumpPin)
                    .HasForeignKey(d => d.PumpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pump_pin_pump_id");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipe");

                entity.HasIndex(e => e.BeverageId)
                    .HasName("mix_combination_beverage_id_idx");

                entity.HasIndex(e => e.IngredientId)
                    .HasName("mix_combination_beverage_recipe_id_idx");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("mix_combination_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.RecipeId)
                    .HasColumnName("recipe_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BeverageId)
                    .HasColumnName("beverage_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IngredientId)
                    .HasColumnName("ingredient_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ratio).HasColumnName("ratio");

                entity.HasOne(d => d.Beverage)
                    .WithMany(p => p.Recipe)
                    .HasForeignKey(d => d.BeverageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_beverage_id");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.Recipe)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_ingredient_id");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.HasIndex(e => e.RegionId)
                    .HasName("region_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.RegionId)
                    .HasColumnName("region_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("region_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.AddressId)
                    .HasName("user_address_id_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PhoneNum)
                    .HasColumnName("phone_num")
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Verified).HasColumnName("verified");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_address_id");
            });

            modelBuilder.Entity<UserBottle>(entity =>
            {
                entity.ToTable("user_bottle");

                entity.HasIndex(e => e.BottleId)
                    .HasName("user_bottle_bottle_id_idx");

                entity.HasIndex(e => e.UserBottleId)
                    .HasName("user_bottle_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("user_bottle_user_id_idx");

                entity.Property(e => e.UserBottleId)
                    .HasColumnName("user_bottle_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BottleId)
                    .IsRequired()
                    .HasColumnName("bottle_id")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Bottle)
                    .WithMany(p => p.UserBottle)
                    .HasForeignKey(d => d.BottleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_bottle_bottle_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBottle)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_bottle_user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
