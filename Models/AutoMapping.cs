using AutoMapper;

namespace Commerce.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.ProductOrders,
                    opts => opts.MapFrom(src => src.ProductOrders)).ReverseMap();
            CreateMap<ProductOrder, ProductOrderDto>();
        }
    }
}