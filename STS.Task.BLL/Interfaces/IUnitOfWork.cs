using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Task.BLL.Interfaces
{
	public interface IUnitOfWork : IAsyncDisposable
	{


		public IProductRepository ProductRepository { get; set; }
		Task<int> Complete();
	}
}
