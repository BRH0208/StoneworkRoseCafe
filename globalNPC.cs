using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;
using System.Net;

namespace StoneworkRoseCafe {
    class globalNPC : GlobalNPC {
		public override void GetChat(NPC npc, ref string chat) {
			List<string> speaking = new List<string>();

			if (npc.type == NPCID.DD2Bartender) {
				int cafeowner = NPC.FindFirstNPC(NPCType<NPCs.Myriil>());
				if(cafeowner>0) {
					speaking.Add(Main.npc[cafeowner].GivenName + " and I are not competition, contrary to popular belief!");
					speaking.Add("I sometimes go to " + Main.npc[cafeowner].GivenName + " for a beverage that won't make me black out.");
				}
			}

			//return random index
			if(speaking.Count>0) {
				Random random = new Random();
				chat = speaking[random.Next(speaking.Count)];
			}
		}
    }
}
