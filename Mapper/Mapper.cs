using AutoMapper;
using AutoMapper.QueryableExtensions;
using IMapper = DomainModel.Infrastructure.IMapper;

namespace Mapper
{
    public class CustomMapper : IMapper
    {
        private MapperConfiguration _config;
        
        public CustomMapper()
        {

            var mappingProfiles = this.GetType().Assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Profile)));

            _config = new MapperConfiguration(cfg =>
            {
                foreach (var mappingProfile in mappingProfiles)
                {
                    cfg.AddProfile(mappingProfile);
                }
            });
        }

        public TMapTo MapSingleTo<TMapTo, TMapFrom>(TMapFrom source)
        {
            return _config.CreateMapper().Map<TMapTo>(source);
        }

        public IQueryable<TMapTo> MapTo<TMapTo>(IQueryable source)
        {
            return source.ProjectTo<TMapTo>(_config);
        }
    }
}
