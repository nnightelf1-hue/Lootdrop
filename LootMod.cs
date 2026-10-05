using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace DimraethGuaranteedLoot
{
    [BepInPlugin("com.mod.dimraeth.loot100", "Guaranteed Loot 100%", "1.0.0")]
    public class GuaranteedLootPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Harmony harmony = new Harmony("com.mod.dimraeth.loot100");
            harmony.PatchAll();
            Logger.LogInfo("Mod Drop 100% Loaded Successfully!");
        }
    }

    [HarmonyPatch]
    public class LootPatch
    {
        // บังคับค่า Random.value ให้ได้ 0.0 เสมอ เพื่อให้ผ่านเงื่อนไขการดรอปของทุกชนิด (value <= dropChance)
        [HarmonyPatch(typeof(UnityEngine.Random), "value", MethodType.Getter)]
        [HarmonyPostfix]
        public static void PostfixValue(ref float __result)
        {
            __result = 0.0f;
        }
    }
}
