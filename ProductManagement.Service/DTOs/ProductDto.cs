using AutoMapper;
using ProductManagement.Repository.Entities;
using ProductManagement.Service.Common.Mappings;

namespace ProductManagement.Service.DTOs;

public class ProductDto : IMapFrom
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Stock { get; set; }

    public decimal Price { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id,
                source => source.Ignore());
    }
}