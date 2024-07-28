using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STS.Task.Apis.DTOs;
using STS.Task.Apis.Helpers;
using STS.Task.BLL.Interfaces;
using STS.Task.BLL.Services;
using STS.Task.DAL.Models;

namespace STS.Task.Apis.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService productService;
		private readonly IMapper mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			this.productService = productService;
			this.mapper = mapper;
		}


		[HttpGet]
		public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams specParams)
		{
			var products = await productService.GetProductsAsync(specParams);
			var count = await productService.GetCountAsync();

			var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

			return Ok(new Pagination<ProductToReturnDto>(specParams.PageIndex,specParams.PageSize, count, data));
		}

	}
}
