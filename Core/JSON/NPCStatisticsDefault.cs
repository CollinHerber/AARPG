using AARPG.Core.Mechanics;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AARPG.Core.JSON{
	[DataContract]
	public class NPCStatisticsDefault{
		[DataMember(Name = "name")]
		[DefaultValue(null)]
		public string Name{ get; set; }
	}
}
