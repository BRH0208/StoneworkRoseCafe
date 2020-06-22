using StoneworkRoseCafe;
using StoneworkRoseCafe.NPCs;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Items
{
	public class SlayingItem : GlobalItem
	{
		public string hated;
		int[] slimesIds= { NPCID.BigSlimedZombie, NPCID.SmallSlimedZombie, NPCID.BigCrimslime, NPCID.LittleCrimslime, NPCID.JungleSlime, NPCID.YellowSlime, NPCID.RedSlime, NPCID.PurpleSlime, NPCID.BlackSlime, NPCID.BabySlime, NPCID.Pinky, NPCID.GreenSlime, NPCID.Slimer2, NPCID.Slimeling, NPCID.BlueSlime, NPCID.MotherSlime, NPCID.LavaSlime, NPCID.DungeonSlime, NPCID.CorruptSlime, NPCID.Slimer, NPCID.IlluminantSlime, NPCID.IceSlime, NPCID.Crimslime, NPCID.SpikedIceSlime, NPCID.SlimedZombie, NPCID.SpikedJungleSlime, NPCID.UmbrellaSlime, NPCID.RainbowSlime, NPCID.SlimeMasked, NPCID.SlimeRibbonWhite, NPCID.SlimeRibbonYellow, NPCID.SlimeRibbonGreen, NPCID.SlimeRibbonRed, NPCID.ArmedZombieSlimed, NPCID.SlimeSpiked, NPCID.SandSlime/*NPCID.QueenSlimeMinionBlue, NPCID.QueenSlimeMinionPink, NPCID.QueenSlimeMinionPurple*/};
		int[] undeadIds = { NPCID.BigSlimedZombie, NPCID.BigTwiggyZombie, NPCID.SmallTwiggyZombie, NPCID.BigSwampZombie, NPCID.SmallSwampZombie, NPCID.SmallSlimedZombie, NPCID.BigPincushionZombie, NPCID.SmallPincushionZombie, NPCID.BigBaldZombie, NPCID.SmallBaldZombie, NPCID.BigZombie, NPCID.SmallZombie, NPCID.BigBoned, NPCID.Zombie, NPCID.AngryBones, NPCID.DarkCaster, NPCID.CursedSkull, NPCID.UndeadMiner, NPCID.Tim, NPCID.DoctorBones, NPCID.TheGroom, NPCID.Mummy, NPCID.DarkMummy, NPCID.LightMummy, NPCID.Wraith, NPCID.SkeletonArcher, NPCID.ZombieEskimo, NPCID.SwampThing, NPCID.UndeadViking, NPCID.RuneWizard, NPCID.ArmoredViking, NPCID.FemaleZombie, NPCID.HeadacheSkeleton, NPCID.MisassembledSkeleton, NPCID.PantlessSkeleton, NPCID.ZombieRaincoat, NPCID.Eyezor, NPCID.Reaper, NPCID.ZombieMushroom, NPCID.ZombieMushroomHat, NPCID.RustyArmoredBonesAxe, NPCID.RustyArmoredBonesFlail, NPCID.RustyArmoredBonesSword, NPCID.RustyArmoredBonesSwordNoArmor, NPCID.BlueArmoredBones, NPCID.BlueArmoredBonesMace, NPCID.BlueArmoredBonesNoPants, NPCID.BlueArmoredBonesSword, NPCID.Necromancer, NPCID.NecromancerArmored, NPCID.DiabolistRed, NPCID.DiabolistWhite, NPCID.BoneLee, NPCID.SkeletonSniper, NPCID.TacticalSkeleton, NPCID.SkeletonCommando, NPCID.AngryBonesBig, NPCID.AngryBonesBigMuscle, NPCID.AngryBonesBigHelmet, NPCID.ZombieDoctor, NPCID.ZombieSuperman, NPCID.ZombiePixie, NPCID.SkeletonTopHat, NPCID.SkeletonAstonaut, NPCID.SkeletonAlien, NPCID.ZombieXmas, NPCID.ZombieSweater, NPCID.ZombieElf, NPCID.ZombieElfBeard, NPCID.ZombieElfGirl, NPCID.ArmedZombie, NPCID.ArmedZombieEskimo, NPCID.ArmedZombiePincussion, NPCID.ArmedZombieSlimed, NPCID.ArmedZombieSwamp, NPCID.ArmedZombieTwiggy, NPCID.ArmedZombieCenx, NPCID.BoneThrowingSkeleton, NPCID.BoneThrowingSkeleton2, NPCID.BoneThrowingSkeleton3, NPCID.BoneThrowingSkeleton4, NPCID.DesertGhoul, NPCID.DesertGhoulCorruption, NPCID.DesertGhoulCrimson, NPCID.DesertGhoulHallow, NPCID.TheBride, /*NPCID.ZombieMerman, NPCID.TorchZombie, NPCID.ArmedTorchZombie, NPCID.BloodMummy, NPCID.PirateGhost */};
		int[] skyIds = { NPCID.Harpy, NPCID.WyvernHead, NPCID.WyvernLegs, NPCID.WyvernBody, NPCID.WyvernBody2, NPCID.WyvernBody3, NPCID.WyvernTail,/*NPCID.GiantFlyingAntlion, NPCID.SporeBat,*/ NPCID.CaveBat,NPCID.JungleBat,NPCID.Hellbat,NPCID.GiantBat,NPCID.IlluminantBat, NPCID.IceBat, NPCID.Lavabat,NPCID.VampireBat, NPCID.GraniteFlyer,NPCID.FlyingAntlion, /*NPCID.EyeballFlyingFish,*/ NPCID.Bee, NPCID.BeeSmall,NPCID.Creeper,NPCID.GiantCursedSkull ,NPCID.DungeonSpirit,NPCID.DemonEyeOwl,NPCID.DemonEyeSpaceship,NPCID.DemonEye2,NPCID.PurpleEye2,NPCID.GreenEye2,NPCID.DialatedEye2,NPCID.SleepyEye2,NPCID.CataractEye2,NPCID.DemonEye,NPCID.Demon,NPCID.VoodooDemon,NPCID.Drippler , NPCID.BigEater ,NPCID.LittleEater,NPCID.GiantFlyingFox ,NPCID.FlyingFish ,NPCID.FlyingSnake,NPCID.MeteorHead,NPCID.BigCrimera,NPCID.LittleCrimera, NPCID.Crimera,NPCID.Ghost/*,NPCID.PirateGhost*/,NPCID.BigHornetStingy,NPCID.LittleHornetStingy,NPCID.BigHornetSpikey,NPCID.LittleHornetSpikey,NPCID.BigHornetLeafy,NPCID.LittleHornetLeafy,NPCID.BigHornetHoney,NPCID.LittleHornetHoney,NPCID.BigHornetFatty,NPCID.LittleHornetFatty,NPCID.GiantMossHornet,NPCID.BigMossHornet,/*NPCID.LittleMossHornet,*/NPCID.TinyMossHornet,NPCID.BigStinger,NPCID.LittleStinger,NPCID.Hornet,NPCID.MossHornet,NPCID.HornetFatty,NPCID.HornetHoney,NPCID.HornetLeafy,NPCID.HornetSpikey,NPCID.HornetStingy,NPCID.VortexHornetQueen,NPCID.VortexHornet,NPCID.Raven,NPCID.Vulture,NPCID.AngryNimbus ,NPCID.MothronSpawn, NPCID.NebulaHeadcrab,NPCID.Corruptor,NPCID.CrimsonAxe,NPCID.DungeonSpirit,NPCID.EnchantedSword,NPCID.Flocko,NPCID.IchorSticker,NPCID.MartianProbe,NPCID.Moth,NPCID.NebulaBrain,NPCID.PigronCorruption ,NPCID.PigronHallow,NPCID.PigronCrimson,NPCID.Poltergeist,NPCID.Reaper,NPCID.ShadowFlameApparition,NPCID.Wraith,NPCID.VampireBat,NPCID.Pixie,NPCID.Parrot,NPCID.MartianDrone,NPCID.IceElemental,NPCID.Gastropod,NPCID.FloatyGross,NPCID.ElfCopter,NPCID.CursedHammer,NPCID.SolarCrawltipedeHead,NPCID.SolarCrawltipedeBody,NPCID.SolarCrawltipedeTail,/*NPCID.TombCrawlerHead,NPCID.TombCrawlerBody,TombCrawlerTail,*/NPCID.SolarFlare,/*NPCID.BloodEelHead, NPCID.BloodEelBlody, NPCID.BloodEelTail,*/NPCID.SolarCorite};
        int[] waterIds = { NPCID.Goldfish, NPCID.CorruptGoldfish, NPCID.Piranha, NPCID.BlueJellyfish, NPCID.PinkJellyfish, NPCID.Shark, NPCID.Crab, NPCID.AnglerFish, NPCID.GreenJellyfish, NPCID.SeaSnail, NPCID.Squid, NPCID.FlyingFish, /*NPCID.GoldfishWalker,*/ NPCID.BloodFeeder, NPCID.BloodJelly, NPCID.GiantShelly, NPCID.GiantShelly2/*NPCID.GoldGoldfish, NPCID.GoldGoldfishWalker, NPCID.SeaTurtle, NPCID.Seahorse, NPCID.GoldSeahorse*/ };
		int[] hellIds = { NPCID.BoneSerpentHead, NPCID.BoneSerpentBody, NPCID.BoneSerpentTail, NPCID.LavaSlime, NPCID.Hellbat, NPCID.Demon, NPCID.VoodooDemon, NPCID.Lavabat, NPCID.RedDevil, NPCID.HellArmoredBones, NPCID.HellArmoredBonesSpikeShield, NPCID.HellArmoredBonesMace, NPCID.HellArmoredBonesSword, NPCID.DemonTaxCollector, /*NPCID.Lavafly*/ };
		int[] corruptionIds = { NPCID.BigEater, NPCID.LittleEater, NPCID.EaterofSouls, NPCID.CorruptBunny, NPCID.CorruptGoldfish, NPCID.CorruptSlime, NPCID.Corruptor, NPCID.SeekerHead, NPCID.SeekerBody, NPCID.SeekerTail, NPCID.Clinger, /*NPCID.BigMimicCorruption,*/ NPCID.DesertGhoulCorruption, NPCID.SandsharkCorrupt };
		int[] crimsonIds = { NPCID.BigCrimslime, NPCID.LittleCrimslime, NPCID.BigCrimera, NPCID.LittleCrimera, NPCID.Crimera, NPCID.Herpling, NPCID.FaceMonster, NPCID.FloatyGross, NPCID.Crimslime, NPCID.BloodCrawler, NPCID.BloodCrawlerWall, NPCID.BloodFeeder, NPCID.BloodJelly, NPCID.IchorSticker, NPCID.CrimsonBunny, NPCID.CrimsonGoldfish, NPCID.CrimsonPenguin, NPCID.BigMimicCrimson, NPCID.DesertGhoulCrimson, NPCID.SandsharkCrimson,/* NPCID.BloodMummy */};
		int[] bloodIds = { NPCID.TheGroom, NPCID.TheBride, NPCID.BloodZombie, /*NPCID.BloodSquid,NPCID.BloodEelHead, NPCID.BloodEelBody, NPCID.BloodEelTail,*/NPCID.CorruptBunny ,/*NPCID.CorruptCorruptGoldfish,*/NPCID.CorruptPenguin, NPCID.CrimsonBunny, NPCID.CrimsonGoldfish, NPCID.CrimsonPenguin,/*NPCID.EyeballFlyingFish, NPCID.ZombieMerman,*/NPCID.ChatteringTeethBomb, NPCID.Clown,/*NPCID.GoblinShark*/};
		int[] snowIds = { NPCID.SnowmanGangsta, NPCID.MisterStabby, NPCID.SnowBalla, NPCID.IceSlime, NPCID.Penguin, NPCID.PenguinBlack, NPCID.IceBat, NPCID.IceTortoise, NPCID.Wolf, NPCID.ZombieEskimo, NPCID.CorruptPenguin, NPCID.SpikedIceSlime, NPCID.SnowFlinx, NPCID.IcyMerman, NPCID.ZombieXmas, NPCID.ZombieSweater, NPCID.ZombieElf, NPCID.ZombieElfBeard, NPCID.ZombieElfGirl, NPCID.PresentMimic, NPCID.ElfCopter, NPCID.Nutcracker, NPCID.NutcrackerSpinning, NPCID.ElfArcher, /*NPCID.ArmedZombieEskimo,*/ /*NPCID.IceMimic,*/ NPCID.IceGolem };
		int[] piratesIds = {NPCID.Parrot, NPCID.PirateDeckhand, NPCID.PirateCorsair, NPCID.PirateDeadeye,NPCID.PirateCrossbower,/*NPCID.PirateGhost*/};
		int[] jungleIds = { NPCID.BigHornetStingy, NPCID.LittleHornetStingy, NPCID.BigHornetSpikey, NPCID.LittleHornetSpikey, NPCID.BigHornetLeafy, NPCID.LittleHornetLeafy, NPCID.BigHornetHoney, NPCID.LittleHornetHoney, NPCID.BigHornetFatty, NPCID.LittleHornetFatty, NPCID.JungleSlime, NPCID.GiantFlyingFox, NPCID.GiantTortoise, NPCID.MossHornet, NPCID.Derpling, NPCID.SpikedJungleSlime, NPCID.Moth, NPCID.HornetFatty, NPCID.HornetHoney, NPCID.HornetLeafy, NPCID.HornetSpikey, NPCID.HornetStingy, NPCID.JungleCreeper, NPCID.JungleCreeperWall, NPCID.Lihzahrd, NPCID.LihzahrdCrawler, NPCID.BigMimicJungle};
		int[] hollowIds = {NPCID.EnchantedSword,NPCID.BigMimicHallow,NPCID.ChaosElemental,NPCID.IlluminantBat,NPCID.IlluminantSlime,NPCID.Gastropod,NPCID.LightningBug,/*NPCID.EmpressButterfly,*/ NPCID.Pixie, NPCID.Unicorn,NPCID.RainbowSlime, NPCID.LightMummy,NPCID.DesertGhoulHallow};
		int[] solarIds = {NPCID.MothronEgg,NPCID.Eyezor, NPCID.Frankenstein, NPCID.SwampThing,NPCID.VampireBat,NPCID.Vampire ,NPCID.CreatureFromTheDeep,NPCID.Fritz,NPCID.Butcher,NPCID.Nailhead,NPCID.Psycho,NPCID.DeadlySphere,NPCID.DrManFly,NPCID.ThePossessed,NPCID.MothronSpawn };

		public override bool InstancePerEntity => true;

		public SlayingItem() {
			hated = "Empty";
		}
		public override GlobalItem Clone(Item item, Item itemClone) {
			SlayingItem myClone = (SlayingItem)base.Clone(item, itemClone);
			myClone.hated = hated;
			return myClone;
		}
		public override void NetSend(Item item, BinaryWriter writer) {
			writer.Write(hated);
		}
		public override void NetReceive(Item item, BinaryReader reader) {
			hated = reader.ReadString();
		}
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
			if (!item.social && item.prefix > 0) {
				TooltipLine line = new TooltipLine(mod, "PrefixHated", "Slays "+hated) {
					isModifier = true
				};
				tooltips.Add(line);
			}
		}

		/*public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
            damageMult = 0.25;
        }*/
		public override void ModifyWeaponDamage(Item item,Player player,ref float add,ref float mult,ref float flat)
		{
			if (hated != "Empty")
			{
				add -= 0.75f;
			}
		}
		public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockback, bool crit)
		{
			bool isHated = false;
			switch (hated) {
				case "Slime":
					if (Array.Exists(slimesIds, element => element == target.type)) isHated = true;
					break;
				case "Undead":
					if (Array.Exists(undeadIds, element => element == target.type)) isHated = true;
					break;
				case "Sky":
					if (Array.Exists(skyIds, element => element == target.type)) isHated = true;
					break;
				case "Water":
					if (Array.Exists(waterIds, element => element == target.type)) isHated = true;
					break;
				case "Hell":
					if (Array.Exists(hellIds, element => element == target.type)) isHated = true;
					break;
				case "Corruption":
					if (Array.Exists(corruptionIds, element => element == target.type)) isHated = true;
					break;
				case "Crimson":
					if (Array.Exists(crimsonIds, element => element == target.type)) isHated = true;
					break;
				case "Blood":
					if (Array.Exists(bloodIds, element => element == target.type)) isHated = true;
					break;
				case "Snow":
					if (Array.Exists(snowIds, element => element == target.type)) isHated = true;
					break;
				case "Pirates":
					if (Array.Exists(piratesIds, element => element == target.type)) isHated = true;
					break;
				case "Jungle":
                    if (Array.Exists(jungleIds, element => element == target.type)) isHated = true;
                    break;
				case "Hollow":
                    if (Array.Exists(hollowIds, element => element == target.type)) isHated = true;
                    break;
				case "Solar":
                    if (Array.Exists(solarIds, element => element == target.type)) isHated = true;
                    break;

			}
			if (isHated) {
				target.StrikeNPC(damage*6, 0, 0); //times 4 to bring it to normal, times 6 to do 6x normal damage
			}
		}
	}
}