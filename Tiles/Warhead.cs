using StoneworkRoseCafe.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Tiles {
    public class Warhead : ModTile {
		public override void SetDefaults() {
			Main.tileSolid[Type] = true; //collide with and stand upon tile
			Main.tileMergeDirt[Type] = false; //does not merge with dirt
			Main.tileBlockLight[Type] = true; //blocks light
			Main.tileLighted[Type] = true; //documentation is empty on this but it was in the example
			Main.tileTable[Type] = true; //place things on like a table
			drop = ItemType<Items.Warhead>(); //drop Warhead item in /items/Warhead.cs
			AddMapEntry(new Color(200, 200, 200)); //light gray
		}
		public override void HitWire(int i, int j)
		{
			int projectile = Projectile.NewProjectile(i * 16 + 8, j * 16 + 8, 0, 0, ProjectileType<WarheadExplode>(), 2147483647, 20, Main.myPlayer);
			Main.projectile[projectile].timeLeft = 2;
			Main.projectile[projectile].netUpdate = true;
		}
	}
}
