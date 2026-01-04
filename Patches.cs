using HarmonyLib;

namespace ADOFAIModTemplate
{
    public static class Patches
    {
        /// <summary>
        /// scrController.Start 补丁
        /// </summary>
        [HarmonyPatch(typeof(scrController), "Start")]
        public static class ControllerStartPatch
        {
            /// <summary>
            /// 前置补丁
            /// </summary>
            /// <param name="__instance">scrController</param>
            public static void Prefix(scrController __instance)
            {
                Main.Mod?.Logger.Log("Controller start");
            }

            /// <summary>
            /// 后置补丁
            /// </summary>
            /// <param name="__instance">scrController</param> 
            public static void Postfix(scrController __instance)
            {
                Main.Mod?.Logger.Log("Controller started");

                // 示例：使用设置
                if (Main.Settings.EnableFeature)
                {
                    Main.Mod?.Logger.Log($"功能已启用，示例数值: {Main.Settings.ExampleValue}");
                }
            }
        }
    }
    
}
