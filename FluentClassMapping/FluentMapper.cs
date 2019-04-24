using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentClassMapping
{
	/// <summary>
	/// Maps DTO properties to Entity properties via lambda expressions
	/// </summary>
	/// <typeparam name="TDto">DTO type</typeparam>
	/// <typeparam name="TEntity">Entity type</typeparam>
	public class FluentMapper<TDto, TEntity> where TDto : IDto where TEntity : IEntity
	{
		/// <summary>
		/// Properties mapping
		/// </summary>
		private static Dictionary<string, string> mappings = new Dictionary<string, string>();

		/// <summary>
		/// Map the dto property <paramref name="dtoExpression"/> to entity property <paramref name="entityExpression"/>
		/// </summary>
		/// <param name="dtoExpression">dto property lambda expression</param>
		/// <param name="entityExpression">entity property lambda expression</param>
		public static void Map(Expression<Func<TDto, object>> dtoExpression, Expression<Func<TEntity, object>> entityExpression)
		{
			string dtoPropertyName = GetPropertyName(dtoExpression);
			string entityPropertyName = GetPropertyName(entityExpression);

			mappings.Add(dtoPropertyName, entityPropertyName);
		}

		/// <summary>
		/// Convert <paramref name="dto"/> to entity
		/// </summary>
		/// <param name="dto">dto</param>
		/// <returns>Entity with seted properties</returns>
		public static TEntity ToEntity(TDto dto)
		{
			TEntity entity = (TEntity)Activator.CreateInstance(typeof(TEntity));

			foreach (KeyValuePair<string, string> mapping in mappings)
			{
				PropertyInfo propDto = typeof(TDto).GetProperty(mapping.Key);
				PropertyInfo propEntity = typeof(TEntity).GetProperty(mapping.Value);
				propEntity.SetValue(entity, propDto.GetValue(dto), null);
			}

			return entity;
		}

		/// <summary>
		/// Convert <paramref name="entity"/> to dto
		/// </summary>
		/// <param name="entity">entity</param>
		/// <returns>Dto with seted properties</returns>
		public static TDto ToDto(TEntity entity)
		{
			TDto dto = (TDto)Activator.CreateInstance(typeof(TDto));

			foreach (KeyValuePair<string, string> mapping in mappings)
			{
				PropertyInfo propDto = typeof(TDto).GetProperty(mapping.Key);
				PropertyInfo propEntity = typeof(TEntity).GetProperty(mapping.Value);
				propDto.SetValue(dto, propEntity.GetValue(entity), null);
			}

			return dto;
		}

		/// <summary>
		/// Get property name from expression <paramref name="expression"/>
		/// </summary>
		/// <typeparam name="T1">Lambda expression type</typeparam>
		/// <param name="expression">Lambda expression</param>
		/// <returns>Property name</returns>
		private static string GetPropertyName<T1>(Expression<Func<T1, object>> expression)
		{
			MemberExpression body = expression.Body as MemberExpression;

			if (body == null)
			{
				UnaryExpression ubody = (UnaryExpression)expression.Body;
				body = ubody.Operand as MemberExpression;
			}

			return body.Member.Name;
		}
	}
}
