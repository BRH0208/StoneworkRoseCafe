using StoneworkRoseCafe.Mugs;
using StoneworkRoseCafe.Mugs.Tiles;
using Terraria.ModLoader;

namespace StoneworkRoseCafe
{
	public class StoneworkRoseCafe : Mod
	{
		public StoneworkRoseCafe() {
		}
		private static NewMug[] mugs = new NewMug[] {
			new NewMug("Stone Mug","StoneMug"),
			new NewMug("Glazed Stone Mug","GlazedStoneMug"),
			new NewMug("Glass Mug","GlassMug"),
			new NewMug("Heat Treated Stone Mug","HeatTreatedStoneMug"),
			new NewMug("Ceramic Mug","CeramicMug"),//finished to here
			/*new NewMug("Porcelain Mug","PorcelaincMug"),
			new NewMug("Moziac Mug","MoziacMug"),
			new NewMug("Specked Mug","SpeckledMug"),
			new NewMug("Crimstone Mug","CrimstoneMug"),
			new NewMug("Gold-Plated Mug","GoldPlatedMug"),
			new NewMug("Calacatta Marble Mug","MarbleMug"),
			new NewMug("Obsidian Mug","ObsidianMug"),
			new NewMug("China Mug","ChinaMug"),
			new NewMug("Stainless Steel Mug","Stainless Steele Mug"),
			new NewMug("Beast Mug","BeastMug"),
			new NewMug("Wooden Mug","WoodenMug"),*/
		};
		public override void Load() {
			foreach (var mymug in mugs) {
				Mug item = new Mug(mymug.displayName, "StoneworkRoseCafe/Mugs/Items/" + mymug.texturePath + "Item");
				MugTile tile = new MugTile(item, "StoneworkRoseCafe/Mugs/Tiles/" + mymug.texturePath + "Tile");
				AddTile(mymug.displayName, tile, "StoneworkRoseCafe/Mugs/Tiles/" + mymug.texturePath + "Tile");
				item.tile = tile.Type;
				AddItem(mymug.displayName, item);
				tile.drop = item.item.type;
			}
		}
	}
}