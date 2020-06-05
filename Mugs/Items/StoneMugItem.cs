using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Mugs.Items {
    class StoneMugItem : ModItem {
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stone Mug");
			Tooltip.SetDefault("Holds coffee! Use it in a cafe.");
		}
        public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 20000;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.StoneMugTile>();
			item.placeStyle = 0;
		}
	}
}
