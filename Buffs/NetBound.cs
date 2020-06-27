using Terraria;
using Terraria.ID;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System.IO;
using System;
using System.Numerics;

namespace StoneworkRoseCafe.Buffs {
	public class NetBound : ModBuff {
		int[] skyIds = { NPCID.Harpy, NPCID.WyvernHead, NPCID.WyvernLegs, NPCID.WyvernBody, NPCID.WyvernBody2, NPCID.WyvernBody3, NPCID.WyvernTail,/*NPCID.GiantFlyingAntlion, NPCID.SporeBat,*/ NPCID.CaveBat,NPCID.JungleBat,NPCID.Hellbat,NPCID.GiantBat,NPCID.IlluminantBat, NPCID.IceBat, NPCID.Lavabat,NPCID.VampireBat, NPCID.GraniteFlyer,NPCID.FlyingAntlion, /*NPCID.EyeballFlyingFish,*/ NPCID.Bee, NPCID.BeeSmall,NPCID.Creeper,NPCID.GiantCursedSkull ,NPCID.DungeonSpirit,NPCID.DemonEyeOwl,NPCID.DemonEyeSpaceship,NPCID.DemonEye2,NPCID.PurpleEye2,NPCID.GreenEye2,NPCID.DialatedEye2,NPCID.SleepyEye2,NPCID.CataractEye2,NPCID.DemonEye,NPCID.Demon,NPCID.VoodooDemon,NPCID.Drippler , NPCID.BigEater ,NPCID.LittleEater,NPCID.GiantFlyingFox ,NPCID.FlyingFish ,NPCID.FlyingSnake,NPCID.MeteorHead,NPCID.BigCrimera,NPCID.LittleCrimera, NPCID.Crimera,NPCID.Ghost/*,NPCID.PirateGhost*/,NPCID.BigHornetStingy,NPCID.LittleHornetStingy,NPCID.BigHornetSpikey,NPCID.LittleHornetSpikey,NPCID.BigHornetLeafy,NPCID.LittleHornetLeafy,NPCID.BigHornetHoney,NPCID.LittleHornetHoney,NPCID.BigHornetFatty,NPCID.LittleHornetFatty,NPCID.GiantMossHornet,NPCID.BigMossHornet,/*NPCID.LittleMossHornet,*/NPCID.TinyMossHornet,NPCID.BigStinger,NPCID.LittleStinger,NPCID.Hornet,NPCID.MossHornet,NPCID.HornetFatty,NPCID.HornetHoney,NPCID.HornetLeafy,NPCID.HornetSpikey,NPCID.HornetStingy,NPCID.VortexHornetQueen,NPCID.VortexHornet,NPCID.Raven,NPCID.Vulture,NPCID.AngryNimbus ,NPCID.MothronSpawn, NPCID.NebulaHeadcrab,NPCID.Corruptor,NPCID.CrimsonAxe,NPCID.DungeonSpirit,NPCID.EnchantedSword,NPCID.Flocko,NPCID.IchorSticker,NPCID.MartianProbe,NPCID.Moth,NPCID.NebulaBrain,NPCID.PigronCorruption ,NPCID.PigronHallow,NPCID.PigronCrimson,NPCID.Poltergeist,NPCID.Reaper,NPCID.ShadowFlameApparition,NPCID.Wraith,NPCID.VampireBat,NPCID.Pixie,NPCID.Parrot,NPCID.MartianDrone,NPCID.IceElemental,NPCID.Gastropod,NPCID.FloatyGross,NPCID.ElfCopter,NPCID.CursedHammer,NPCID.SolarCrawltipedeHead,NPCID.SolarCrawltipedeBody,NPCID.SolarCrawltipedeTail,/*NPCID.TombCrawlerHead,NPCID.TombCrawlerBody,TombCrawlerTail,*/NPCID.SolarFlare,/*NPCID.BloodEelHead, NPCID.BloodEelBlody, NPCID.BloodEelTail,*/NPCID.SolarCorite};
		
		public override void SetDefaults() {
			// DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Bound!");
			Description.SetDefault("You are bound in net");
			Main.buffNoTimeDisplay[Type] = false;
			Main.vanityPet[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.wingTime = 0;
		}
		
		public override void Update(NPC npc, ref int buffIndex){
			if(Array.Exists(skyIds, element => element == npc.type)){
				npc.noGravity = false;
				npc.SimpleFlyMovement(new Vector2(0,500),2);
			}
		}		
	}
}
