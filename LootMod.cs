using System;
using BepInEx;
using HarmonyLib;

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
        // ปรับโอกาสดรอปทุกชนิดให้เป็น 100% (ค่า 1f หรือ 100f)
        [HarmonyPatch(typeof(UnityEngine.Random), nameof(UnityEngine.Random.Range), new Type[] { typeof(float), typeof(float) })]
        [HarmonyPostfix]
        public static void PostfixRange(ref float __result, float min, float max)
        {
            // ดักจับการสุ่มดรอปทั่วไป
        }

        // บังคับค่า Random.value ให้ได้ค่าต่ำสุดเสมอเพื่อชนะเงื่อนไข (value <= dropChance)
        [HarmonyPatch(typeof(UnityEngine.Random), "value", MethodType.Getter)]
        [HarmonyPostfix]
        public static void PostfixValue(ref float __result)
        {
            __result = 0.0f; 
        }
    }
}
