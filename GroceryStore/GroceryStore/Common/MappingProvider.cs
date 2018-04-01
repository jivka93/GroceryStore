using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace Common
{
    public class MappingProvider : IMappingProvider
    {
        private readonly IMapper mapper;

        public MappingProvider(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IQueryable<TargetType> ProjectTo<CollectionType, TargetType> (IQueryable<CollectionType> collection)
        {
            return collection.ProjectTo<TargetType>();
        }

        public Target Map<Source, Target>(Source source)
        {
            return mapper.Map<Target>(source);
        }
    }
}
