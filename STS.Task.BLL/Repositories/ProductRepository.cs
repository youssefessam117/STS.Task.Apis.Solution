using Microsoft.EntityFrameworkCore;
using STS.Task.BLL.Interfaces;
using STS.Task.BLL.Services;
using STS.Task.DAL.Data;
using STS.Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Task.BLL.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private protected readonly ApplicationDbContext _dbContext;

		public ProductRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		async Task<IReadOnlyList<Product>> IProductRepository.GetAllWithSpecAsync(ProductSpecParams specParams)
		{
				return await _dbContext.Products.Skip((specParams.PageIndex - 1) * specParams.PageSize)
												.Take(specParams.PageSize)
												.ToListAsync();
		}

		async Task<Product?> IProductRepository.GetAsync(int id)
		{
			return await _dbContext.FindAsync<Product>(id);
		}

		public void Add(Product entity)
			=> _dbContext.Add(entity);

		public void Update(Product entity)
			=> _dbContext.Update(entity);

		public void Delete(Product entity)
			=> _dbContext.Remove(entity);

		public async Task<int> GetCountAsync()
		{
			return await _dbContext.Products.CountAsync();
		}
	}
}
