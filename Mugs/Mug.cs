using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace StoneworkRoseCafe.Mugs {
    class Mug : ModItem {
		private string displayName;
		private string texturePath;
		public int tile;

		public Mug(string displayName, string texturePath) {
			this.displayName = displayName;
			this.texturePath = texturePath;
		}

		public override void SetStaticDefaults() {
			DisplayName.SetDefault(displayName);
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
			item.createTile = tile;
			item.placeStyle = 0;
		}
	}
}
