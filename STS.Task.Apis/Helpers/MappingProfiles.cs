using AutoMapper;
using STS.Task.Apis.DTOs;
using STS.Task.DAL.Models;

namespace STS.Task.Apis.Helpers
{
	public class MappingProfiles : Profile
	{

		public MappingProfiles()
		{
			CreateMap<Product, ProductToReturnDto>()
				.ForMember(p => p.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());
		}
	}
}
