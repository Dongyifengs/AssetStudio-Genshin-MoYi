# 原神 AssetStudio 汉化修复版 - 墨忆特供
查看 [原 AssetStudio 项目](https://github.com/Perfare/AssetStudio) 来查看更多信息

注意：需要互联网连接以获取 asset_index json 文件。
_____________________________________________________________________________________________________________________________
如何使用

```
1. 构建 CABMap (调试 -> 构建 CABMap)。
2. 加载文件。
```
_____________________________________________________________________________________________________________________________
CLI 版本:
```
描述：

用法：
  AssetStudioCLI <input_path> <output_path> [选项]

参数：
  <input_path>   输入文件/文件夹。
  <output_path>  输出文件夹。

选项：
  --silent                                                隐藏日志消息。
  --type <Texture2D|Sprite|etc..>                         指定 Unity 类型。
  --filter <filter>                                       指定正则表达式过滤器。
  --game <BH3|CB1|CB2|CB3|GI|SR|TOT|ZZZ> (REQUIRED)       指定游戏。
  --map_op <AssetMap|Both|CABMap|None>                    指定要构建的地图。[默认值：None]
  --map_type <JSON|XML>                                   AssetMap 输出类型。[默认值：XML]
  --map_name <map_name>                                   指定 AssetMap 文件名。
  --group_assets_type <ByContainer|BySource|ByType|None>  指定导出资源的分组方式。[默认值：0]
  --no_asset_bundle                                       从 AssetMap/导出中排除 AssetBundle。
  --no_index_object                                       从 AssetMap/导出中排除 IndexObject/MiHoYoBinData。
  --xor_key <xor_key>                                     解密 MiHoYoBinData 的 XOR 密钥。
  --ai_file <ai_file>                                     指定 asset_index json 文件路径（用于恢复 GI 容器）。
  --version                                               显示版本信息
  -?, -h, --help                                          显示帮助和使用信息
```
_____________________________________________________________________________________________________________________________
注意事项：
```
- 如果出现任何 "MeshRenderer/SkinnedMeshRenderer" 错误，请确保在加载资源之前启用 "导出选项" 中的 "禁用渲染器" 选项。
- 如果需要导出模型/动画制作器而不获取所有动画，请确保在加载资源之前启用 "选项 -> 导出选项" 中的 "忽略控制器动画" 选项。
```
_____________________________________________________________________________________________________________________________
特别感谢：
- Perfare：[AssetStudio](https://github.com/Perfare/AssetStudio)原始作者
- Khang06：[GenshinBlkStuff](https://github.com/khang06/genshinblkstuff)用于提取
- Radioegor146：[Asset-indexes](https://github.com/radioegor146/gi-asset-indexes) 用于恢复/更新的 asset_index 文件。
- Ds5678：[AssetRipper](https://github.com/AssetRipper/AssetRipper)[[discord](https://discord.gg/XqXa53W2Yh)] 用于关于资产格式和解析的信息。
- mafaca：[uTinyRipper](https://github.com/mafaca/UtinyRipper) 用于 YAML 和 AnimationClipConverter。
- RazTools：[Studo](https:/gitlab.com/RazTools/Studio)基于本项目修改。
- Jaihk662：[CSDN](https://blog.csdn.net/Jaihk662/article/details/118193258)编译AssetStudio(原版)教程
_____________________________________________________________________________________________________________________________

如果您发现 `AssetStudio-Genshin-MoYi` 有用，您可以给它点Star 😄

谢谢，期待您的反馈。
