using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Items {
	public class StoneRoseTableItem : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stone Rose Table");
			Tooltip.SetDefault("An ancient design of a marvelous stone table");
		}

		public override void SetDefaults() {
			item.width = 16;
			item.height = 34;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.StoneRoseTable>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneSlab, 4);
			recipe.AddIngredient(ItemID.BorealWood, 4);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}