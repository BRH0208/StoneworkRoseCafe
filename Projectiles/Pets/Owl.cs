using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StoneworkRoseCafe.Projectiles.Pets {
	public class Owl : ModProjectile {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Owl"); // Automatic from .lang files
			Main.projFrames[projectile.type] = 5;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Parrot);
			aiType = ProjectileID.Parrot;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.parrot = false; // Relic from aiType
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			playerMod modPlayer = player.GetModPlayer<playerMod>();
			if (player.dead) {
				modPlayer.owlPet = false;
			}
			if (modPlayer.owlPet) {
				projectile.timeLeft = 2;
			}
		}
	}
}