using STS.Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace STS.Task.DAL.Data
{
	public static class ApplicationDbContextSeed
	{
		public static async System.Threading.Tasks.Task SeedAsync(ApplicationDbContext dbContext)
		{
			if (!dbContext.Products.Any())
			{
				var productsData = File.ReadAllText("../STS.Task.DAL/Data/Dataseed/products.json");

				var products = JsonSerializer.Deserialize<List<Product>>(productsData);

				if (products?.Count > 0)
				{
					foreach (var product in products)
					{
						dbContext.Set<Product>().Add(product);
					}
					await dbContext.SaveChangesAsync();
				}
			}
		}
	}
}
