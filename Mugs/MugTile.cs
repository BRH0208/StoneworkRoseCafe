
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Mugs.Tiles {
    class MugTile : ModTile {
        public static int dropItem;
        public static string texturePath;
        public static string myname;

        public MugTile(ModItem item, string texture) {
            texturePath = texture;
            dropItem = item.item.whoAmI;
            myname = item.item.HoverName;
        }
        public override bool Autoload(ref string name, ref string texture) {
            name = myname;
            texturePath = texture;
            return false;
        }
        public override void SetDefaults() {
            Main.tileSolid[Type] = false;
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
        }

        public override bool Drop(int i, int j) {
            Tile t = Main.tile[i, j];
            int style = t.frameX / 18;
            if (style == 0) // It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
            {
                Item.NewItem(i * 16, j * 16, 16, 16, dropItem);
            }
            return base.Drop(i, j);
        }
    }
}
