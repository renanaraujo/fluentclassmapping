using FluentClassMapping;
using FluentClassMappingTest.DTO;
using FluentClassMappingTest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentClassMappingTest.EntityMapping
{
	public class EmpresaMapping : FluentMapper<EmpresaDto, EmpresaEntity>
	{
		static EmpresaMapping()
		{
			Map(dto => dto.Id, entity => entity.Id);
			Map(dto => dto.Nome, entity => entity.Nome);
		}
	}
}
