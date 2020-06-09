using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Mugs.Items {
	class GlazedStoneMugItem : StoneMugItem {
		public override void SetDefaults() {
			item.CloneDefaults(ItemType<StoneMugItem>());
			item.createTile = TileType<Tiles.GlazedStoneMugTile>();
		}
	}
}
