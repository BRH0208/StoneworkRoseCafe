using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using StoneworkRoseCafe.Items;
using StoneworkRoseCafe.Projectiles;
using StoneworkRoseCafe.Tiles;
using System;
using System.Collections;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace StoneworkRoseCafe.NPCs
{
	[AutoloadHead]
	public class Hunter : ModNPC{
		public override string Texture => "StoneworkRoseCafe/NPCs/Hunter";
		
		public override bool Autoload(ref string name) {
			name = "Hunter";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hunter");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}
		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}
		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}

				foreach (Item item in player.inventory) {
					if (item.type == 267){
						return true;
					}
				}
			}
			return false;
		}
		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "Gerald Fitz";
				case 1:
					return "John Harrison";
				case 2:
					return "Bryce Robert Hawken";
				case 3:
					return "Lionheart";
				default:
					return "Satan";
			}
		}
		/*
		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ItemType<ExampleItem>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<EquipMaterial>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<BossItem>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ExampleWorkbench>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ExampleChair>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ExampleDoor>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ExampleBed>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ExampleChest>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<ExamplePickaxe>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<ExampleHamaxe>());
			nextSlot++;
			if (Main.LocalPlayer.HasBuff(BuffID.Lifeforce)) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleHealingPotion>());
				nextSlot++;
			}
			if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>().ZoneExample && !GetInstance<ExampleConfigServer>().DisableExampleWings) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleWings>());
				nextSlot++;
			}
			if (Main.moonPhase < 2) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleSword>());
				nextSlot++;
			}
			else if (Main.moonPhase < 4) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleGun>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.ExampleBullet>());
				nextSlot++;
			}
			else if (Main.moonPhase < 6) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleStaff>());
				nextSlot++;
			}
			else {
			}
			// Here is an example of how your npc can sell items from other mods.
			var modSummonersAssociation = ModLoader.GetMod("SummonersAssociation");
			if (modSummonersAssociation != null) {
				shop.item[nextSlot].SetDefaults(modSummonersAssociation.ItemType("BloodTalisman"));
				nextSlot++;
			}

			if (!Main.LocalPlayer.GetModPlayer<ExamplePlayer>().examplePersonGiftReceived && GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList != null)
			{
				foreach (var item in GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList)
				{
					if (item.IsUnloaded)
						continue;
					shop.item[nextSlot].SetDefaults(item.Type);
					shop.item[nextSlot].shopCustomPrice = 0;
					shop.item[nextSlot].GetGlobalItem<ExampleInstancedGlobalItem>().examplePersonFreeGift = true;
					nextSlot++;
					// TODO: Have tModLoader handle index issues.
				}	
			}
		}
		*/
		private void addLineNPC(int npcId, string line, ArrayList lines){
			int npc = NPC.FindFirstNPC(npcId);
			if (npc>= 0) {
				lines.Add(line);
			}
		}
		
		public override void SetChatButtons(ref string button, ref string button2) {
			button2 = "";
			button = "Slayer Weapons";
		}
		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			shop = false;
			if (firstButton) {
				Main.playerInventory = true;
				Main.npcChatText = "";
				GetInstance<StoneworkRoseCafe>().HunterUserInterface.SetState(new UI.HunterUI());
				
			}
		}
		
		
		public override string GetChat() {
			Main.npcChatCornerItem = ItemID.Explosives;
			ArrayList lines = new ArrayList();
			// Generic Lines
			lines.Add("TEMP");
			return (string) lines[Main.rand.Next(lines.Count)];
		}
		public override bool CanGoToStatue(bool toKingStatue) {
			return true;
		}
		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 250;
			knockback = 100f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 1;
			randExtraCooldown = 1;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = 	143;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 1f;
			randomOffset = 1f;
		}
		
		
		
	}
	
	
}
