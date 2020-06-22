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
			NPCID.Sets.AttackTime[npc.type] = 30;
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
					return "Adam";
				case 1:
					return "Sam";
				case 2:
					return "John";
				case 3:
					return "Hunter";
				default:
					return "Jacob";
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
			ArrayList lines = new ArrayList();
			// Generic Lines
			lines.Add("Deadfall traps are highly effective, do try one");
			lines.Add("If you want to start a fire, you need some form of tinder, fuel and spark");
			lines.Add("Steel wool is great for holding a spark, or as tinder");
			lines.Add("Always know your location, keep a sense of direction and landmarks");
			lines.Add("Undead and Megafauna can be delt with with pit-traps");
			lines.Add("When finding a spot for rest, find high ground. Most dangerous creatures cannot fly");
			lines.Add("Trapping pits are great for luring dangerous creatures");
			lines.Add("Be ready for anything, because it will be ready for you");
			lines.Add("The best encounter is one where you remain un-noticed. Keep distance");
			lines.Add("Keep a burning campfire nearby for warmpth and light.");
			lines.Add("Nothing allows you to recover better than the camp's campfire");
			
			
			
			//Creature hunting lines
			lines.Add("Bunnies are no threat, to hunt: Take out from a distance or use a simple trap.");
			lines.Add("A small snare is all you need to catch small mammels");
			lines.Add("Birds can be cooked, granting enough food to feed someone");
			lines.Add("The murder of harmless wildlife is not a good outcome.");
			lines.Add("Treat wildlife well: With dignity and respect");
			lines.Add("We are encroching on creatures homes, be kind and respectfull");
			lines.Add("Live birds can be sold for a few silver, blue-jays and cardinals generally worth 50% more");
			lines.Add("Ducks and Mallads are peacefull and healthy parts of an ecosystem.");
			lines.Add("Duck tasts great roasted.");
			lines.Add("In my opinion, it is always duck season");
			lines.Add("Fireflies give of light, and can also be used as fishing bait. They are an easy capture");
			lines.Add("If you capture a frog, you can make Sauteed Frog Legs, a fun meal");
			lines.Add("Frogs are a possible source of food, they are passive and captured easily");
			lines.Add("Do not hunt owls for food. They are harmless, and not easy to cook. They are also easy to capture");
			lines.Add("Seagulls are a passive creature found near the oceans. They are not great food sources, but are easy to capture");
			lines.Add("Near water and in forrests you can find turtles. They are harmless, and make for great pets!");
			lines.Add("Dragonflies are pretty, I used to find them all over camp");
			lines.Add("Golfish are nice pets, but I would reccomend not naming any Silgar"); //DND waterdeep reference
			
			//Enimies
			lines.Add("Slimes are weak enimies, all acting the same. Their bounces are predictable, they can be stopped by a small pit and you are safe behind a wall"); 
			
			//Bosses
			if(!NPC.downedBoss3 && NPC.downedBoss2){
				lines.Add("Skeletron is immune to alot, but it is not immune to the frost effect of frost arrows");
				lines.Add("Skeletron's head is incredibly strong while it still has its hands, target them first");
				lines.Add("Skeletron can fire homing skulls once one of its hands are defeated, so defeat both hands around the same time");
				lines.Add("Mobility is key to avoid Skeletron's spin attack. Keep moving, preferably from platforms, campfires and ropes setup prior to the fight");
				lines.Add("For hunting Skeletron, I reccomend the tendon or demon bow with frost/jester arrows in a special made arena");
			}
			if(!NPC.downedBoss1){
				lines.Add("For hunting the Eye of Chuthulu, being prepared is key. Take out the servants, and dodge the eye. Once it is in its second form, dodging is key as it becomes much more of a glass cannon");
			} 
			if(!NPC.downedMechBoss1 && Main.hardMode){
				lines.Add("Againt the Destroyer, a stormbow is a must. Combine this with holy arrows for an even easier fight. Failing that, any area-of-effect or piercing weapon will do");
				lines.Add("When hunting the destroyer, target the probes, they give health and will interfere with the fight");
				lines.Add("You can run from the destroyer, but you cannot hide, it will follow you to the end of the world");
				lines.Add("Avoid being trapped by the destroyers body, if you ever lose mobility the head of the destroyer can vivisect you");
				lines.Add("To hunt the destroyer, target the head if possible, it is signifigantly weaker, and where the head goes the body follows");			
			}
			if(!NPC.downedMechBoss2 && Main.hardMode){
				lines.Add("The twins are powerfull foes, expecially if both are in their second form. Try to eleminate one fully before damaging the other.");
				lines.Add("For hunting the twins, use a stormbow and holy arrows. Always be prepared for whatever fight you pick.");
			}
			if(!NPC.downedMechBoss3 && Main.hardMode){
				lines.Add("When hunting skeletron prime, keep mobility. A single spin attack can end the hunt.");
				lines.Add("While defeating the arms of skeletron prime are technically optional, defeating them makes the rest of the fight much much easier");
				lines.Add("Occasionally using ichor arrows on skeletron prime will help to get over his incredible armor");
			}
			if(NPC.downedBoss3 && !Main.hardMode){
				lines.Add("Before hunting the wall of flesh, make sure you are prepared. The world is much more deadly once it is dead");
				lines.Add("The wall of flesh should be fought on a long platform across hell, giving you enough time to fight it. Keeping distance from the wall is key");
				lines.Add("While hunting the wall of flesh, take out the hungery, which are a source of health and while they are alive the wall of flesh has higher defence");
				lines.Add("When hunting the wall of flesh, target the eyes, they have lower defence.");
			}
			if(!NPC.downedPlantBoss && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3){
				lines.Add("When hunting Plantera, stay underground: It gets enraged if not underground.");
				lines.Add("Before taking on Plantera, carve a large arena so you can remain mobile");
			}
			if(NPC.downedPlantBoss && !NPC.downedGolemBoss){
				lines.Add("It is reccomended you disarm the jungle temple's traps, you can use them in your own trapping");
				lines.Add("When hunting the Golem, make sure to have shroomite armor, it is surprisingly easy to obtain, and is incredibly strong");
				lines.Add("Chlorophite shotbows are great for hunting the golem");
				lines.Add("In the first phase of the Golem fight, dodge the fire projectiles and go for the arms first.");
			}
			if(NPC.downedGolemBoss && !NPC.downedAncientCultist){
				lines.Add("For hunting cultists, Bring a Tsunami if you have it. It comes from fishron.");
				lines.Add("For hunting cultists, It is imperative you do not hit the fake versions, they summon strong enimies. Fakes look different with dead eyes and no strip on their hoods");
				lines.Add("Before hunting cultists, Be ready for the lunar event");
			}
			if(NPC.downedAncientCultist && !NPC.downedMoonlord){
				lines.Add("The lord of the moon is the most powerfull foe you could encoutner. Approach with caution. The tounge prevents healing, and his deathray can kill most anyone");	
			}
			
			//Triggered Lines
			addLineNPC(NPCID.PartyGirl,"I don't get the party girl, how can you throw a party with the world as it is?",lines); // Party Girl
			addLineNPC(NPCID.PartyGirl,"With how the world is, I can hardly understand the party girls desire to party.",lines); // Party Girl
			addLineNPC(NPCID.PartyGirl,"The party girl would not survive five minutes in the wild",lines); // Party Girl
			addLineNPC(NPCID.Cyborg,"That Cyborg should learn to give up technology",lines); // Cyborg
			addLineNPC(NPCID.Cyborg,"Tell the Cyborg that rocket-launchers are not practical for hunting",lines); // Cyborg
			addLineNPC(NPCID.Angler,"The angler is a fantastic fishing partner",lines);//Angler
			addLineNPC(NPCID.Angler,"I was talking to the angler about lures, he is very knowledgeable",lines);//Angler
			addLineNPC(NPCID.Angler,"If I could pick a person to survive on a deserted island with, it would be the Angler ",lines);//Angler
			addLineNPC(NPCID.Angler,"That angler knows how to be self-sufficent",lines);//Angler
			addLineNPC(NPCID.TravellingMerchant,"That Traveling Merchant knows how to live; constantly on the move",lines); // Traveler
			addLineNPC(NPCID.TravellingMerchant,"For someone who travels, the traveling merchant knows very little about trapping",lines); // Traveler
			addLineNPC(NPCID.TravellingMerchant,"I always love to meet travelers: people who wander",lines); // Traveler
			addLineNPC(NPCID.GoblinTinkerer,"I do not need my weapons 'Modified', they work fine as-is",lines); // Goblin Tinkerer
			addLineNPC(NPCID.GoblinTinkerer,"I am not having a goblin mess with my items",lines); // Goblin Tinkerer
			addLineNPC(NPCID.Wizard,"No amount of magic vodoo crap will compare to a good bow",lines); //Wizard
			addLineNPC(NPCID.Merchant,"That merchant has what you need: Rope, flares, Sickle, Rope, Marshmallows and bugnets!",lines); // Merchant
			addLineNPC(NPCID.Merchant,"I hope the merchant won't run out of rope!",lines); // Merchant
			addLineNPC(NPCID.Merchant,"The merchant is a fantastic supplier of survival gear",lines); // Merchant
			addLineNPC(NPCID.Merchant,"Did you know the merchant sells torches, flares and rope! He has got everything!",lines); // Merchant
			addLineNPC(NPCID.Merchant,"Me and the Merchant love to make smores!",lines); // Merchant
			addLineNPC(NPCID.Merchant,"The merchant sells a bug-net. Most bugs can be used as fishin' bait",lines);
			addLineNPC(NPCID.Nurse,"When Injured, seek medical attention, the nurse can provide that",lines); // Nurse
			addLineNPC(NPCID.Nurse,"The great thing about the nurse it is allows us to remain safe",lines); // Nurse
			addLineNPC(NPCID.ArmsDealer,"Boom-sticks are loud and impractical, use bows not guns",lines); // Arms Dealer
			addLineNPC(NPCID.ArmsDealer,"Guns may seem practical, but bullets are limited",lines); // Arms Dealer
			addLineNPC(NPCID.ArmsDealer,"I can see hunting with a shotgun, but the arms dealers weapons are bit much",lines); // Arms Dealer
			addLineNPC(NPCID.ArmsDealer,"Hunting bows are better than hunting rifles, but I could see why the Arms dealer sells them",lines); // Arms Dealer
			addLineNPC(NPCID.Dryad,"The dryad has such an interesting perspective on nature",lines); // Dryad
			addLineNPC(NPCID.Dryad,"Why is the dryad so apposed to hunting, it is very 'natural'?",lines); // Dryad
			//addLineNPC(NPCID.TownDog,"Dogs make for the best companions",lines);//Town Dog
			//addLineNPC(NPCID.TownDog,"Isn't the dog just the best",lines);//Town Dog
			//addLineNPC(NPCID.TownCat,"The cat is great for dealing with mice",lines);//Town cat
			addLineNPC(NPCID.TaxCollector,"Who the hell collects taxes? What are taxes? Why are taxes?",lines);//Tax Collector
			addLineNPC(NPCID.TaxCollector,"It is very hard to be self-sufficent when the tax collecter keeps taking my money?",lines);//Tax Collector
			addLineNPC(NPCID.TaxCollector,"The Tax collecter makes me wish we all kept to the barter system",lines);//Tax Collector
			addLineNPC(NPCID.TaxCollector,"The Tax collecter needs to chill",lines);//Tax Collector
			addLineNPC(NPCID.TaxCollector,"Lets see how much his 'taxes' save him from dying in the jungle",lines);//Tax Collector
			addLineNPC(NPCID.Guide,"Always keep your guides close!",lines); // Guide
			addLineNPC(NPCID.Guide,"Trust those which lead, trust the guide",lines);// Guide
			addLineNPC(NPCID.Guide,"The guide has great advice, but his survival skills are lacking",lines);// Guide
			addLineNPC(NPCID.Clothier,"Having a clothier is nice, clothing must match the enviorment... but he is a bit too attached to modern conviences",lines);//Clothier
			addLineNPC(NPCID.Demolitionist,"Explosive are dangerous, and we should keep our distance from the demolitionist",lines);//Demolitionist
			addLineNPC(NPCID.Demolitionist,"The demolitionist needs to stop reccomending landmines for hunting",lines);//Demolitionist
			addLineNPC(NPCID.DyeTrader,"Why buy dyes from the Dye trader when you can make your own?",lines);//Dye Trader
			addLineNPC(NPCID.DyeTrader,"The dye trader is a bit pointless. If you really want dye, use yellow marigold",lines);//Dye Trade
			addLineNPC(NPCID.DyeTrader,"I love painting, but I am not going to pay for dye",lines);//Dye Trade
			addLineNPC(NPCID.DD2Bartender,"Taverns make for a nice 'home base' to return to",lines);//Tavern Keeper
			addLineNPC(NPCID.Stylist,"The stylist would have you waste time decorating yourself",lines);//Stylist
			addLineNPC(NPCID.Stylist,"Many of the stylist's styles are not practical",lines);//Stylist
			addLineNPC(NPCID.WitchDoctor,"The witchdocter does not seem to know first aid, but I can respect his practices",lines);//Witchdoctor
			addLineNPC(NPCID.Mechanic,"the mechanics mechanims makes people reliant and stupid?",lines);//Mechanic
			addLineNPC(NPCID.Mechanic,"The mechanics wrench does not compare to a good bow",lines);//Mechanic
			addLineNPC(NPCID.Mechanic,"You can see how '''usefull''' mechanical systems are, the mechanic got themselves trapped in the dunguon",lines);//Mechanic
			addLineNPC(NPCID.Mechanic,"Do not spend all of your money on more of the mechanics wire!",lines);//Mechanic
			if(WorldGen.crimson){
				lines.Add("When in the crimson, bring rope, it helps to get out of the crimson chasms");
				lines.Add("The crimson is full of dangerous enimes, keep your distance. I reccomend digging pit traps");
				lines.Add("If you make camp in the crimson, put yourself high in air in a contained box. while crimeras can fly, they cannot go through a well made shelter");
				lines.Add("In the crimson, you will find face monsters. They are slow, but aren't knocked back by strong hits");
				lines.Add("Crimera's are a threat in pacts, but they are harmless at enough distance. Pick them off with arrows");
				lines.Add("Crimosn blood crawlers are not a threat above ground, but below they are very dangerous");
				if(Main.hardMode){
					lines.Add("In the crimson, avoid mimics at all costs. They are much more powerfull than you may expect");
					lines.Add("Crimson Herplings are a very dangerous foe. They are fast, deadly and hart to push back. They cannot jump high, so use rope to your advantage");
					lines.Add("In the crimson, avoid mimics at all costs. They are much more powerfull than you may expect");
					lines.Add("Floaty Grosses are enimies you can find in the crimson. They are weak, but can fly through walls. If they hit you, you are more vunerable to other creatures");
					lines.Add("Ichor Stickers are bulky, they don't go down easy. They also use ichor that melts armor. Stay light and manuverable, it is slow big and bulky. Stay in cover");
					lines.Add("Staying light and manuverable is needed to survive Ichor Stickers");			
					lines.Add("Crimson slimes are one of the eaisier crimson prey, acting like normal slimes, just with more health.");
					lines.Add("Slime-slaying weapons work wonders against Crimson Slimes");
					lines.Add("Cursed axes are an interesting prey, pin them with arrows. They can go through walls");	
					lines.Add("Before you enter the crimson, be prepared. Bring a well made, high quality, repeating crossbow, failing that, a nice hunting shotgun.");
				}else{
					if(!NPC.downedBoss2 && NPC.downedBoss1){
						lines.Add("For fighting Cthulu's brain, cover the area in rope. Manuverability is your friend. Shoot down the creepers from distance.");
					}
					lines.Add("Before you enter the crimson, be prepared. Bring a strong bow, gold or plantinum. Frostburn arrows are great");
				}
			}else{
				lines.Add("The corruption can corrupt critters. This makes them stronger and violent. ");
				lines.Add("Corrupted bunnies can still be delt with easily, despite their corrupted status");
				lines.Add("Eater of souls can be hunted for extremely filling burgers. I don't understand it either");
				lines.Add("Corrupted goldfish do NOT make for good pets. They are like piranas, but worse. Watch the water before entering");
				lines.Add("When walking through corrupted lands, watch the ground for Devourers. They are tunneling enimies. Splash damage is devistating, flails work well too");
				lines.Add("To hunt devourers, stay mobile. Flails and splash damage do well against it");
				if(!NPC.downedBoss2 && NPC.downedBoss1){
					lines.Add("The Eater of worlds is a powerfull prey. Piercing weapons and area-of-effect weapons can be used to great effect. Most extra-arrows hit.");
					lines.Add("Against the Eater of Worlds, target the head and tail. This stops splitting");
					lines.Add("Each part of the Eater of World's body follows the head, as long as you avoid the head, you can attack the same area repeatedly with ease");
					lines.Add("When you destroy one of the Eater of World's heads, it is slowed signifigantly. Having greater manuverability that your target is key to success");
				}
				lines.Add("Before fighting in the corruption, prepare. You need good weapons to defend yourself");
				lines.Add("When approaching the corruption, bring rope. It is usefull for manuvering");
				if(Main.hardMode){
					lines.Add("Do not underestimate a Corrupter. They are strong, and can make you weaker to other creatures. Keep cover from the projectiles");
					lines.Add("Corrupt slimes are easily predictable, acting like normal slimes. Slime-slaying weapons will slaughter them");
					lines.Add("Slimer is always a fun prey, they fly around like bats, you can knock them out of the sky, then they attack like a normal slime");
					lines.Add("Cursed arrows are great against world feeders");
					lines.Add("World Feeders can be destroyed like any other worm. Hit with piercing, area of effect or debuffs.");
					lines.Add("Inside of corrupted deserts, you can find corrupted mummies that effect debuffs");					
				}
			}
			return (string) lines[Main.rand.Next(lines.Count)];
		}
		public override bool CanGoToStatue(bool toKingStatue) {
			return true;
		}
		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			if(NPC.downedFishron){
				damage = 60;
			}else if(Main.hardMode){
				damage = 38;
			}else if(NPC.downedBoss3){
				damage = 31;
			}else if(NPC.downedBoss1){
				if(WorldGen.crimson){
					damage = 19;
				}else{
					damage = 14;
				}
			}else{
				damage = 4
			}
			knockback = 100f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 1;
			randExtraCooldown = 1;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = 	1;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 1f;
			randomOffset = 1f;
		}
		
		
		
	}
	
	
}
