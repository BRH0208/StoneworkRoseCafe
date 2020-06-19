  \using StoneworkRoseCafe.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Items {
	public class LivingDynamite : ModItem {
		public override void SetStaticDefaults() {
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Pet Dynamite");
			Tooltip.SetDefault("It Wants To Explode, If you want this, you want to explode");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ProjectileType<Projectiles.Pets.Dynamite>();
			item.buffType = BuffType<Buffs.PetDynamiteBuff>();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
