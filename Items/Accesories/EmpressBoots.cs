using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EmpressBoots.Config;

namespace EmpressBoots.Items.Accesories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class EmpressBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            string displayName = "Ethereal Boots";
            string tooltip =
                "Allows flight, super fast running, and extra mobility on ice\n" +
                "8% increased movement speed\n" +
                "Provides the ability to walk on water, honey & lava\n" +
                "Grants immunity to fire blocks and 7 seconds of immunity to lava\n" +
                "Reduces damage from touching lava\n";
            if (BootsConfig.Instance.IgnoreCalamitySoaringNerf)
                tooltip += "Grants infinite wing and rocket boot flight\n";
            else
                tooltip += "Increases wing flight time by 50%\n";
            tooltip += "Increases flight and jump mobility";
            if (BootsConfig.Instance.EnableHorseShoe)
                tooltip += "\nNegates fall damge";

            DisplayName.SetDefault(displayName);
            Tooltip.SetDefault(tooltip);
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 25);
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.expert = true;
            Item.canBePlacedInVanityRegardlessOfConditions = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            UpdateBoots(player);

            UpdateInsignia(player);

            UpdateHorseshoe(player);
        }

        private void UpdateInsignia(Player player)
        {
            player.moveSpeed += 0.1f;
            if (BootsConfig.Instance.IgnoreCalamitySoaringNerf)
            {
                player.wingTime = player.wingTimeMax + 1;
                player.rocketTime = player.rocketTimeMax + 1;

                player.jumpSpeedBoost += 2.4f;
                player.runAcceleration *= 2f;
            }
            else player.empressBrooch = true;
        }

        private void UpdateHorseshoe(Player player)
        {
            if (BootsConfig.Instance.EnableHorseShoe)
                player.noFallDmg = true;
        }

        private void UpdateBoots(Player player)
        {
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaMax += 420;
            player.lavaRose = true;

            player.accRunSpeed = 6.75f;
            player.rocketBoots = (player.vanityRocketBoots = 4);
            player.moveSpeed += 0.08f;
            player.iceSkate = true;
        }

        private void AddRecipeGroup()
        {
            RecipeGroup etherealWings = new RecipeGroup(() => "Fishron Wings or Betsy Wings", new int[]
            {
                ItemID.BetsyWings,
                ItemID.FishronWings
            });

            RecipeGroup.RegisterGroup("EmpressBoots:EtherealWings", etherealWings);
        }

        public override void AddRecipes()
        {
            AddRecipeGroup();

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.TerrasparkBoots, 1);
            recipe.AddIngredient(ItemID.EmpressFlightBooster, 1);

            if (BootsConfig.Instance.EnableHorseShoe)
            {
                recipe.AddIngredient(ItemID.LuckyHorseshoe, 1);
            }

            if (BootsConfig.Instance.EnableHardRecipe)
            {
                recipe.AddRecipeGroup("EmpressBoots:EtherealWings", 1);
            }

            if (BootsConfig.Instance.EnableManipulatorCrafting)
            {
                recipe.AddTile(TileID.LunarCraftingStation);
            }
            else
            {
                recipe.AddTile(TileID.TinkerersWorkbench);
            }

            recipe.Register();
        }
    }
}
