
using StoneworkRoseCafe.Mugs.Items;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Mugs.Tiles {
    class GlazedStoneMugTile : StoneMugTile {
        public int drop = ItemType<Items.GlazedStoneMugItem>();
    }
}
