using AutoMapper;
using hands_on_netcore.Model.Domain;
using hands_on_netcore.Model.DTO;

namespace hands_on_netcore.Mapper
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<Produto, NovoProdutoDto>()
                .ForPath(dest => dest.detalhes.QtdEstoque, opt => opt.MapFrom(src => src.QtdEstoque))
                .ForPath(dest => dest.detalhes.UltimaCompra, opt => opt.MapFrom(src => src.UltimaCompra))
                .ForPath(dest => dest.detalhes.Ativo, opt => opt.MapFrom(src => src.Ativo))
                .ReverseMap();
        }
    }
}