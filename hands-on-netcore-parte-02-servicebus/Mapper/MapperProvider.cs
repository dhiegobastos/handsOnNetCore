using AutoMapper;
using AutoMapper.Configuration;

namespace hands_on_netcore.Mapper
{
    public class MapperProvider
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDtoProfile());
            });
        }
    }
}