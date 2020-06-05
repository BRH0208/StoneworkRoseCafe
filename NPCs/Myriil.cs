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

namespace StoneworkRoseCafe.NPCs {
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Myriil : ModNPC {
		public override string Texture => "StoneworkRoseCafe/NPCs/Myriil";


		public override bool Autoload(ref string name) {
			name = "Cafe Owner";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			DisplayName.SetDefault("Cafe Owner");
			Main.npcFrameCount[npc.type] = 24;
			NPCID.Sets.ExtraFramesCount[npc.type] = 7; //precise guesswork based on druid animation
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 1; //bowd
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 38;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Dryad;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			if(Main.bloodMoon || Main.eclipse || !Main.dayTime)
				return false;
			return true;
		}
		public override bool CheckConditions(int left, int right, int top, int bottom) {
			int score = 0;
			bool tables = false;
			bool chairs = false;
			for (int x = left; x <= right; x++) {
				for (int y = top; y <= bottom; y++) {
					int type = Main.tile[x, y].type;
					if (!tables) tables = type == TileType<StoneRoseBench>() || type == TileType<StoneRoseTable>();
					if (!chairs) chairs = type == TileType<StoneRoseChair>();

					if (type == TileID.BorealWood || type == TileID.DynastyWood || type == TileID.OpenDoor || type == TileID.ClosedDoor) {
						score++;
					}
					if (Main.tile[x, y].wall == WallID.BorealWood || Main.tile[x, y].wall == WallID.WhiteDynasty) {
						score++;
					}
				}
			}
			return tables && chairs && (score >= (right - left) * (bottom - top) * 0.75);
			//must have the Stone Rose tables, chairs, and at least 75% Dynasty or Boreal wood
		}

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "Myriil";
				case 1:
					return "Mist";
				case 2:
					return "Uxyll";
				default:
					return "Issat";
			}
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
			if (npc.homeless) {
				chat.Add("I can't do anything without a cafe. My reputation requires a high quality wood construct along with the signature Stonework Rose furniture.");
				chat.Add("I'm a vegabond, like the Travelling Merchant.");
				chat.Add("I love nature, but not living in it.");
				chat.Add("Why would anyone use blue dynasty wood? Oranges and browns are more likely to make customers come again.");
				chat.Add("Wandering eyes are icky, but there is no real estate!");
				return chat;
			}
			//conversation
			int birdman = NPC.FindFirstNPC(NPCType<NPCs.EmissaryOfTheFlock>());
			if (birdman >= 0) {
				chat.Add("Hey, what's up with that " + Main.npc[birdman].GivenName + " fellow?");
				chat.Add("Have you noticed " + Main.npc[birdman].GivenName + " can't teleport to the statues?");
				chat.Add("The \"Emissary Of the Birds\" is not allowed near any of my owls.");
			}
			int bartender = NPC.FindFirstNPC(NPCID.DD2Bartender);
			if(bartender > 0) {
				chat.Add("You might think " + Main.npc[bartender].GivenName + " and I are competition, but we get along smashingly!");
				chat.Add("The cafe can't get you drunk. " + Main.npc[bartender].GivenName + "'s tavern on the other hand...");
				chat.Add("Some of the townspeople think they can only support " + Main.npc[bartender].GivenName + "'s tavern or Stonework Rose cafe. Just come to both!");
			}
			int taxCollector = NPC.FindFirstNPC(NPCID.TaxCollector);
			if(taxCollector > 0) {
				chat.Add("I understand that without the funds from " + Main.npc[taxCollector].GivenName + ", this town would not be the same! Although he always is okay with coffee as payment.");
			}
			int cultists = NPC.FindFirstNPC(NPCID.CultistDevote);
			if(cultists > 0) {
				chat.Add("Sometimes when you're not looking, the cultists will come in here for some tea.", 5);
			}
			chat.Add("I come from a long lineage of cafe owners.");
			chat.Add("'Stonework Rose' came from the cafe's first customer, a smither who lived next door and made stone roses.");
			chat.Add("Stonework Rose Cafe moves every few hundred years. I'm glad I get to be in this neat town!");
			chat.Add("Maybe you will help me decorate the cafe?");
			chat.Add("I'm a falconer at heart, but I also love the cafe. So, I moved here!");
			chat.Add("There used to be a lot of... disputes in the cafe. That's why I carry Jester's Arrows now. It's an old habit.");
			if (Main.LocalPlayer.HasItem(ItemType<OwlItem>()))
				chat.Add("Do tell me you are keeping good care of your owl?", 5);
			else
				chat.Add("If you decide to get a pet owl, make sure you take care of it!");
			chat.Add("I love Dynasty Wood, but the doors are... blue...",0.3);
			chat.Add("What's up, "+(Main.player[Main.myPlayer].Male?"Mr":"Ms") + ". Mayor?");
			if (!Main.dayTime) {
				chat.Add("Getting some caffiene, huh?", 3);
				if(NPC.downedBoss1) {
					chat.Add("Ever since the Eye attacked, I've been having nightmares. Thanks for taking care of it.", 5);
				}
			}
			if(Main.raining) {
				chat.Add("I love having coffee whilst listening to the rain.",3);
				chat.Add("The rain will make your coffee cold too fast. Stay indoors!");
			}
			//hints
			chat.Add("I bet we can improve sales with more seating.");
			chat.Add("A Coffee Pot would go a long way for effeciency around here.");

			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			Player player = Main.player[Main.myPlayer];
			playerMod modPlayer = player.GetModPlayer<playerMod>();
			button2 = "Collect (" + (modPlayer.recievedCafeCut || npc.homeless ? "0" : "1") + " Gold)";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				//bailout for the homeless
				
				shop = true;
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
				Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
				
			} else {
				if (npc.homeless) {
					Main.npcChatText = "No cafe, no money. I need a place or we'll both go broke. Stonework Rose needs to be made of High Quality woods and signature furnature.";
					return;
				}

				Player player = Main.player[Main.myPlayer];
				playerMod modPlayer = player.GetModPlayer<playerMod>();
				if(modPlayer.recievedCafeCut) {
					switch (Main.rand.Next(4)) {
						case 0:
							Main.npcChatText = "We have not had too many sales since last you came to me. You must be patient.";
							break;
						case 2:
							Main.npcChatText = "Come back tommorow after I finished doing the maths.";
							break;
						case 3:
							Main.npcChatText = "If you're pressed for money, kill a boss or something.";
							break;
						case 4:
							Main.npcChatText = "There is no way I am your only source of income.";
							break;
					}
					
					return;
				}

				switch (Main.rand.Next(4)) {
					case 0:
						Main.npcChatText = "I know you do amazing things with your cut of the profits!";
						break;
					case 1:
						Main.npcChatText = "Thanks for all the help! Here's your cut of the profits.";
						break;
					case 2: {
							if(NPC.FindFirstNPC(NPCID.TaxCollector) > 0)
								Main.npcChatText = "The tax collector stashes some of the money for himself. I much prefer paying you directly.";
							else
								Main.npcChatText = "Our mutual benifet keeps the world turning! Your cut.";
							break;
						}
						
					case 4:
						Main.npcChatText = "Best landlord, best real estate!";
						break;
				}
				modPlayer.recievedCafeCut = true;
				Main.LocalPlayer.QuickSpawnItem(ItemID.GoldCoin);
			}
		}
		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ItemID.WizardHat);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.TopHat);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Mug);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Book);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<OwlItem>());
			nextSlot++;
		}

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toKingStatue) {
			return !toKingStatue; //inverse bool
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 0;
			randExtraCooldown = 0;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.JestersArrow; //id for wooden arrow
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness ) {
			scale = 1;
			item = ItemID.WoodenBow;
			closeness = 20;
		}
	}
}