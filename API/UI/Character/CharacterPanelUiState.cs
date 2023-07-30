using AARPG.Core.Mechanics;
using AARPG.Core.Players;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace AARPG.API.UI.Character;

public class CharacterPanelUiState : UIState
{
	public UIDragablePanel panel;
	public bool visible = false;
	private bool addedLevels;
	private bool addedExperience;

	public override void OnInitialize() {

		panel = new UIDragablePanel("Character Information");
		panel.Left.Set(800, 0);
		panel.Top.Set(100, 0);
		panel.Width.Set(280, 0);
		panel.Height.Set(200, 0);

		Append(panel);
	}

	public void AddLevelText() {
		var playerStats = GetPlayerStats();
		if (playerStats == null || addedLevels) {
			return;
		}
		var levelText = new UIText($"Level: {playerStats.stats.level}", 0.9f) { MarginLeft = 1f };
		panel.viewArea.Append(levelText);
		addedLevels = true;
	}
	
	public void AddExperienceText() {
		var playerStats = GetPlayerStats();
		if (playerStats == null || addedExperience) {
			return;
		}

		var levelText = new UIText($"Experience: {playerStats.stats.xp} / {PlayerStatistics.XPRequirementsPerLevel[playerStats.stats.level]}", 0.9f) {
			MarginTop = 20
		};
		panel.viewArea.Append(levelText);
		addedExperience = true;
	}
	
	private StatPlayer GetPlayerStats() {
		var player = Main.LocalPlayer;
		return player.GetModPlayer<StatPlayer>();
	}

	public void Refresh() {
		panel.viewArea.RemoveAllChildren();
		addedLevels = false;
		addedExperience = false;
	}
}