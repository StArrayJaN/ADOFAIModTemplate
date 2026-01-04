using System.Reflection;
using HarmonyLib;
using UnityModManagerNet;

namespace ADOFAIModTemplate
{
    /// <summary>
    /// ADOFAI UMM Mod 主类
    /// </summary>
    public static class Main
    {
        public static UnityModManager.ModEntry? Mod { get; private set; }
        public static Harmony? Harmony { get; private set; }
        public static ModSettings Settings { get; private set; } = null!;

        /// <summary>
        /// Mod 入口点
        /// </summary>
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            Mod = modEntry;
            
            // 加载设置
            Settings = ModSettings.Load(modEntry);
            
            // 设置回调
            modEntry.OnToggle = OnToggle;
            modEntry.OnGUI = Settings.OnGUI;
            modEntry.OnSaveGUI = Settings.OnSaveGUI;
            
            // 应用 Harmony 补丁
            Harmony = new Harmony(modEntry.Info.Id);
            
            modEntry.Logger.Log("Mod 已加载");
            return true;
        }

        /// <summary>
        /// Mod 启用/禁用切换
        /// </summary>
        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (value)
            {
                modEntry.Logger.Log("Mod 已启用");
                Harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            else
            {
                modEntry.Logger.Log("Mod 已禁用");
                Harmony.UnpatchAll();
            }
            return true;
        }
    }
}