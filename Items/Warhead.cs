using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StoneworkRoseCafe.Items
{
    public class Warhead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warhead"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("For a brief moment in history, Manhattan was in New Mexico");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 20000000; //20 platinum * 100 gold * 100 silver * 100 copper
            item.rare = ItemRarityID.Lime; //Lime, around Plantera and Golem
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = TileType<Tiles.Warhead>();
        }

        public override void AddRecipes()
        {
            // Recipes here. See Basic Recipe Guide
        }
    }
}
