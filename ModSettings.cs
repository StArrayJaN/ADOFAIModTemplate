using UnityModManagerNet;

namespace ADOFAIModTemplate
{
    /// <summary>
    /// Mod 设置类
    /// </summary>
    public class ModSettings : UnityModManager.ModSettings
    {
        /// <summary>
        /// 示例布尔设置
        /// </summary>
        public bool EnableFeature = true;

        /// <summary>
        /// 示例整数设置
        /// </summary>
        public int ExampleValue = 100;

        /// <summary>
        /// 示例字符串设置
        /// </summary>
        public string ExampleText = "Hello World";

        /// <summary>
        /// 绘制 Mod GUI
        /// </summary>
        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            // 示例：绘制设置界面
            UnityEngine.GUILayout.Label("=== Mod 设置 ===");
            
            EnableFeature = UnityEngine.GUILayout.Toggle(
                EnableFeature, 
                "启用功能"
            );
            
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label("示例数值: ", UnityEngine.GUILayout.Width(100));
            if (int.TryParse(
                UnityEngine.GUILayout.TextField(ExampleValue.ToString(), UnityEngine.GUILayout.Width(100)),
                out int newValue))
            {
                ExampleValue = newValue;
            }
            UnityEngine.GUILayout.EndHorizontal();
            
            UnityEngine.GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label("示例文本: ", UnityEngine.GUILayout.Width(100));
            ExampleText = UnityEngine.GUILayout.TextField(
                ExampleText, 
                UnityEngine.GUILayout.Width(200)
            );
            UnityEngine.GUILayout.EndHorizontal();
        }

        /// <summary>
        /// 保存设置时调用
        /// </summary>
        public void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            Save(modEntry);
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }

        /// <summary>
        /// 加载设置
        /// </summary>
        public static ModSettings Load(UnityModManager.ModEntry modEntry)
        {
            return Load<ModSettings>(modEntry);
        }
    }
}
