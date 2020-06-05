using StoneworkRoseCafe.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace StoneworkRoseCafe.Items.Armor {
	[AutoloadEquip(EquipType.Head)]
	public class Omega : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Vanity Item\nLegend says it is made of Platinum.");
		}

		public override void SetDefaults() {
			item.width = 25;
			item.height = 25;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 0;
		}
		public virtual bool drawHair() { return false; }
		public virtual bool drawHead() { return false; }
	}
}