using StoneworkRoseCafe.Items;
using StoneworkRoseCafe.NPCs;
using StoneworkRoseCafe.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;


namespace StoneworkRoseCafe {
    class roseWorld  : ModWorld {
		public override void Initialize() {
		}
		public override TagCompound Save() {

			return new TagCompound {
				["emissary"] = EmissaryOfTheFlock.Save()
			};
		}
		public override void Load(TagCompound tag) {
			EmissaryOfTheFlock.Load(tag.GetCompound("emissary"));
		}
		public override void PreUpdate() {
			// Update everything about spawning the traveling merchant from the methods we have in the Traveling Merchant's class
			EmissaryOfTheFlock.UpdateMerchandise();
			Myriil.getPayout();
		}
	}
}
