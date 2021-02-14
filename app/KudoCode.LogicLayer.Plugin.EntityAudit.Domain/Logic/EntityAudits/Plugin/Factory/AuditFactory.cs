using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin.Factory
{
	public class EntityAuditFactory : IEntityAuditFactory
	{
		public EntityAuditFactory()
		{
			_results = new Dictionary<string, List<PropertyInformationDto>>();
		}

		private Dictionary<string, List<PropertyInformationDto>> _results { get; set; }

		public async Task<List<PropertyInformationDto>> Set(string name, object obj)
		{
			if (obj == null) return null;

			var propertyInformation = await Task.Run(() => new CollectObjectProperties().Get(obj));
			_results.Add(name, propertyInformation);
			return propertyInformation;
		}

		public async Task<List<PropertyInformationDto>> GetDifference(string nameA, string nameB)
		{
			if (!_results.ContainsKey(nameA) || !_results.ContainsKey(nameB))
				return new List<PropertyInformationDto>();

			var org = _results[nameA];
			var mod = _results[nameB];

			org.ToList().ForEach(a => a.Value = a.Value ?? "");
			mod.ToList().ForEach(a => a.Value = a.Value ?? "");

			var result = await Task.Run(() =>
			 mod.Where(p => !org.Any(matchProperty(p))).ToList()
			);
			return result;
		}

		private static Func<IPropertyInformationDto, bool> matchProperty(IPropertyInformationDto p)
		{
			return p2 => p2.Name.Equals(p.Name) && p2.Value.ToString().Equals(p.Value);
		}
	}
}
