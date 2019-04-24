using FluentClassMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentClassMappingTest.DTO
{
	public class EmpresaDto : IDto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
	}
}
