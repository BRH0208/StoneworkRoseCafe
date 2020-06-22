using StoneworkRoseCafe.Items;
using Terraria;
using Terraria.ModLoader;

namespace StoneworkRoseCafe.Prefixes
{
	public class HatePrefix : ModPrefix
	{
		private readonly string _hates;

		// see documentation for vanilla weights and more information
		// note: a weight of 0f can still be rolled. see CanRoll to exclude prefixes.
		// note: if you use PrefixCategory.Custom, actually use ChoosePrefix instead, see ExampleInstancedGlobalItem
		public override float RollChance(Item item)
			=> 5f;

		// determines if it can roll at all.
		// use this to control if a prefixes can be rolled or not
		public override bool CanRoll(Item item)
			=> true;

		// change your category this way, defaults to Custom
		public override PrefixCategory Category
			=> PrefixCategory.AnyWeapon;

		public HatePrefix()
		{
		}

		public HatePrefix(string hates)
		{
			_hates = hates;
		}

		// Allow multiple prefix autoloading this way (permutations of the same prefix)
		public override bool Autoload(ref string name)
		{
			if (!base.Autoload(ref name))
			{
				return false;
			}

			mod.AddPrefix("SlimeSlaying", new HatePrefix("Slime"));
			mod.AddPrefix("UndeadSlaying", new HatePrefix("Undead"));
			mod.AddPrefix("SkySlaying", new HatePrefix("Sky"));
			mod.AddPrefix("WaterSlaying", new HatePrefix("Water"));
			mod.AddPrefix("HellSlaying", new HatePrefix("Hell"));
			mod.AddPrefix("CorruptionSlaying", new HatePrefix("Corruption"));
			mod.AddPrefix("CrimsonSlaying", new HatePrefix("Crimson"));
			mod.AddPrefix("BloodMoonSlaying", new HatePrefix("Blood"));
			mod.AddPrefix("SnowSlaying", new HatePrefix("Snow"));
			mod.AddPrefix("PirateSlaying", new HatePrefix("Pirates"));
			mod.AddPrefix("JungleSlaying", new HatePrefix("Jungle"));
			mod.AddPrefix("HollowSlaying", new HatePrefix("Hollow"));
			mod.AddPrefix("SolarEclipseSlaying", new HatePrefix("Solar"));
			return false;
		}

		public override void Apply(Item item)
		{ 
			item.GetGlobalItem<SlayingItem>().hated = _hates;
		}/*
		public override void ModifyValue(ref float valueMult)
		{
			float multiplier = 1f + 0.05f;
			valueMult *= multiplier;
		}*/
	}
}