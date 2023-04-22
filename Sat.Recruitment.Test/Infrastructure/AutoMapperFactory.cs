using AutoMapper;

namespace Sat.Recruitment.Test.Infrastructure
{
    /// <summary>
    /// A factory for creating instances of AutoMapper's IMapper interface.
    /// </summary>
    public static class AutoMapperFactory
    {
        /// <summary>
        /// Creates an instance of AutoMapper with pre-configured mappings.
        /// </summary>
        /// <returns>An instance of IMapper.</returns>
        public static IMapper Create()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps("Sat.Recruitment.Application");
            });

            return mappingConfig.CreateMapper();
        }
    }
}
