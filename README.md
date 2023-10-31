# 原神 AssetStudio 汉化修复版 - 墨忆特供
![Static Badge](https://img.shields.io/badge/Vs%E7%89%88%E6%9C%AC-2019%E6%88%96%E6%9B%B4%E9%AB%98-blue)
![GitHub contributors](https://img.shields.io/github/contributors/Dongyifengs/AssetStudio-Genshin-MoYi)
![GitHub last commit (by committer)](https://img.shields.io/github/last-commit/Dongyifengs/AssetStudio-Genshin-MoYi)






查看 [原 AssetStudio 项目](https://github.com/Perfare/AssetStudio) 来查看更多信息

注意：需要互联网连接以获取 asset_index.json 文件.
_____________________________________________________________________________________________________________________________
编译项目:
 - 准备：Windows（10/11）环境 Vs2019或更高 Nodejs Git
 - 1.为了以后修改代码方便提交,先`Fork`本仓库.
 - 2.打开Vs2022 Git Clone Fork后的仓库,打开Vs2022 Git Clone Fork后的仓库.
 - 4.我们需要下载 [AssetStudioFBXNative](https://www.autodesk.com/developer-network/platform-technologies/fbx-sdk-2020-0) 下载对应自己vs的版本,然后安装即(演示使用22版)
 - 5.打开VS,上面菜单->项目->属性 打开属性窗口
 - 6.找到你刚刚下载的`AssetStudioFBXNative`,默认路径是`C:\Program Files\Autodesk\FBX\FBXSDK\2020.0.1\include`把这个地址添加到配置属性 → C/C++ → 附加包含目录里面,并且复制一份里面的内容到你的`VS include`文件夹下,这个路径默认是 `C:\Program Files (x86)\Microsoft VisualStudio\2019\Community\VC\Tools\MSVC\14.25.28610\include`.当然如果你自定义了安装目录,就要去你的安装目录里面找,下面同理.
 - 7.和步骤6几乎一样,找到对应 SDK 的 lib 附加目录库：默认地址是`C:\Program Files\Autodesk\FBX\FBX SDK\2020.0.1\lib\vs2017\x86\debug`,把这个地址添加到配置属性→ 连接器 → 常规 → 附加库目录里面,前提是你使用的是 debug 模式,release 模式类似
 - 8.配置属性 → 连接器 → 输入 → 附加依赖项添加`libfbxsdk.dll`,配置属性 → 连接
器 → 输入 → 忽略特定默认库添加`LIBCMT`
 - 9.修改代码->运行.
_____________________________________________________________________________________________________________________________
如何使用:

```
1. 构建 CABMap (调试 -> 构建 CABMap).
2. 加载文件.
```
_____________________________________________________________________________________________________________________________
CLI 版本:
```
描述：

用法：
  AssetStudioCLI <input_path> <output_path> [选项]

参数：
  <input_path>   输入文件/文件夹.
  <output_path>  输出文件夹.

选项：
  --silent                                                隐藏日志消息.
  --type <Texture2D|Sprite|etc..>                         指定 Unity 类型.
  --filter <filter>                                       指定正则表达式过滤器.
  --game <BH3|CB1|CB2|CB3|GI|SR|TOT|ZZZ> (REQUIRED)       指定游戏.
  --map_op <AssetMap|Both|CABMap|None>                    指定要构建的地图.[默认值：None]
  --map_type <JSON|XML>                                   AssetMap 输出类型.[默认值：XML]
  --map_name <map_name>                                   指定 AssetMap 文件名.
  --group_assets_type <ByContainer|BySource|ByType|None>  指定导出资源的分组方式.[默认值：0]
  --no_asset_bundle                                       从 AssetMap/导出中排除 AssetBundle.
  --no_index_object                                       从 AssetMap/导出中排除 IndexObject/MiHoYoBinData.
  --xor_key <xor_key>                                     解密 MiHoYoBinData 的 XOR 密钥.
  --ai_file <ai_file>                                     指定 asset_index.json 文件路径（用于恢复 GI 容器）.
  --version                                               显示版本信息
  -?, -h, --help                                          显示帮助和使用信息
```
_____________________________________________________________________________________________________________________________
注意事项：
```
- 如果出现任何 "渲染器失效" 错误,请确保在加载资源之前启用 "导出选项" 中的 "禁用渲染器" 选项.
- 如果需要导出模型/动画制作器而不获取所有动画,请确保在加载资源之前启用 "选项 -> 导出选项" 中的 "忽略控制器动画" 选项.
```
_____________________________________________________________________________________________________________________________
特别感谢：
- Perfare：[AssetStudio](https://github.com/Perfare/AssetStudio)原始作者
- Khang06：[GenshinBlkStuff](https://github.com/khang06/genshinblkstuff)用于提取
- Radioegor146：[Asset-indexes](https://github.com/radioegor146/gi-asset-indexes) 用于恢复/更新的 asset_index 文件
- Ds5678：[AssetRipper](https://github.com/AssetRipper/AssetRipper)[[discord](https://discord.gg/XqXa53W2Yh)] 用于关于资产格式和解析的信息
- mafaca：[uTinyRipper](https://github.com/mafaca/UtinyRipper) 用于 YAML 和 AnimationClipConverter
- RazTools：[Studo](https:/gitlab.com/RazTools/Studio)基于本项目修改.
- Jaihk662：[CSDN](https://blog.csdn.net/Jaihk662/article/details/118193258)编译AssetStudio(原版)教程
_____________________________________________________________________________________________________________________________

如果您发现 `AssetStudio-Genshin-MoYi` 有用,您可以给它点Star 😄

谢谢,期待您的反馈.
