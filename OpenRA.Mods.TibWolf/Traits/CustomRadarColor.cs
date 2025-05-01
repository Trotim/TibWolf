using OpenRA.Mods.Common.Traits;
using OpenRA.Primitives;
using OpenRA.Traits;

namespace OpenRA.Mods.TibWolf.Traits
{
	[Desc("Define a custom radar color used regardless of owner.")]
	public class CustomRadarColorInfo : TraitInfo
	{
		[Desc("Color to use")]
		public readonly Color Color = Color.White;

		public override object Create(ActorInitializer init) { return new CustomRadarColor(init, this); }
	}

	public class CustomRadarColor : IRadarColorModifier
	{
		public CustomRadarColorInfo Info { get; set; }

		public CustomRadarColor(ActorInitializer init, CustomRadarColorInfo info)
		{
			Info = info;
		}

		Color IRadarColorModifier.RadarColorOverride(Actor self, Color color)
		{
			return Info.Color;
		}
	}
}
