using IST.SpacePlanning.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestSupport.EfHelpers;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public abstract class AbstractRepositoryTest
    {
        protected UnitOfWork _spacePlanningUnitOfWork;
        protected DbContextOptions<ISTSpacePlanningContext> _dbOptions;
        protected ISTSpacePlanningContext _context;

        [TestInitialize]
        public void SetUp()
        {
            _dbOptions = SqliteInMemory.CreateOptions<ISTSpacePlanningContext>();
            _context = new ISTSpacePlanningContext(_dbOptions);
            _spacePlanningUnitOfWork = new UnitOfWork(_context);
            _context.Database.EnsureCreated();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _context.Dispose();
        }
    }
}
