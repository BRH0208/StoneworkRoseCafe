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
using System.Collections.Generic;
using Terraria.Utilities;
using Terraria.ModLoader.IO;

namespace StoneworkRoseCafe.NPCs {
    // [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class EmissaryOfTheFlock : ModNPC {
        public override string Texture => "StoneworkRoseCafe/NPCs/EmissaryOfTheFlock";


        public override bool Autoload(ref string name) {
            name = "Emissary of the Flock";
            return mod.Properties.Autoload;
        }
        public static List<Item> shopItems = new List<Item>();

        public static void UpdateMerchandise() {
            if (Main.dayTime && Main.time == 0) {
                shopItems = CreateNewShop();
            }
        }
        public static List<Item> CreateNewShop() {
            var itemIds = new List<int>();
            for (int i = 0; i < 30; i++) {
                itemIds.Add(Main.rand.Next(-24, 3930));
            }
            var items = new List<Item>();
            foreach (int itemId in itemIds) {
                Item item = new Item();
                try {
                    item.SetDefaults(itemId);
                } catch {
                    // If the item does not exist, just move on. Suppress error.
                    continue;
                }
                
                items.Add(item);
            }
            return items;
        }

        public override void SetStaticDefaults() {
            // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            DisplayName.SetDefault("Emissary of the Flock");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0; //throwing
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.townNPC = true;
            npc.friendly = true;
            npc.dontTakeDamageFromHostiles = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Merchant;
            shopItems = CreateNewShop();
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            for (int k = 0; k < 255; k++) {
                Player player = Main.player[k];
                if (!player.active) {
                    continue;
                }
            }
            return false;
        }

        public static TagCompound Save() {
            return new TagCompound {
                ["shopItems"] = shopItems
            };
        }

        public static void Load(TagCompound tag) {
            shopItems = tag.Get<List<Item>>("shopItems");
        }

        public override string TownNPCName() {
            return "Connor";
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
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add("The birds. They are coming.");
			chat.Add("Ravens. Robins. Gulls.");
			chat.Add("They are calling for you.");
			chat.Add("The flock guides us all");
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}

        public override void SetChatButtons(ref string button, ref string button2) {
            button = Language.GetTextValue("LegacyInterface.28");
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
            if (firstButton) {
                shop = true;
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot) {
            foreach(Item item in shopItems) {
                if (item == null || item.type == ItemID.None)
                    continue;
                shop.item[nextSlot].SetDefaults(item.type);
                shop.item[nextSlot].shopCustomPrice = 5000000;
                nextSlot++;
            }
        }

        // Make this Town NPC teleport to the King and/or Queen statue when triggered.
        public override bool CanGoToStatue(bool toKingStatue) {
            return false;
        }

        // Create a square of pixels around the NPC on teleport.
        public void StatueTeleport() {
            for (int i = 0; i < 30; i++) {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y)) {
                    position.X = Math.Sign(position.X) * 20;
                }
                else {
                    position.Y = Math.Sign(position.Y) * 20;
                }
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.CopperCoinsFalling;
			attackDelay = 1;
		}

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}