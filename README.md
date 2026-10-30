# 涂布一组工具（SolidWorks 涂布工程二次开发工具）

面向涂布设备工程设计的 SolidWorks 二次开发辅助工具（C# WinForms，基于 SolidWorks API 2023）。

在 SolidWorks 已打开文档的前提下，通过 Windows COM 连接 SolidWorks，批量完成工程图创建、模板/属性整理、装配体清理、一键替换、打包、图纸检查与 AI 智能审核等日常操作，减少重复手工操作。

## 功能特性

- **SolidWorks 连接**：一键「打开 SW」新建实例，或「获取 solidwork」连接已运行的实例
- **文档属性与工程图模板**：按同名「图号 / 物料编码」整理属性，模板与质量单位管理（需本地模板路径）
- **一键替换**：把目标文件夹中的最新零件 / 组件一键替换到装配体，或替换指定零件
- **装配体清理**：按命名规则批量删除装配体中的传动部件（平键、轴承、风轮、旋转接头、密封胶条等）
- **工程图**：新建第三视角工程图并导出 PDF
- **打包（Pack and Go）**：按路径批量打包
- **图纸检查**：对当前打开的 2D 工程图（.slddrw）做只读检查，不修改图纸
  - 标注类：标注重叠、标注越界、重复标注、异常文本
  - 格式类：字体字号、视图比例、图幅、标题栏必填项/建议项
  - 标题栏标准：机加图 / 装配图分开判定（图号、名称、材料、物料编码、设计、设计日期等）
- **AI 智能审核**：把当前工程图的结构化信息（图幅、视图、标注、标题栏属性、规则检查结果）发送给大模型 API 做全面审核
  - 默认接入 DeepSeek（OpenAI 兼容接口），可在 `ai_config.json` 中切换到任意 OpenAI 兼容端点
  - 同时把工程图图形区导出为 PNG（`AI_Review` 目录），为后续 YOLO / 视觉模型审核预留接入点

## 环境要求

- Windows 10 / 11
- SolidWorks 2023（含 API 组件）
- .NET Framework 4.5（Visual Studio 2019 或兼容环境编译）
- 大模型 API Key（仅 AI 智能审核需要，可选）

## 目录结构

```
WindowsFormsApplication5/
├── Form1.cs                    # 主窗体逻辑（连接、替换、清理、打包、检查、AI 审核）
├── Form1.Designer.cs           # 主窗体布局
├── DrawingChecker.cs           # 工程图规则检查 + 结构化上下文 JSON 提取
├── AIConfig.cs                 # AI 审核配置读取（ai_config.json）
├── AIDrawingReviewer.cs        # 大模型 API 调用（OpenAI 兼容 /chat/completions）
├── Program.cs                  # 程序入口
├── 涂布二次开发工具.csproj      # 主工程（Debug|x86，AssemblyName=ConsoleApplication）
├── WindowsFormsApplication5.csproj  # 遗留工程（.NET 4.0，未编译）
├── docs/AI智能审核使用说明.txt  # AI 审核配置与使用说明
└── ai_config.json              # AI 审核配置文件（需填写 ApiKey；不入库）
```

## 构建方法

使用 Visual Studio 2019 自带的 MSBuild：

```bat
MSBuild.exe "涂布二次开发工具.csproj" /t:Build /p:Configuration=Debug /p:Platform=x86
```

- 工程通过 `/link` 嵌入 SolidWorks Interop（`SolidWorks.Interop.sldworks.dll`、`SolidWorks.Interop.swconst.dll`），运行时不依赖额外 interop DLL
- 输出：`bin\Debug\ConsoleApplication.exe`

## 使用方法

1. 启动工具，连接 SolidWorks（未启动时点「打开SW」，已运行时点「获取solidwork」）
2. 在 SolidWorks 中打开需要处理的文档（装配体 / 工程图）
3. 按功能分组点击对应按钮
4. 图纸检查 / AI 智能审核：打开 `.slddrw` 工程图后点击按钮查看报告

### AI 智能审核配置

首次使用需在程序目录创建 `ai_config.json`：

```json
{
  "BaseUrl": "https://api.deepseek.com",
  "ApiKey": "你的 API Key",
  "Model": "deepseek-chat",
  "TimeoutSeconds": 120,
  "MaxTokens": 4000
}
```

- 默认 DeepSeek（平台：https://platform.deepseek.com）
- 可切换到任意 OpenAI 兼容端点（通义、智谱、火山方舟等），只需改 `BaseUrl` 与 `Model`

## 路线图

- [x] 工程图规则检查（赢合模板标题栏标准）
- [x] AI 智能审核（规则提取 + 大模型 API，MVP）
- [ ] YOLO 视觉检测审核（已预留图纸图片导出接入点）
- [ ] 模板路径改为可配置（当前部分按钮的模板路径为历史遗留的 Z 盘路径，需按本机实际路径配置）

## 说明

- 工具仅读取/操作 SolidWorks 当前打开文档，装配体清理、一键替换等修改类操作建议先保存副本
- AI 审核结果仅供参考，最终以人工复核为准
- 本项目为内部工具代码整理开源，不含 SolidWorks 安装文件与公司模板文件
