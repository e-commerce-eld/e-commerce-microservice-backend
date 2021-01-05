using AutoMapper;

namespace Commerce.Models
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<ProductOrder, ProductOrderDto>().ReverseMap();


        }
    }
}