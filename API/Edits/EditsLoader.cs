namespace AARPG.API.Edits{
	internal static class EditsLoader{
		public static void Load(){
			Terraria.On_NPC.SetDefaultsFromNetId += Detours.Vanilla.NPC_SetDefaultsFromNetId;
			Terraria.On_NPC.Transform += Detours.Vanilla.NPC_Transform;

			Terraria.On_Player.KillMe += Detours.Vanilla.Player_KillMe;
		}
	}
}
