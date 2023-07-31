using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader.IO;

namespace AARPG.Core.Mechanics;

/// <summary>
/// An object representing the XP, Level and other stat modifiers that could be shared between NPCs and players
/// </summary>
public class Statistics {
	public int level;
	public int xp;
	public Dictionary<string, Perk> perks;
	public int perkPoints;
	public int refundPoints;

	public Modifier healthModifier = Modifier.Default;

	public Modifier defenseModifier = Modifier.Default;

	public Modifier enduranceModifier = Modifier.Default;

	public virtual TagCompound SaveToTag()
		=> new() {
			["level"] = level,
			["xp"] = xp,
			["perks"] = SavePerks(),
			["perkPoints"] = perkPoints,
			["refundPoints"] = refundPoints,
			["mod.hp"] = healthModifier.ToTag(),
			["mod.defense"] = defenseModifier.ToTag(),
			["mod.endure"] = enduranceModifier.ToTag()
		};

	public virtual void LoadFromTag(TagCompound tag) {
		level = tag.GetInt("level");
		xp = tag.GetInt("xp");
		LoadPerks(tag.GetCompound("perks"));
		perkPoints = tag.GetInt("perkPoints");
		refundPoints = tag.GetInt("refundPoints");
		healthModifier = Modifier.FromTag(tag.GetCompound("mod.hp"));
		defenseModifier = Modifier.FromTag(tag.GetCompound("mod.defense"));
		enduranceModifier = Modifier.FromTag(tag.GetCompound("mod.endure"));
	}

	private void LoadPerks(TagCompound compound) {
		if (!compound.Any()) return;
		var activePerks = compound.Get<Dictionary<string, Perk>>("perks");
		foreach (var perk in activePerks) {
			perks.Add(perk.Key, perk.Value);
		}
	}

	private TagCompound SavePerks() {
		return new(){
			["perks"] = perks,
		};
	}
}