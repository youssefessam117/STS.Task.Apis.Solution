using STS.Task.BLL.Services;
using STS.Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Task.BLL.Interfaces
{
	public interface IProductService
	{

		Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecParams specParams);
		Task<int> GetCountAsync();
	}
}
