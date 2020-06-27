using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Buffs {
	public class NetBound : ModBuff {
		public override void SetDefaults() {
			// DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Bound!");
			Description.SetDefault("You are bound in net");
			Main.buffNoTimeDisplay[Type] = false;
			Main.vanityPet[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.wingTime = 0;
		}
		
		public override void Update(NPC npc, ref int buffIndex){
			npc.noGravity = false;
		}		
	}
}