# ADOFAI UMM Mod Template

这是一个 A Dance of Fire and Ice (ADOFAI) 的 UnityModManager (UMM) Mod 开发模板项目。

## 项目结构

```
项目根目录/
├── ADOFAIModTemplate.csproj    # 项目文件
├── Main.cs                      # 主 Mod 类
├── ModSettings.cs               # Mod 设置类
├── Patches.cs                   # Harmony 补丁
├── Info.json                    # UMM Mod 信息文件
├── Properties/
│   └── AssemblyInfo.cs          # 程序集信息
└── lib/                   # 游戏依赖库
```

## 开发环境

- .NET Framework 4.8.1
- Visual Studio 2019 或更高版本 / JetBrains Rider

## 使用此模板

### 安装模板
```bash
# 从本地文件夹安装（开发测试）
dotnet new install . --force

# 从 NuGet 包安装
dotnet new install .\StArray.ADOFAIModTemplate.1.0.0.nupkg
```

### 从模板创建新项目
```bash
# 基础用法（使用 --name 或 -n 指定项目名称）
dotnet new adofaimod --name MyModName

# 完整参数
dotnet new adofaimod -n MyModName -d "My Mod Description" -a "Your Name" -v "1.0.0"

# 带游戏路径（自动部署和启动）
dotnet new adofaimod -n MyModName -g "C:\Games\ADOFAI\A Dance of Fire and Ice.exe"
```

### 参数说明
- `-n, --name`: 项目名称（必需，会自动替换所有 ADOFAIModTemplate）
- `-d, --description`: Mod 描述
- `-a, --author`: 作者名称
- `-v, --version`: 版本号
- `-g, --game-path`: 游戏 exe 路径（可选，用于自动部署和启动游戏）

## 依赖库设置

模板需要 ADOFAI 游戏的依赖库。请将游戏的 DLL 文件复制到 `lib/` 文件夹：

```
lib/
├── ModManager/
│   ├── 0Harmony.dll
│   └── UnityModManager.dll
├── Assembly-CSharp.dll
├── UnityEngine.dll
└── ... (其他 Unity 模块)
```

你可以从游戏安装目录的以下位置找到这些文件：
- `<游戏目录>/A Dance of Fire and Ice_Data/Managed/`
- `<游戏目录>/A Dance of Fire and Ice_Data/Managed/UnityModManager/` (UMM 相关 DLL)
