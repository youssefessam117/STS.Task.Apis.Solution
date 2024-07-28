using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Task.BLL.Services
{
	public class ProductSpecParams
	{
		private const int MaxPageSize = 10;
		private int pageSize = 5;

		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
		}

		public int PageIndex { get; set; } = 1;
	}
}
