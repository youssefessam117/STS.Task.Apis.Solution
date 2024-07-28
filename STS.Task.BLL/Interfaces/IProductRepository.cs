using STS.Task.BLL.Services;
using STS.Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Task.BLL.Interfaces
{
	public interface IProductRepository
	{
		Task<IReadOnlyList<Product>> GetAllWithSpecAsync(ProductSpecParams specParams);
		Task<Product?> GetAsync(int id);
		void Add(Product entity);
		void Update(Product entity);
		void Delete(Product entity);
		Task<int> GetCountAsync();
	}
}
