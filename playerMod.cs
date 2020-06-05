using StoneworkRoseCafe.Buffs;
using StoneworkRoseCafe.Items;
using StoneworkRoseCafe.NPCs;
using StoneworkRoseCafe.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe {
	// ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
	// several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class playerMod : ModPlayer {
		public bool owlPet;
		public bool examplePersonGiftReceived;
		public bool recievedCafeCut;

		public override void ResetEffects() {
			owlPet = false;
		}

        public override void PreUpdate() {
			if (Main.dayTime && Main.time == 0) {
				recievedCafeCut = false;
			}
		}

        //I have no clue if this is necessary (Ronan)
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)player.whoAmI);
			packet.Send(toWho, fromWho);
		}

		public override TagCompound Save() {
			// Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
			return new TagCompound {
				// {"somethingelse", somethingelse}, // To save more data, add additional lines
				{ nameof(recievedCafeCut), recievedCafeCut },
				{nameof(examplePersonGiftReceived), examplePersonGiftReceived},
			};
			//note that C# 6.0 supports indexer initializers
			//return new TagCompound {
			//	["score"] = score
			//};
		}

		public override void Load(TagCompound tag) {
			examplePersonGiftReceived = tag.GetBool(nameof(examplePersonGiftReceived));
			recievedCafeCut = tag.GetBool(nameof(recievedCafeCut));
		}
	}
}
