using AutoMapper;

namespace Sat.Recruitment.Test.Infrastructure
{
    /// <summary>
    /// Represents a test fixture for unit tests.
    /// </summary>
    public class TestFixture
    {
        /// <summary>
        /// Gets the mapper instance used by the test fixture.
        /// </summary>
        public IMapper Mapper { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestFixture"/> class.
        /// </summary>
        public TestFixture()
        {
            Mapper = AutoMapperFactory.Create();
        }
    }
}
