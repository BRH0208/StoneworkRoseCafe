using System;
using StoneworkRoseCafe.Items;
using StoneworkRoseCafe.Projectiles;
using StoneworkRoseCafe.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;

namespace StoneworkRoseCafe.NPCs.Visitors {
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Visitors : ModNPC {
		public override string Texture => "StoneworkRoseCafe/NPCs/Visitors/visitor0";
		public static void UpdateVisitors() {

			// Spawn the traveler if the spawn conditions are met (time of day, no events, no sundial)
			if (CanSpawnNow()) {
				int newVisitor = NPC.NewNPC(Main.spawnTileX * 16, Main.spawnTileY * 16, NPCType<Visitors>(), 1); // Spawning at the world spawn
				NPC visitor = Main.npc[newVisitor];
				visitor.homeless = true;
				visitor.direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
				visitor.netUpdate = true;
			}
		}
		private static bool CanSpawnNow() {
			// can't spawn if any events are running
			if (Main.eclipse || Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0)
				return false;

			// can't spawn if the sundial is active
			if (Main.fastForwardTime)
				return false;

			// can spawn if daytime, and between the spawn and despawn times
			return true;
		}

		public override bool Autoload(ref string name) {
			name = "Cafe Visitor";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			DisplayName.SetDefault("Cafe Visitor");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 38;
			npc.aiStyle = 7;
			npc.damage = 0;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			return false; //spawning is manual
		}

		public override string TownNPCName() {
			string name;
			switch (WorldGen.genRand.Next(8)) {
				case 0:
					name = "Kent";
					break;
				case 1:
					name = "Fredrick";
					break;
				case 2:
					name = "Gilbert";
					break;
				case 3:
					name = "Alexis";
					break;
				case 4:
					name = "Joyce";
					break;
				case 5:
					name = "Briana";
					break;
				case 6:
					name = "Lisa";
					break;
				case 7:
					name = "Janie";
					break;
				default:
					name = "Jesse";
					break;
			}
			name += " ";
			switch (WorldGen.genRand.Next(8)) {
				case 0:
					name += "Hayden";
					break;
				case 1:
					name += "Townsend";
					break;
				case 2:
					name += "Evans";
					break;
				case 3:
					name += "Cotton";
					break;
				case 4:
					name += "Burns";
					break;
				case 5:
					name += "Drake";
					break;
				case 6:
					name += "Quinn";
					break;
				case 7:
					name += "Finch";
					break;
				default:
					name += "Mack";
					break;
			}
			return name;
		}

		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat() {
			WeightedRandom<string> chat = new WeightedRandom<string>();
			
			chat.Add("Such a wonderful shop, the Stonework Rose.");
			chat.Add("You must be the mayor!");
			if (!Main.dayTime) {
				chat.Add("Midnight coffee is the best coffee.");
			}
			if (Main.raining) {
				chat.Add("Rain just makes the coffee that much better.");
				chat.Add("I'm not sure how I plan to get home in this weather.");
			}

			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
        public override void AI() {
            base.AI();
        }
    }
}