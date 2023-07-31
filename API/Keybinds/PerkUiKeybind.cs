using System;
using AARPG.Core.Systems;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace AARPG.API.Keybinds;
internal class PerkUiKeybind : ModPlayer {
	public static ModKeybind perkUi;

	public override void Load() {
		if (Main.dedServ)
			return;

		perkUi = KeybindLoader.RegisterKeybind(Mod, "OpenPerkUi", Keys.I);
	}

	public override void ProcessTriggers(TriggersSet triggersSet) {
		if (perkUi.JustPressed) {
			InterfaceSystem.perkPanel.Refresh();
			InterfaceSystem.perkPanel.visible = !InterfaceSystem.perkPanel.visible;
			InterfaceSystem.uiInterface.SetState(InterfaceSystem.perkPanel);
		}
	}
}