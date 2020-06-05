using StoneworkRoseCafe.Mugs.Tiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace StoneworkRoseCafe.Mugs {
	class NewMug : ModItem {
		public string displayName;
		public string texturePath;

		public override bool CloneNewInstances => true;
		public override string Texture => texturePath;

		public NewMug(string displayName, string texturePath) {
			this.displayName = displayName;
			this.texturePath = texturePath;
		}
	}
	class MugTileTemplate : ModTile {
		public override bool Autoload(ref string name, ref string texture) {
			texture = texturePath;
			return false;
        }
		private string texturePath;
		private int dropItem;

		public MugTileTemplate(int ItemID, string texturePath) {
			this.texturePath = texturePath;
			this.dropItem = ItemID;
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
	class MugFactory : Mod {
		
    }
}
