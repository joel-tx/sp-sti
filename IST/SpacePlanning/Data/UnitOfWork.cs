using IST.SpacePlanning.Data.EntityModel;
using IST.SpacePlanning.Data.Repository;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace IST.SpacePlanning.Data
{
    /// <summary>
    /// Implement the Unit of Work pattern in the ISTSpacePlanning database.
    /// </summary>
    public class UnitOfWork : System.IDisposable
    {
        #region Fields...
        readonly ISTSpacePlanningContext _dbContext;
        readonly IRepository<Address> _addressRepository;
        readonly IRepository<AuditLog> _auditLogRepository;
        readonly IRepository<Element> _elementRepository;
        readonly IRepository<ElementType> _elementypeRepository;
        readonly IRepository<ElementUser> _elemenUserRepository;
        readonly IRepository<Entity> _entityRepository;
        readonly IRepository<EntityAddress> _entityAddressRepository;
        readonly IRepository<EntityName> _entityNameRepository;
        readonly IRepository<EntityType> _entityTypeRepository;
        readonly IRepository<EntityUser> _entityUserRepository;
        readonly IRepository<Graphic> _graphicRepository;
        readonly IRepository<GraphicType> _graphicTypeRepository;
        readonly IRepository<Layer> _layerRepository;
        readonly IRepository<LayerType> _layerTypeRepository;
        readonly IRepository<Lock> _lockRepository;
        readonly IRepository<LockUser> _lockUserRepository;
        readonly LogLevelRepository _logLevelRepository;
        readonly IRepository<Name> _nameRepository;
        readonly IRepository<Object> _objectRepository;
        readonly IRepository<ObjectPermission> _objectPermissionRepository;
        readonly IRepository<Operation> _operationRepository;
        readonly IRepository<OperationPermission> _operationPermissionRepository;
        readonly IRepository<Permission> _permissionRepository;
        readonly IRepository<PhysicalElement> _physicalElementRepository;
        readonly IRepository<Plan> _planRepository;
        readonly IRepository<PlanUser> _planUserRepository;
        readonly IRepository<Preference> _preferenceRepository;
        readonly IRepository<PreferenceUser> _preferenceUserRepository;
        readonly IRepository<Role> _roleRepository;
        readonly IRepository<RolePermission> _rolePermissionRepository;
        readonly IRepository<Scene> _sceneRepository;
        readonly IRepository<SceneType> _sceneTypeRepository;
        readonly IRepository<User> _userRepository;
        readonly IRepository<UserRole> _userRoleRepository;
        #endregion
        bool _disposed = false;

        #region Constructors...
        public UnitOfWork(ISTSpacePlanningContext dbContext = null)
        {
            _dbContext = dbContext ?? new ISTSpacePlanningContext();
            _addressRepository = new Repository<Address>(_dbContext);
            _auditLogRepository = new Repository<AuditLog>(_dbContext);
            _elementRepository = new Repository<Element>(_dbContext);
            _elementypeRepository = new Repository<ElementType>(_dbContext);
            _elemenUserRepository = new Repository<ElementUser>(_dbContext);
            _entityRepository = new Repository<Entity>(_dbContext);
            _entityAddressRepository = new Repository<EntityAddress>(_dbContext);
            _entityNameRepository = new Repository<EntityName>(_dbContext);
            _entityTypeRepository = new Repository<EntityType>(_dbContext);
            _entityUserRepository = new Repository<EntityUser>(_dbContext);
            _graphicRepository = new Repository<Graphic>(_dbContext);
            _graphicTypeRepository = new Repository<GraphicType>(_dbContext);
            _layerRepository = new Repository<Layer>(_dbContext);
            _layerTypeRepository = new Repository<LayerType>(_dbContext);
            _lockRepository = new Repository<Lock>(_dbContext);
            _lockUserRepository = new Repository<LockUser>(_dbContext);
            _logLevelRepository = new LogLevelRepository(_dbContext);
            _nameRepository = new Repository<Name>(_dbContext);
            _objectRepository = new Repository<Object>(_dbContext);
            _objectPermissionRepository = new Repository<ObjectPermission>(_dbContext);
            _operationRepository = new Repository<Operation>(_dbContext);
            _operationPermissionRepository = new Repository<OperationPermission>(_dbContext);
            _permissionRepository = new Repository<Permission>(_dbContext);
            _physicalElementRepository = new Repository<PhysicalElement>(_dbContext);
            _planRepository = new Repository<Plan>(_dbContext);
            _planUserRepository = new Repository<PlanUser>(_dbContext);
            _preferenceRepository = new Repository<Preference>(_dbContext);
            _preferenceUserRepository = new Repository<PreferenceUser>(_dbContext);
            _roleRepository = new Repository<Role>(_dbContext);
            _rolePermissionRepository = new Repository<RolePermission>(_dbContext);
            _sceneRepository = new Repository<Scene>(_dbContext);
            _sceneTypeRepository = new Repository<SceneType>(_dbContext);
            _userRepository = new Repository<User>(_dbContext);
            _userRoleRepository = new Repository<UserRole>(_dbContext);
        }
        #endregion

        #region Public methods (Save and Dispose)...
        /// <summary>Saves changes to the database of all repositories with pending CRUD operations.</summary>
        public void Save() => _dbContext.SaveChanges();

        /// <summary>Release resources used.</summary>
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion

        #region Public methods (Repositories)...
        /// <summary>Exposes the AddressRepository repository</summary> 
        public IRepository<Address> AddressRepository => _addressRepository;
        
        /// <summary>Exposes the AuditLogRepository repository</summary> 
        public IRepository<AuditLog> AuditLogRepository => _auditLogRepository;
        
        /// <summary>Exposes the ElementRepository repository</summary> 
        public IRepository<Element> ElementRepository => _elementRepository;

        /// <summary>Exposes the ElementTypeRepository repository</summary> 
        public IRepository<ElementType> ElementypeRepository => _elementypeRepository;

        /// <summary>Exposes the ElementUserRepository repository</summary> 
        public IRepository<ElementUser> ElemenUserRepository => _elemenUserRepository;

        /// <summary>Exposes the EntityRepository repository</summary> 
        public IRepository<Entity> EntityRepository => _entityRepository;

        /// <summary>Exposes the ElementAddressRepository repository</summary> 
        public IRepository<EntityAddress> EntityAddressRepository => _entityAddressRepository;

        /// <summary>Exposes the ElementNameRepository repository</summary> 
        public IRepository<EntityName> EntityNameRepository => _entityNameRepository;

        /// <summary>Exposes the EntityTypeRepository repository</summary> 
        public IRepository<EntityType> EntityTypeRepository => _entityTypeRepository;

        /// <summary>Exposes the EntityUserRepository repository</summary> 
        public IRepository<EntityUser> EntityUserRepository => _entityUserRepository;

        /// <summary>Exposes the GraphicRepository repository</summary> 
        public IRepository<Graphic> GraphicRepository => _graphicRepository;

        /// <summary>Exposes the GraphicTypeRepository repository</summary> 
        public IRepository<GraphicType> GraphicTypeRepository => _graphicTypeRepository;

        /// <summary>Exposes the LayerRepository</summary> 
        public IRepository<Layer> LayerRepository => _layerRepository;

        /// <summary>Exposes the LayerTypeRepository repository</summary> 
        public IRepository<LayerType> LayerTypeRepository => _layerTypeRepository;

        /// <summary>Exposes the LockRepository repository</summary> 
        public IRepository<Lock> LockRepository => _lockRepository;

        /// <summary>Exposes the LockUserRepository repository</summary> 
        public IRepository<LockUser> LockUserRepository => _lockUserRepository;

        /// <summary>Exposes the LogLevelRepository repository</summary> 
        public LogLevelRepository LogLevelRepository => _logLevelRepository;

        /// <summary>Exposes the NameRepository repository</summary> 
        public IRepository<Name> NameRepository => _nameRepository;

        /// <summary>Exposes the ObjectRepository repository</summary> 
        public IRepository<Object> ObjectRepository => _objectRepository;

        /// <summary>Exposes the ObjectPermissionRepository repository</summary> 
        public IRepository<ObjectPermission> ObjectPermissionRepository => _objectPermissionRepository;

        /// <summary>Exposes the OperationRepository repository</summary> 
        public IRepository<Operation> OperationRepository => _operationRepository;

        /// <summary>Exposes the OperationPermissionRepository repository</summary> 
        public IRepository<OperationPermission> OperationPermissionRepository => _operationPermissionRepository;

        /// <summary>Exposes the PermissionRepository repository</summary> 
        public IRepository<Permission> PermissionRepository => _permissionRepository;

        /// <summary>Exposes the PhysicalElementRepository repository</summary> 
        public IRepository<PhysicalElement> PhysicalElementRepository => _physicalElementRepository;

        /// <summary>Exposes the PlanRepository repository</summary> 
        public IRepository<Plan> PlanRepository => _planRepository;

        /// <summary>Exposes the PlanUserRepository repository</summary> 
        public IRepository<PlanUser> PlanUserRepository => _planUserRepository;

        /// <summary>Exposes the ReferenceRepository repository</summary> 
        public IRepository<Preference> PreferenceRepository => _preferenceRepository;

        /// <summary>Exposes the PreferenceUserRepository repository</summary> 
        public IRepository<PreferenceUser> PreferenceUserRepository => _preferenceUserRepository;

        /// <summary>Exposes the RoleRepository repository</summary> 
        public IRepository<Role> RoleRepository => _roleRepository;

        /// <summary>Exposes the RolePermissionRepository repository</summary> 
        public IRepository<RolePermission> RolePermissionRepository => _rolePermissionRepository;

        /// <summary>Exposes the SceneRepository repository</summary> 
        public IRepository<Scene> SceneRepository => _sceneRepository;

        /// <summary>Exposes the SceneTypeRepository repository</summary> 
        public IRepository<SceneType> SceneTypeRepository => _sceneTypeRepository;

        public IRepository<User> UserRepository => _userRepository;

        public IRepository<UserRole> UserRoleRepository => _userRoleRepository;

        #endregion

        #region IDisposable...

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _dbContext.Dispose();
                _disposed = true;
            }
        }

        ~UnitOfWork() => Dispose(false);
        #endregion
    }
}
