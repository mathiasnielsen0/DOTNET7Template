using System.Linq;

namespace DomainModel.Infrastructure
{
    public interface IMapper
    {
        TMapTo MapSingleTo<TMapTo, TMapFrom>(TMapFrom source);
        IQueryable<TMapTo> MapTo<TMapTo>(IQueryable source);
    }

    public static class MapperExtensions
    {
        public static IQueryable<TMapTo> ProjectTo<TMapTo>(this IQueryable source, IMapper mapper)
        {
            return mapper.MapTo<TMapTo>(source);
        }
    }
}