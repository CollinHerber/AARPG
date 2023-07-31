using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AARPG.Core.Mechanics.Perks;

public class TestPerk : Perk {
	public TestPerk() : base("Regeneration", 1, 1) {

	}

	public override void Enable(Perk perk) {
		base.Enable(this);
		var players = Main.player;
		foreach (var player in players) {
			player.AddBuff(BuffID.Regeneration, 3600);
		}
	}
	
	public override void Disable(Perk perk) {
		base.Disable(this);
		var players = Main.player;
		foreach (var player in players) {
			player.ClearBuff(BuffID.Regeneration);
		}
	}
}