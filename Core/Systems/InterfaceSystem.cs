using AARPG.Core.UI.NPCStats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using AARPG.API.UI.Character;
using AARPG.Core.Mechanics;
using AARPG.Core.Players;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace AARPG.Core.Systems {
	public class InterfaceSystem : ModSystem {
		public static bool LeftClick => curMouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released;

		private static MouseState oldMouse;
		private static MouseState curMouse;

		internal static NPCStatsState debugNPCStats;
		public static UserInterface uiInterface;
		public static CharacterPanelUiState characterPanel;

		public static void LoadStatic() {
			if (Main.dedServ)
				return;

			uiInterface = new();
			debugNPCStats = new();
			characterPanel = new();
			characterPanel.Initialize();

			uiInterface.SetState(debugNPCStats);
			debugNPCStats.Activate();
		}

		public static void UnloadStatic() {
			uiInterface = null;
			debugNPCStats = null;
		}

		public override void UpdateUI(GameTime gameTime) {
			oldMouse = curMouse;
			curMouse = Mouse.GetState();

			if (debugNPCStats.Active)
				uiInterface.Update(gameTime);

			if (!Main.gameMenu && characterPanel.visible) {
				uiInterface?.Update(gameTime);
			}
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
			int idx = layers.FindIndex(layer => layer.Name == "Vanilla: Mouse Text");
			if (idx >= 0) {
				layers.Insert(idx + 1, new LegacyGameInterfaceLayer("AARPG: Debug NPC Stats", DrawDebugNpcUi, InterfaceScaleType.UI));
				layers.Insert(idx + 1, new LegacyGameInterfaceLayer("Character Panel", DrawCharacterUi, InterfaceScaleType.UI));
			}
		}

		private bool DrawDebugNpcUi() {
			if (debugNPCStats.Active)
				uiInterface.Draw(Main.spriteBatch, new GameTime());
			
			return true;
		}

		private bool DrawCharacterUi() {
			if (!Main.gameMenu && characterPanel.visible) {
				characterPanel.AddLevelText();
				characterPanel.AddExperienceText();
				characterPanel.AddPerkPointsText();
				characterPanel.AddRefundPointsText();
				uiInterface.Draw(Main.spriteBatch, new GameTime());	
			}

			return true;
		}
	}
}