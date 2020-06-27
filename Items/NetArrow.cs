using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Items
{
	public class NetArrow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This arrow entraps creatures");
		}

		public override void SetDefaults() {
			item.damage = 12;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 0;
			item.value = 10;
			item.rare = ItemRarityID.Green;
			item.shoot = ProjectileType<Projectiles.NetArrow>();   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 16f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 50);
			recipe.AddIngredient(ItemID.BugNet, 1);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}