using System;
using System.Reflection;
using FluentClassMapping;
using FluentClassMappingTest.DTO;
using FluentClassMappingTest.Entity;
using FluentClassMappingTest.EntityMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentClassMappingTest
{
	[TestClass]
	public class MapTest
	{
		[TestMethod]
		public void ToEntity()
		{
			this.Startup();

			var dto = new EmpresaDto
			{
				Id = 1,
				Nome = "Teste"
			};

			var entity = EmpresaMapping.ToEntity(dto);

			Assert.AreEqual(dto.Id, entity.Id);
			Assert.AreEqual(dto.Nome, entity.Nome);

		}

		[TestMethod]
		public void ToDto()
		{
			this.Startup();
			
			var entity = new EmpresaEntity
			{
				Id = 1,
				Nome = "Teste"
			};

			var dto = EmpresaMapping.ToDto(entity);

			Assert.AreEqual(dto.Id, entity.Id);
			Assert.AreEqual(dto.Nome, entity.Nome);

		}

		private void Startup()
		{
			Activator.CreateInstance(typeof(EmpresaMapping));
		}
	}
}
