﻿using AutoMapper;
using STS.Task.Apis.DTOs;
using STS.Task.DAL.Models;

namespace STS.Task.Apis.Helpers
{
	public class ProductPictureUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
	{
		private readonly IConfiguration configuration;

		public ProductPictureUrlResolver(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
		{
			if (!string.IsNullOrEmpty(source.PictureUrl))
				return $"{configuration["ApiBaseUrl"]}/{source.PictureUrl}";


			return string.Empty;
		}
	}
}
