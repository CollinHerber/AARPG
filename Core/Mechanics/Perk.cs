using System.Collections.Generic;
using AARPG.Core.Players;
using AARPG.Core.Systems;
using Terraria;

namespace AARPG.Core.Mechanics;
public class Perk {
	public string name;
	public int currentLevel = 0;
	public int maxLevel;
	public int cost;

	public Perk(string name, int maxLevel, int cost) {
		this.name = name;
		this.maxLevel = maxLevel;
		this.cost = cost;
	}

	public int GetCurrentLevel(string perkName) {
		var player = Main.LocalPlayer;
		var statPlayer = player.GetModPlayer<StatPlayer>();
		if (statPlayer.stats.perks.TryGetValue(perkName, out Perk value)) {
			return value.currentLevel;
		}

		return 0;
	}

	public bool IsEnabled(string perkName) {
		var player = Main.LocalPlayer;
		var statPlayer = player.GetModPlayer<StatPlayer>();
		if (statPlayer.stats.perks != null && statPlayer.stats.perks.TryGetValue(perkName, out Perk value)) {
			return true;
		}

		return false;
	}

	public virtual void Enable(Perk perk) {
		var player = Main.LocalPlayer;
		var statPlayer = player.GetModPlayer<StatPlayer>();
		if (statPlayer.stats.perks == null) {
			statPlayer.stats.perks = new Dictionary<string, Perk>();
			statPlayer.stats.perks.Add(perk.name, perk);
		}
		InterfaceSystem.perkPanel.Refresh();
	}
	
	public virtual void Disable(Perk perk) {
		var player = Main.LocalPlayer;
		var statPlayer = player.GetModPlayer<StatPlayer>();
		if (statPlayer.stats.perks != null && statPlayer.stats.perks.TryGetValue(perk.name, out Perk value)) {
			statPlayer.stats.perks.Remove(perk.name);
		}
		InterfaceSystem.perkPanel.Refresh();
	}
}