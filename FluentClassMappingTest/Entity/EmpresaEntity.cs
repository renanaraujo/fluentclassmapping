using FluentClassMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentClassMappingTest.Entity
{
	public class EmpresaEntity : IEntity
	{
		public int Id { get; set; }
		public string Nome { get; set; }
	}
}
