using StoneworkRoseCafe;
using StoneworkRoseCafe.Mugs;
using StoneworkRoseCafe.Mugs.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe
{
	public class StoneworkRoseCafe : Mod
	{
		internal UserInterface HunterUserInterface;
		
		public StoneworkRoseCafe() {
		}
		private static NewMug[] mugs = new NewMug[] {
			new NewMug("Stone Mug","StoneMug"),
			new NewMug("Glazed Stone Mug","GlazedStoneMug"),
			new NewMug("Glass Mug","GlassMug"),
			new NewMug("Blue-Spruce Mug","BlueSpruceStoneMug"),
			new NewMug("Heat Treated Stone Mug","HeatTreatedStoneMug"),
			new NewMug("Ceramic Mug","CeramicMug"),
			new NewMug("Porcelain Mug","PorcelainMug"),
			new NewMug("Moziac Mug","MoziacMug"),
			new NewMug("Specked Mug","SpeckledMug"),
			new NewMug("Crimstone Mug","CrimstoneMug"),
			new NewMug("Gold-Plated Mug","GoldPlatedMug"),
			new NewMug("Calacatta Marble Mug","MarbleMug"),
			new NewMug("Obsidian Mug","ObsidianMug"),
			new NewMug("China Mug","China"),
			new NewMug("Stainless Steel Mug","StainlessSteelMug"),
			new NewMug("Beast Mug","BeastMug"),
			new NewMug("Wooden Mug","WoodenMug"),
			new NewMug("Paper Mug","PaperMug"),
		};
		public static List<int> MugIDs = new List<int>();
		public override void Load() {
			foreach (var mymug in mugs) {
				Mug item = new Mug(mymug.displayName, "StoneworkRoseCafe/Mugs/Items/" + mymug.texturePath + "Item");
				MugTile tile = new MugTile(item, "StoneworkRoseCafe/Mugs/Tiles/" + mymug.texturePath + "Tile");
				AddTile(mymug.displayName, tile, "StoneworkRoseCafe/Mugs/Tiles/" + mymug.texturePath + "Tile");
				item.tile = tile.Type;
				MugIDs.Add(tile.Type); //add so we can get all the mugs later
				AddItem(mymug.displayName, item);
				tile.drop = item.item.type;
			}
			
			HunterUserInterface = new UserInterface();
		}
		
		public override void UpdateUI(GameTime gameTime) {
			HunterUserInterface?.Update(gameTime); // I don't know why there is an '?' either, but without it, the code don't build
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
			int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
			if (inventoryIndex != -1) {
				layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
					"ExampleMod: Example Person UI",
					delegate {
						// If the current UIState of the UserInterface is null, nothing will draw. We don't need to track a separate .visible value.
						HunterUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}
