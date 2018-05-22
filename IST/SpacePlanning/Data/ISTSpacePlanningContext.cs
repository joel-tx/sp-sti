using Microsoft.EntityFrameworkCore;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace IST.SpacePlanning.Data
{
    public partial class ISTSpacePlanningContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public virtual DbSet<Element> Element { get; set; }
        public virtual DbSet<ElementType> ElementType { get; set; }
        public virtual DbSet<ElementUser> ElementUser { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<EntityAddress> EntityAddress { get; set; }
        public virtual DbSet<EntityName> EntityName { get; set; }
        public virtual DbSet<EntityType> EntityType { get; set; }
        public virtual DbSet<EntityUser> EntityUser { get; set; }
        public virtual DbSet<Graphic> Graphic { get; set; }
        public virtual DbSet<GraphicType> GraphicType { get; set; }
        public virtual DbSet<Layer> Layer { get; set; }
        public virtual DbSet<LayerType> LayerType { get; set; }
        public virtual DbSet<Lock> Lock { get; set; }
        public virtual DbSet<LockUser> LockUser { get; set; }
        public virtual DbSet<LogLevel> LogLevel { get; set; }
        public virtual DbSet<Name> Name { get; set; }
        public virtual DbSet<Object> Object { get; set; }
        public virtual DbSet<ObjectPermission> ObjectPermission { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<OperationPermission> OperationPermission { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PhysicalElement> PhysicalElement { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<PlanUser> PlanUser { get; set; }
        public virtual DbSet<Preference> Preference { get; set; }
        public virtual DbSet<PreferenceUser> PreferenceUser { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<Scene> Scene { get; set; }
        public virtual DbSet<SceneType> SceneType { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<SessionLog> SessionLog { get; set; }
        public virtual DbSet<SessionRole> SessionRole { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        public ISTSpacePlanningContext() : base()
        {

        }

        public ISTSpacePlanningContext(DbContextOptions options) : base(options)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                var configuration = builder.Build();
                optionsBuilder.UseSqlServer(@"Data Source=TXBOJTOLA-2;Initial Catalog=SteveSuggestion;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.AddressId)
                    .HasName("IDX_address_id");

                entity.HasIndex(e => e.City)
                    .HasName("IDX_address_city");

                entity.HasIndex(e => e.State)
                    .HasName("IDX_address_state");

                entity.HasIndex(e => new { e.City, e.State })
                    .HasName("IDX_address_city_state");

                entity.HasIndex(e => new { e.AddressLine1, e.City, e.State, e.PostalCode })
                    .HasName("IDX_address_full");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasColumnName("address_line_1")
                    .HasMaxLength(128);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line_2")
                    .HasMaxLength(128);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(64);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('USA')");

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasMaxLength(64);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postal_code")
                    .HasMaxLength(16);

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(128);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("Audit_Log");

                entity.HasIndex(e => e.CreateDate)
                    .HasName("IDX_created");

                entity.HasIndex(e => new { e.CreateDate, e.LevelId })
                    .HasName("IDX_level_created");

                entity.Property(e => e.AuditLogId)
                    .HasColumnName("audit_log_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Entry)
                    .IsRequired()
                    .HasColumnName("entry")
                    .HasColumnType("text");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.AuditLog)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audit_Log_Log_Level");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuditLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audit_Log_User");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasIndex(e => e.ElementId)
                    .HasName("IDX_element_id");

                entity.Property(e => e.ElementId)
                    .HasColumnName("element_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.ElementTypeId).HasColumnName("element_type_id");

                entity.Property(e => e.GraphicId).HasColumnName("graphic_id");

                entity.Property(e => e.Label)
                    .HasColumnName("label")
                    .HasMaxLength(32);

                entity.HasOne(d => d.ElementType)
                    .WithMany(p => p.Element)
                    .HasForeignKey(d => d.ElementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Element_Element_Type");

                entity.HasOne(d => d.Graphic)
                    .WithMany(p => p.Element)
                    .HasForeignKey(d => d.GraphicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Element_Graphic");
            });

            modelBuilder.Entity<ElementType>(entity =>
            {
                entity.ToTable("Element_Type");

                entity.HasIndex(e => e.ElementTypeId)
                    .HasName("IDX_element_type_id");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_element_name");

                entity.Property(e => e.ElementTypeId)
                    .HasColumnName("element_type_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<ElementUser>(entity =>
            {
                entity.HasKey(e => new { e.ElementId, e.UserId });

                entity.ToTable("Element_User");

                entity.Property(e => e.ElementId).HasColumnName("element_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.ElementUser)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Element_User_Element");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ElementUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Element_User_User");
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.HasIndex(e => e.EntityId)
                    .HasName("IDX_entity_id");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_entity_name");

                entity.Property(e => e.EntityId)
                    .HasColumnName("entity_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.EntityTypeId).HasColumnName("entity_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.HasOne(d => d.EntityType)
                    .WithMany(p => p.Entity)
                    .HasForeignKey(d => d.EntityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entity_Entity_Type");
            });

            modelBuilder.Entity<EntityAddress>(entity =>
            {
                entity.HasKey(e => new { e.AddressId, e.EntityId });

                entity.ToTable("Entity_Address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.EntityAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entity_Address_Address");

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.EntityAddress)
                    .HasForeignKey(d => d.EntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entity_Address_Entity");
            });

            modelBuilder.Entity<EntityName>(entity =>
            {
                entity.HasKey(e => new { e.NameId, e.EntityId });

                entity.ToTable("Entity_Name");

                entity.Property(e => e.NameId).HasColumnName("name_id");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.EntityName)
                    .HasForeignKey(d => d.EntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entity_Name_Entity");

                entity.HasOne(d => d.Name)
                    .WithMany(p => p.EntityName)
                    .HasForeignKey(d => d.NameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entity_Name_Name");
            });

            modelBuilder.Entity<EntityType>(entity =>
            {
                entity.ToTable("Entity_Type");

                entity.HasIndex(e => e.EntityTypeId)
                    .HasName("IDX_entity_type_id");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_entity_type_name");

                entity.Property(e => e.EntityTypeId)
                    .HasColumnName("entity_type_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<EntityUser>(entity =>
            {
                entity.HasKey(e => new { e.EntityId, e.UserId });

                entity.ToTable("Entity_User");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.EntityUser)
                    .HasForeignKey(d => d.EntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entity_User_Entity");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EntityUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entity_User_User");
            });

            modelBuilder.Entity<Graphic>(entity =>
            {
                entity.HasIndex(e => e.GraphicId)
                    .HasName("IDX_graphic_id");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_name");

                entity.Property(e => e.GraphicId)
                    .HasColumnName("graphic_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.GraphicTypeId).HasColumnName("graphic_type_id");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.GraphicType)
                    .WithMany(p => p.Graphic)
                    .HasForeignKey(d => d.GraphicTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Graphic_Graphic_Type");
            });

            modelBuilder.Entity<GraphicType>(entity =>
            {
                entity.ToTable("Graphic_Type");

                entity.HasIndex(e => e.GraphicTypeId)
                    .HasName("IDX_graphic_type_id");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_graphic_type_name");

                entity.Property(e => e.GraphicTypeId)
                    .HasColumnName("graphic_type_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Layer>(entity =>
            {
                entity.HasIndex(e => e.LayerId)
                    .HasName("IDX_layer_id");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_layer_name");

                entity.HasIndex(e => new { e.LayerId, e.SceneId })
                    .HasName("IDX_LayerID_SceneID");

                entity.Property(e => e.LayerId)
                    .HasColumnName("layer_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.LayerTypeId).HasColumnName("layer_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32);

                entity.Property(e => e.SceneId).HasColumnName("scene_id");

                entity.Property(e => e.Zorder).HasColumnName("zorder");

                entity.HasOne(d => d.LayerType)
                    .WithMany(p => p.Layer)
                    .HasForeignKey(d => d.LayerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Layer_Layer_Type");

                entity.HasOne(d => d.Scene)
                    .WithMany(p => p.Layer)
                    .HasForeignKey(d => d.SceneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Layer_Scene");
            });

            modelBuilder.Entity<LayerType>(entity =>
            {
                entity.ToTable("Layer_Type");

                entity.HasIndex(e => e.LayerTypeId)
                    .HasName("IDX_layer_type_id");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_layer_type_name");

                entity.Property(e => e.LayerTypeId)
                    .HasColumnName("layer_type_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Lock>(entity =>
            {
                entity.Property(e => e.LockId)
                    .HasColumnName("lock_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ElementId).HasColumnName("element_id");

                entity.Property(e => e.LayerId).HasColumnName("layer_id");

                entity.Property(e => e.SceneId).HasColumnName("scene_id");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Lock)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lock_Element");

                entity.HasOne(d => d.Layer)
                    .WithMany(p => p.Lock)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lock_Layer");

                entity.HasOne(d => d.Scene)
                    .WithMany(p => p.Lock)
                    .HasForeignKey(d => d.SceneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lock_Scene");
            });

            modelBuilder.Entity<LockUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LockId });

                entity.ToTable("Lock_User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.LockId).HasColumnName("lock_id");

                entity.HasOne(d => d.Lock)
                    .WithMany(p => p.LockUser)
                    .HasForeignKey(d => d.LockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lock_User_Lock");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LockUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lock_User_User");
            });

            modelBuilder.Entity<LogLevel>(entity =>
            {
                entity.ToTable("Log_Level");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_level_name");

                entity.Property(e => e.LogLevelId)
                    .HasColumnName("log_level_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Name>(entity =>
            {
                entity.HasIndex(e => e.Last)
                    .HasName("IDX_last");

                entity.HasIndex(e => e.NameId)
                    .HasName("IDX_name_id");

                entity.HasIndex(e => new { e.First, e.Last })
                    .HasName("IDX_first_last");

                entity.Property(e => e.NameId)
                    .HasColumnName("name_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.First)
                    .IsRequired()
                    .HasColumnName("first")
                    .HasMaxLength(64);

                entity.Property(e => e.Last)
                    .IsRequired()
                    .HasColumnName("last")
                    .HasMaxLength(64);

                entity.Property(e => e.Middle)
                    .HasColumnName("middle")
                    .HasMaxLength(16);

                entity.Property(e => e.Prefix)
                    .HasColumnName("prefix")
                    .HasMaxLength(8);

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<Object>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IDX_obj_name");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("IDX_object_id");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("object_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<ObjectPermission>(entity =>
            {
                entity.HasKey(e => new { e.ObjectId, e.PermissionId });

                entity.ToTable("Object_Permission");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.ObjectPermission)
                    .HasForeignKey(d => d.ObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Object_Permission_Object");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ObjectPermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Object_Permission_Permission");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IDX_op_name");

                entity.HasIndex(e => e.OperationId)
                    .HasName("IDX_operation_id");

                entity.Property(e => e.OperationId)
                    .HasColumnName("operation_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<OperationPermission>(entity =>
            {
                entity.HasKey(e => new { e.OperationId, e.PermissionId });

                entity.ToTable("Operation_Permission");

                entity.Property(e => e.OperationId).HasColumnName("operation_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.OperationPermission)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operation_Permission_Operation");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.OperationPermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operation_Permission_Permission");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IDX_perm_name");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("IDX_permission_id");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<PhysicalElement>(entity =>
            {
                entity.ToTable("physical_element");

                entity.HasIndex(e => e.PhysicalElementId)
                    .HasName("IDX_physical_element_id");

                entity.Property(e => e.PhysicalElementId)
                    .HasColumnName("physical_element_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(100);

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(16);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.ElementId).HasColumnName("element_id");

                entity.Property(e => e.Endx).HasColumnName("endx");

                entity.Property(e => e.Endy).HasColumnName("endy");

                entity.Property(e => e.Label)
                    .HasColumnName("label")
                    .HasMaxLength(32);

                entity.Property(e => e.LayerId).HasColumnName("layer_id");

                entity.Property(e => e.Rotation).HasColumnName("rotation");

                entity.Property(e => e.Startx).HasColumnName("startx");

                entity.Property(e => e.Starty).HasColumnName("starty");

                entity.Property(e => e.Zorder).HasColumnName("zorder");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.PhysicalElement)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_physical_element_Element");

                entity.HasOne(d => d.Layer)
                    .WithMany(p => p.PhysicalElement)
                    .HasForeignKey(d => d.LayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_physical_element_Layer");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IDX_plan_name");

                entity.HasIndex(e => e.PlanId)
                    .HasName("IDX_plan_id");

                entity.Property(e => e.PlanId)
                    .HasColumnName("plan_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<PlanUser>(entity =>
            {
                entity.HasKey(e => new { e.PlanId, e.UserId });

                entity.ToTable("Plan_User");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PlanUser)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plan_User_Plan");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PlanUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plan_User_User");
            });

            modelBuilder.Entity<Preference>(entity =>
            {
                entity.HasIndex(e => e.PreferenceId)
                    .HasName("IDX_preference_id");

                entity.Property(e => e.PreferenceId)
                    .HasColumnName("preference_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<PreferenceUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PreferenceId });

                entity.ToTable("Preference_User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.PreferenceId).HasColumnName("preference_id");

                entity.HasOne(d => d.Preference)
                    .WithMany(p => p.PreferenceUser)
                    .HasForeignKey(d => d.PreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preference_User_Preference");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PreferenceUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preference_User_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IDX_role_name");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IDX_role_id");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId });

                entity.ToTable("Role_Permission");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Permission_Permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Permission_Role");
            });

            modelBuilder.Entity<Scene>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IDX_scene_name");

                entity.HasIndex(e => e.SceneId)
                    .HasName("IDX_scene_id");

                entity.Property(e => e.SceneId)
                    .HasColumnName("scene_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.SceneTypeId).HasColumnName("scene_type_id");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Scene)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scene_Plan");

                entity.HasOne(d => d.SceneType)
                    .WithMany(p => p.Scene)
                    .HasForeignKey(d => d.SceneTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scene_Scene_Type");
            });

            modelBuilder.Entity<SceneType>(entity =>
            {
                entity.ToTable("Scene_Type");

                entity.HasIndex(e => e.Name)
                    .HasName("IDX_scene_type_name");

                entity.HasIndex(e => e.SceneTypeId)
                    .HasName("IDX_scene_type_id");

                entity.Property(e => e.SceneTypeId)
                    .HasColumnName("scene_type_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasIndex(e => e.SessionId)
                    .HasName("IDX_session_id");

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<SessionLog>(entity =>
            {
                entity.ToTable("Session_Log");

                entity.Property(e => e.SessionLogId)
                    .HasColumnName("session_log_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Entry)
                    .IsRequired()
                    .HasColumnName("entry")
                    .HasColumnType("text");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionLog)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Log_Session");
            });

            modelBuilder.Entity<SessionRole>(entity =>
            {
                entity.HasKey(e => new { e.SessionId, e.RoleId });

                entity.ToTable("Session_Role");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SessionRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Role_Role");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionRole)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Role_Session");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IDX_user_id");

                entity.HasIndex(e => e.Username)
                    .HasName("IDX_username");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActiveDate)
                    .HasColumnName("active_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150);

                entity.Property(e => e.LockoutCount).HasColumnName("lockout_count");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(512);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("User_Role");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role_User");
            });
        }
    }
}
