using System;
using AARPG.Core.Systems;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace AARPG.API.Keybinds;
internal class CharacterUiKeybind : ModPlayer {
	public static ModKeybind characterUi;

	public override void Load() {
		if (Main.dedServ)
			return;

		characterUi = KeybindLoader.RegisterKeybind(Mod, "OpenCharacterUi", Keys.I);
	}

	public override void ProcessTriggers(TriggersSet triggersSet) {
		if (characterUi.JustPressed) {
			InterfaceSystem.characterPanel.Refresh();
			InterfaceSystem.characterPanel.visible = !InterfaceSystem.characterPanel.visible;
			InterfaceSystem.uiInterface.SetState(InterfaceSystem.characterPanel);
		}
	}
}