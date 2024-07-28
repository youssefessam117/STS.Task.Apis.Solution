using STS.Task.BLL.Interfaces;
using STS.Task.BLL.Repositories;
using STS.Task.DAL.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Task.BLL
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext dbContext;

        public IProductRepository ProductRepository { get; set; }

        public UnitOfWork(ApplicationDbContext dbContext) // ask clr for creation object from dbcontext 
		{
			this.dbContext = dbContext;
			ProductRepository = new ProductRepository(dbContext);
		}

		public async Task<int> Complete()
		{
			return await dbContext.SaveChangesAsync();
		}

		public async ValueTask DisposeAsync()
		{
			await dbContext.DisposeAsync();
		}
	}
}
