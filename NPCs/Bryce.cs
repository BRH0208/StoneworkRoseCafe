using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System;
using System.Collections;

namespace StoneworkRoseCafe.NPCs
{
	[AutoloadHead]
	public class Bryce : ModNPC{
		public override string Texture => "StoneworkRoseCafe/NPCs/Bryce";

		public override bool Autoload(ref string name) {
			name = "Agent of Chaos";
			return mod.Properties.Autoload;
		}
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Agent of Chaos");
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
			button = Language.GetTextValue("LegacyInterface.28"); // "Shop" except translated automatically	
		}
		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				shop = true;
			}
		}
		public override void SetupShop(Chest shop, ref int nextSlot) {
			
			if(!Main.dayTime){
				shop.item[nextSlot].SetDefaults(ItemID.Obelisk);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Gravestone);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.CrossGraveMarker);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.GraveMarker);
				nextSlot++;
			}else{
				shop.item[nextSlot].SetDefaults(ItemID.CactusSword);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.CactusPickaxe);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.CactusHelmet);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.CactusBreastplate);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Chest);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.RainCoat);
				nextSlot++;
			}
			if(Main.hardMode){
				switch (Main.moonPhase) {
					case 1:
						shop.item[nextSlot].SetDefaults(ItemID.MagicMirror);
						break;
					case 3:
						shop.item[nextSlot].SetDefaults(ItemID.CloudinaBottle);
						break;
					case 5:
						shop.item[nextSlot].SetDefaults(ItemID.BandofRegeneration);
						break;
					case 7:	
						shop.item[nextSlot].SetDefaults(ItemID.HermesBoots);
						break;
					default:
						shop.item[nextSlot].SetDefaults(ItemID.JestersArrow);
						break;
				}
				if(!Main.dayTime){
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.ReaperHood);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.ReaperRobe);
					nextSlot++;
				}
			}
			
			
			//shop.item[nextSlot].SetDefaults(ItemID.BottomlessLavaBucket);
			//nextSlot++;
			if(Main.bloodMoon){
				shop.item[nextSlot].SetDefaults(ItemID.VialofVenom);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.FlaskofPoison);
				nextSlot++;
			}
			if(Main.dayTime){
				if(NPC.downedSlimeKing){
					shop.item[nextSlot].SetDefaults(ItemID.PinkGel);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.Gel);
					nextSlot++;
				}
				if(NPC.downedQueenBee){
					shop.item[nextSlot].SetDefaults(ItemID.BeeMask);
					nextSlot++;
				}
				if(NPC.downedAncientCultist){
					shop.item[nextSlot].SetDefaults(ItemID.BeetleWings);
					nextSlot++;
				}
			}else{
				int npc = NPC.FindFirstNPC(NPCID.Guide);
				if (npc>= 0) {
					shop.item[nextSlot].SetDefaults(ItemID.GuideVoodooDoll);
					nextSlot++;
				}
				npc = NPC.FindFirstNPC(NPCID.DyeTrader);
				if (npc>= 0) {
					shop.item[nextSlot].SetDefaults(ItemID.YellowDye);
					nextSlot++;
				}
			}
			if(NPC.downedBoss3){
				if(Main.dayTime){
					shop.item[nextSlot].SetDefaults(ItemID.Timer1Second);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.Timer3Second);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.Timer5Second);
					nextSlot++;
				}else{
					shop.item[nextSlot].SetDefaults(ItemID.DartTrap);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.WoodenSpike);
					nextSlot++;
				}
			}
			
			if(NPC.downedMoonlord && !Main.dayTime){
				shop.item[nextSlot].SetDefaults(ItemID.ShroomiteHelmet);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ShroomiteBreastplate);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ShroomiteLeggings);
				nextSlot++;
			}
				
			if(NPC.downedPlantBoss){
					if(Main.dayTime){
						shop.item[nextSlot].SetDefaults(ItemID.PlanteraMask);
					}else{
						shop.item[nextSlot].SetDefaults(ItemID.Seedler);
					}
					nextSlot++;
				}
			if(NPC.downedGolemBoss){
				if(!Main.dayTime){
					shop.item[nextSlot].SetDefaults(ItemID.SuperDartTrap);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.FlameTrap);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.SpikyBallTrap);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.SpearTrap);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.Spike);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.GeyserTrap);
					nextSlot++;
				}else{
					shop.item[nextSlot].SetDefaults(ItemID.LogicSensor_Liquid);
					nextSlot++;
				}
			}
			if((Main.dayTime) && (NPC.downedFishron)){
				shop.item[nextSlot].SetDefaults(ItemID.MermaidTail);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.BottomlessBucket);
				nextSlot++;
			}
			
		}
		
		public override string GetChat() {
			Main.npcChatCornerItem = ItemID.Explosives;
			ArrayList lines = new ArrayList();
			// Generic Lines
			lines.Add("Dig a hole to hell. Do it.");
			lines.Add("The statement 'Burn in hell' is much less fun when hell can be accessed easily.");
			lines.Add("Hello friend, make sure to burn in hell for me.");
			lines.Add("Death traps should be owned by the person who made them.");
			lines.Add("When in doubt, drain the ocean.");
			lines.Add("Duplicate water. Its not that hard.");
			lines.Add("Greetings Mortal. Prepare to die.");
			lines.Add("Some things do not explode, but do not panic, this is fixable");
			lines.Add("Some people do not want to explode, but do not panic, this is cureable");
			lines.Add("Dig a deathtrap under someones house. do it.");
			
			//Triggered Lines
			addLineNPC(NPCID.Golem,"I mean, I would be focusing on killing the Golem, but thats just me",lines);//Golem
			addLineNPC(NPCID.MartianSaucer,"I belive in space aliens, do you?",lines);//Space Ship
			addLineNPC(NPCID.MoonLordHead,"I swear I saw a spaceship. You can't tell me I didn't see what I did",lines);//Space Ship
			addLineNPC(NPCID.MoonLordHead,"The end is neigh! Kill the moon lord!",lines);//Moon Lord
			addLineNPC(NPCID.BrainofCthulhu,"Interesting fact, the brain of cthulu is an exposed brain, and thus, explosives work against it",lines);//Brain of Cthulu
			addLineNPC(NPCID.Plantera,"Go kill plantera. It is plant vunerable to explosives, how hard could it be",lines);//Plantera
			addLineNPC(NPCID.WallofFlesh,"I feel the Wall of Flesh is risen. I reccommend going and killing it",lines); // Wall of Flesh
			addLineNPC(NPCID.EyeofCthulhu,"Don't you want to kill the Eye of Chtulu?",lines); // Eye of Cthulu
			addLineNPC(NPCID.PartyGirl,"The party girl's parties are not nearly chaotic enough.",lines); // Party Girl
			addLineNPC(NPCID.PartyGirl,"The party girl rejected my plans for more deathtraps.",lines); // Party Girl
			addLineNPC(NPCID.PartyGirl,"Apparently increasing the explosive yield of happy grenades is frowned apon",lines); // Party Girl
			addLineNPC(NPCID.Cyborg,"I cannot fathom why the Cyborg turned down my upgrades",lines); // Cyborg
			addLineNPC(NPCID.Cyborg,"The Cyborg disproves of being turned into a trap",lines); // Cyborg
			addLineNPC(NPCID.Angler,"Fishing is boring and lame. It just takes too long",lines);//Angler
			addLineNPC(NPCID.Angler,"How does the angeler stand fishing, its soo dull.",lines);//Angler
			addLineNPC(NPCID.Angler,"The only good thing about fishing is the explosive fish",lines);//Angler
			addLineNPC(NPCID.Angler,"I firmly belive the best way to fish is with dynamite",lines);//Angler
			addLineNPC(NPCID.TravellingMerchant,"Kill the traveler and steal his hat",lines); // Traveler
			addLineNPC(NPCID.TravellingMerchant,"That traveler has a very nice hat that he drops when he dies. Just saying",lines); // Traveler
			addLineNPC(NPCID.TravellingMerchant,"Did you know that traps can kill the traveling merchant? It gives you his hat",lines); // Traveler
			addLineNPC(NPCID.GoblinTinkerer,"That goblin fellow calls himself a tinkerer and he cannot build a single improvised explosive",lines); // Goblin Tinkerer
			addLineNPC(NPCID.GoblinTinkerer,"Go tell that goblin to find a way to make everything explode.",lines); // Goblin Tinkerer
			addLineNPC(NPCID.Wizard,"The wizard is not a true wizard, he does not have magical mischief",lines); //Wizard
			addLineNPC(NPCID.Merchant,"That merchant entirely failes to sell traps",lines); // Merchant
			addLineNPC(NPCID.Merchant,"I hope the merchant will sell traps eventually.",lines); // Merchant
			addLineNPC(NPCID.Nurse,"That nurse ruins the fun of traps. How is it fun if noone gets hurt?",lines); // Nurse
			addLineNPC(NPCID.Nurse,"Why get a person to heal you when honey and statues do the job better?",lines); // Nurse
			addLineNPC(NPCID.ArmsDealer,"Why does the arms dealer not sell explosive bullets?",lines); // Arms Dealer
			addLineNPC(NPCID.ArmsDealer,"Why buy a gun when you can buy explosives",lines); // Arms Dealer
			addLineNPC(NPCID.Dryad,"I am permently banned from pranking the Dryad",lines); // Dryad
			addLineNPC(NPCID.Dryad,"Why is the dryad so apposed to random environmental destruction?",lines); // Dryad
			//addLineNPC(NPCID.TownDog,"I cannot overstate how much I love dogs",lines);//Town Dog
			//addLineNPC(NPCID.TownDog,"Isn't the town dog just adorable! Such a good dog!",lines);//Town Dog
			//addLineNPC(NPCID.TownCat,"I am not much of a cat person",lines);//Town cat
			addLineNPC(NPCID.TaxCollector,"the Tax collecter was better as a tortured soul",lines);//Tax Collector
			addLineNPC(NPCID.TaxCollector,"What in the name of sanity are taxes? How do they work?",lines);//Tax Collector
			addLineNPC(NPCID.TaxCollector,"Could you kill the Tax collecter, it would be much appreciated",lines);//Tax Collector
			addLineNPC(NPCID.TaxCollector,"I hope the tax collecter burns in hell. Again",lines);//Tax Collector
			addLineNPC(NPCID.TaxCollector,"The tax collecter was in hell for a reason.",lines);//Tax Collector
			addLineNPC(NPCID.Guide,"Why is the Guide alive",lines); // Guide
			addLineNPC(NPCID.Guide,"If you are doing things correctly, the guide should be dead",lines);// Guide
			addLineNPC(NPCID.Guide,"I am not anti-guide, I am pro-suffering",lines);// Guide
			addLineNPC(NPCID.Guide,"Throw a guide voodoo doll in the lava of hell. Trust me",lines);// Guide
			addLineNPC(NPCID.Guide,"The guide should suffer and burn",lines);// Guide
			addLineNPC(NPCID.Guide,"The guide has lived far too long",lines);// Guide
			addLineNPC(NPCID.Guide,"You should go through guides like explosions goes through hopes and dreams",lines);// Guide
			addLineNPC(NPCID.Guide,"The guide deserves to suffer",lines);// Guide
			addLineNPC(NPCID.Clothier,"I wonder why the clothier stopped being old and mysterious and started being boring",lines);//Clothier
			addLineNPC(NPCID.Demolitionist,"The demolitionist and I are good friends",lines);//Demolitionist
			addLineNPC(NPCID.Demolitionist,"The demolitionist's explosives make for great traps",lines);//Demolitionist
			addLineNPC(NPCID.Demolitionist,"A nearly unlimited supply of explosives has not nearly bancrupted me",lines);//Demolitionist
			addLineNPC(NPCID.Demolitionist,"I wonder why the demolitionist isn't more popular",lines);//Demolitionist
			addLineNPC(NPCID.DyeTrader,"I wish the dye trader could find a way to dye explosives, make the explosions even more glorious",lines);//Dye Trader
			addLineNPC(NPCID.DyeTrader,"The dye trader is a bit pointless. I don't need dye to paint everything red.",lines);//Dye Trader
			addLineNPC(NPCID.DyeTrader,"The dye trader is a bit pointless. I don't need dye to paint everything red.",lines);//Dye Trader
			addLineNPC(NPCID.DD2Bartender,"What is the point of a tavern keeper, doesn't the tavern keep itself?",lines);//Tavern Keeper
			addLineNPC(NPCID.Stylist,"Why does the stylist not sell fasionable traps?",lines);//Stylist
			addLineNPC(NPCID.Stylist,"Why does the stylist not sell stylish explosives?",lines);//Stylist
			addLineNPC(NPCID.Stylist,"Why does the stylist not sell fasionable explosives?",lines);//Stylist
			addLineNPC(NPCID.Stylist,"Why does the stylist not sell stylish traps?",lines);//Stylist
			addLineNPC(NPCID.WitchDoctor,"The witchdocter is the best kind of doctor",lines);//Witchdoctor
			addLineNPC(NPCID.Mechanic,"Isn't the mechanic just the best?",lines);//Mechanic
			addLineNPC(NPCID.Mechanic,"Nothing is better than wire and actuators",lines);//Mechanic
			addLineNPC(NPCID.Mechanic,"Wire is worth every penny",lines);//Mechanic
			addLineNPC(NPCID.Mechanic,"I need money for more wire",lines);//Mechanic
			addLineNPC(NPCID.Mechanic,"The mechanic is essential to good buisness. No trap works without wires",lines);//Mechanic
			addLineNPC(NPCID.Mechanic,"Wire is the best item in the game",lines);//Mechanic
			addLineNPC(NPCID.Mechanic,"Wire from the Mechanic and traps can make for the perfect traps",lines);//Mechanic
			if(WorldGen.crimson){
				lines.Add("Fear the Crimson Chasams. The Crimson is always a dangerous place");
				lines.Add("I would rather walk through hell than through the crimson");
				lines.Add("The crimson is terrifying, hellfire is always preferable");
			}
			else{
				lines.Add("The ever-expanding corruption will claim everything. We have to be ready");
				lines.Add("I would rather walk through hell than through the corruption");
				lines.Add("The corruption is terrifying, hellfire is always preferable");
			}
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
