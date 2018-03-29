using System.Linq;

namespace Common
{
    public interface IMappingProvider
    {
        Target Map<Source, Target>(Source source);
        IQueryable<TargetType> ProjectTo<CollectionType, TargetType>(IQueryable<CollectionType> collection);
    }
}