using STS.Task.BLL.Interfaces;
using STS.Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Task.BLL.Services
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork unitOfWork;

		public ProductService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecParams specParams)
		{
			var products = await unitOfWork.ProductRepository.GetAllWithSpecAsync(specParams);

			return products;
		}

		public async Task<int> GetCountAsync()
		{
			var count = await unitOfWork.ProductRepository.GetCountAsync();

			return count;
		}
	}
}
