using AARPG.API.UI;
using AARPG.Core.Mechanics;
using AARPG.Core.Mechanics.Perks;
using AARPG.Core.Players;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace AARPG.API.UI.Character;

public class PerkUiState : UIState
{
	public UIDragablePanel panel;
	public bool visible;
	private bool addedPerks;

	public override void OnInitialize() {

		panel = new UIDragablePanel("Perk Tree");
		panel.OnMenuClose += () => {
			visible = false;
		};
		panel.Left.Set(700, 0);
		panel.Top.Set(100, 0);
		panel.Width.Set(400, 0);
		panel.Height.Set(250, 0);
		Append(panel);
	}

	public void DrawPerks() {
		if (addedPerks) return;
		var perkPanel = new PerkSquare(new TestPerk());
		panel.viewArea.Append(perkPanel);
		addedPerks = true;
	}

	public void Refresh() {
		panel.viewArea.RemoveAllChildren();
		addedPerks = false;
	}
}