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
		};
		public override void Load() {
			foreach (var mymug in mugs) {
				Mug item = new Mug(mymug.displayName, "StoneworkRoseCafe/Mugs/Items/" + mymug.texturePath);
				MugTile tile = new MugTile(item);
				item.tile = tile.Type;
				AddItem(mymug.displayName, item);
				AddTile(mymug.displayName, tile, "StoneworkRoseCafe/Mugs/Tiles/" + mymug.texturePath);
			}
		}
	}
}