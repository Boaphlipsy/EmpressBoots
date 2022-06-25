using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace EmpressBoots.Config
{
    class BootsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static BootsConfig Instance;

        [DefaultValue(true)]
        [Label("Enable No Falldamge")]
        [Tooltip("Adds the Lucky Horseshoe to the Crafting Recipe and also adds the ability of negating Falldamage\nRELOAD REQUIRED")]
        public bool EnableHorseShoe;

        [DefaultValue(false)]
        [Label("Enable Harder Recipe")]
        [Tooltip("Changes the Recipe to also require a drop from either Betsy or Duke Fishron\nRELOAD REQUIRED")]
        public bool EnableHardRecipe;

        [DefaultValue(false)]
        [Label("Enable Ancient Manipulator Crafting")]
        [Tooltip("Changes the required Crafting Station from Tinkerers Workbench to Ancient Manipulator\nRELOAD REQUIRED")]
        public bool EnableManipulatorCrafting;

        [DefaultValue(true)]
        [Label("Ignore Calamity Mod's Nerf to the Soaring Insignia")]
        [Tooltip("Ignores Calamity Mod's Nerf to the Soaring Insignia and still grants Infinite Flight")]
        public bool IgnoreCalamitySoaringNerf;
    }
}
