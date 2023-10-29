using AssetStudio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using static AssetStudioGUI.Exporter;
using Object = AssetStudio.Object;

namespace AssetStudioGUI
{
    internal enum ExportType
    {
        Convert,
        Raw,
        Dump
    }

    internal enum ExportFilter
    {
        All,
        Selected,
        Filtered
    }

    internal enum AssetGroupOption
    {
        ByType,
        ByContainer,
        BySource,
        None
    }

    internal enum ExportListType
    {
        XML
    }

    internal static class Studio
    {
        public static AssetsManager assetsManager = new AssetsManager();
        public static AssemblyLoader assemblyLoader = new AssemblyLoader();
        public static List<AssetItem> exportableAssets = new List<AssetItem>();
        public static List<AssetItem> visibleAssets = new List<AssetItem>();
        internal static Action<string> StatusStripUpdate = x => { };
        public static Game Game;

        public static int ExtractFolder(string path, string savePath)
        {
            int extractedCount = 0;
            Progress.Reset();
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                var file = files[i];
                var fileOriPath = Path.GetDirectoryName(file);
                var fileSavePath = fileOriPath.Replace(path, savePath);
                extractedCount += ExtractFile(file, fileSavePath);
                Progress.Report(i + 1, files.Length);
            }
            return extractedCount;
        }

        public static int ExtractFile(string[] fileNames, string savePath)
        {
            int extractedCount = 0;
            Progress.Reset();
            for (var i = 0; i < fileNames.Length; i++)
            {
                var fileName = fileNames[i];
                extractedCount += ExtractFile(fileName, savePath);
                Progress.Report(i + 1, fileNames.Length);
            }
            return extractedCount;
        }

        public static int ExtractFile(string fileName, string savePath)
        {
            int extractedCount = 0;
            var reader = new FileReader(fileName, Game);
            if (reader.FileType == FileType.BundleFile)
                extractedCount += ExtractBundleFile(reader, savePath);
            else if (reader.FileType == FileType.WebFile)
                extractedCount += ExtractWebDataFile(reader, savePath);
            else if (reader.FileType == FileType.GameFile)
                extractedCount += ExtractGameFile(reader, savePath);
            else
                reader.Dispose();
            return extractedCount;
        }

        private static int ExtractBundleFile(FileReader reader, string savePath)
        {
            StatusStripUpdate($"解压缩 {{reader.FileName}} ...");
            var bundleFile = new BundleFile(reader);
            reader.Dispose();
            if (bundleFile.FileList.Length > 0)
            {
                var extractPath = Path.Combine(savePath, reader.FileName + "_unpacked");
                return ExtractStreamFile(extractPath, bundleFile.FileList);
            }
            return 0;
        }

        private static int ExtractWebDataFile(FileReader reader, string savePath)
        {
            StatusStripUpdate($"解压缩 {{reader.FileName}} ...");
            var webFile = new WebFile(reader);
            reader.Dispose();
            if (webFile.fileList.Length > 0)
            {
                var extractPath = Path.Combine(savePath, reader.FileName + "_unpacked");
                return ExtractStreamFile(extractPath, webFile.fileList);
            }
            return 0;
        }

        private static int ExtractGameFile(FileReader reader, string savePath)
        {
            StatusStripUpdate($"解压缩 {{reader.FileName}} ...");
            var gameFile = new GameFile(reader);
            reader.Dispose();
            var fileList = gameFile.Bundles.SelectMany(x => x.Value).ToList();
            if (fileList.Count > 0)
            {
                var extractPath = Path.Combine(savePath, Path.GetFileNameWithoutExtension(reader.FileName));
                return ExtractStreamFile(extractPath, fileList.ToArray());
            }
            return 0;
        }

        private static int ExtractStreamFile(string extractPath, StreamFile[] fileList)
        {
            int extractedCount = 0;
            foreach (var file in fileList)
            {
                var filePath = Path.Combine(extractPath, file.path);
                var fileDirectory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }
                if (!File.Exists(filePath))
                {
                    using (var fileStream = File.Create(filePath))
                    {
                        file.stream.CopyTo(fileStream);
                    }
                    extractedCount += 1;
                }
                file.stream.Dispose();
            }
            return extractedCount;
        }

        public static List<AssetEntry> BuildAssetMap(List<string> files)
        {
            var assets = new List<AssetEntry>();
            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var reader = new FileReader(file, Game);
                var gameFile = new GameFile(reader);
                reader.Dispose();

                foreach (var bundle in gameFile.Bundles)
                {
                    foreach (var cab in bundle.Value)
                    {
                        var dummyPath = Path.Combine(Path.GetDirectoryName(file), cab.fileName);
                        using (var cabReader = new FileReader(dummyPath, cab.stream, Game))
                        {
                            if (cabReader.FileType == FileType.AssetsFile)
                            {
                                var assetsFile = new SerializedFile(cabReader, assetsManager, file);
                                assetsManager.assetsFileList.Add(assetsFile);

                                assetsFile.m_Objects = assetsFile.m_Objects.Where(x => x.HasExportableType()).ToList();

                                IndexObject indexObject = null;
                                var containers = new List<(PPtr<Object>, string)>(assetsFile.m_Objects.Count);
                                var animators = new List<(PPtr<GameObject>, AssetEntry)>(assetsFile.m_Objects.Count);
                                var objectAssetItemDic = new Dictionary<Object, AssetEntry>(assetsFile.m_Objects.Count);
                                foreach (var objInfo in assetsFile.m_Objects)
                                {
                                    var objectReader = new ObjectReader(assetsFile.reader, assetsFile, objInfo);
                                    var obj = new Object(objectReader);
                                    var asset = new AssetEntry()
                                    {
                                        Source = file,
                                        PathID = objectReader.m_PathID,
                                        Type = objectReader.type,
                                        Container = ""
                                    };

                                    var exportable = true;
                                    switch (objectReader.type)
                                    {
                                        case ClassIDType.AssetBundle:
                                            var assetBundle = new AssetBundle(objectReader);
                                            foreach (var m_Container in assetBundle.Container)
                                            {
                                                var preloadIndex = m_Container.Value.preloadIndex;
                                                var preloadSize = m_Container.Value.preloadSize;
                                                var preloadEnd = preloadIndex + preloadSize;
                                                for (int k = preloadIndex; k < preloadEnd; k++)
                                                {
                                                    if (Game.Name == "GI" || Game.Name == "GI_CB2" || Game.Name == "GI_CB3")
                                                    {
                                                        if (long.TryParse(m_Container.Key, out var containerValue))
                                                        {
                                                            var last = unchecked((uint)containerValue);
                                                            var path = ResourceIndex.GetBundlePath(last);
                                                            if (!string.IsNullOrEmpty(path))
                                                            {
                                                                containers.Add((assetBundle.PreloadTable[k], path));
                                                                continue;
                                                            }
                                                        }
                                                    }
                                                    containers.Add((assetBundle.PreloadTable[k], m_Container.Key));
                                                }
                                            }
                                            obj = null;
                                            asset.Name = assetBundle.m_Name;
                                            exportable = AssetBundle.Exportable;
                                            break;
                                        case ClassIDType.GameObject:
                                            var gameObject = new GameObject(objectReader);
                                            obj = gameObject;
                                            asset.Name = gameObject.m_Name;
                                            exportable = false;
                                            break;
                                        case ClassIDType.Shader:
                                            asset.Name = objectReader.ReadAlignedString();
                                            if (string.IsNullOrEmpty(asset.Name))
                                            {
                                                var m_parsedForm = new SerializedShader(objectReader);
                                                asset.Name = m_parsedForm.m_Name;
                                            }
                                            break;
                                        case ClassIDType.Animator:
                                            var component = new PPtr<GameObject>(objectReader);
                                            animators.Add((component, asset));
                                            break;
                                        case ClassIDType.MiHoYoBinData:
                                            if (indexObject.Names.TryGetValue(objectReader.m_PathID, out var binName))
                                            {
                                                var path = ResourceIndex.GetContainerFromBinName(binName);
                                                asset.Container = path;
                                                asset.Name = !string.IsNullOrEmpty(path) ? Path.GetFileName(path) : binName;
                                            }
                                            exportable = IndexObject.Exportable;
                                            break;
                                        case ClassIDType.IndexObject:
                                            indexObject = new IndexObject(objectReader);
                                            obj = null;
                                            asset.Name = "IndexObject";
                                            exportable = IndexObject.Exportable;
                                            break;
                                        default:
                                            asset.Name = objectReader.ReadAlignedString();
                                            break;
                                    }
                                    if (obj != null)
                                    {
                                        objectAssetItemDic.Add(obj, asset);
                                        assetsFile.AddObject(obj);
                                    }
                                    if (exportable)
                                    {
                                        assets.Add(asset);
                                    }
                                }
                                foreach (var pair in animators)
                                {
                                    if (pair.Item1.TryGet(out var gameObject))
                                    {
                                        pair.Item2.Name = gameObject.m_Name;
                                    }
                                    else
                                    {
                                        Logger.Warning($"无法找到有效 {pair.Item1.m_PathID} 的游戏路径ID对象，正在移除...");
                                        assets.Remove(pair.Item2);
                                    }
                                }
                                foreach ((var pptr, var container) in containers)
                                {
                                    if (pptr.TryGet(out var obj))
                                    {
                                        objectAssetItemDic[obj].Container = container;
                                    }
                                }
                                assetsManager.assetsFileList.Clear();
                            }
                        }
                    }
                }

                Logger.Info($"[{i + 1}/{files.Count}] 已处理 {Path.GetFileName(file)}");
                Progress.Report(i + 1, files.Count);
            }

            return assets;
        }

        public static (string, List<TreeNode>) BuildAssetData()
        {
            StatusStripUpdate("编译素材列表...");

            string productName = null;
            var objectCount = assetsManager.assetsFileList.Sum(x => x.Objects.Count);
            var objectAssetItemDic = new Dictionary<Object, AssetItem>(objectCount);
            var containers = new List<(PPtr<Object>, string)>();
            int i = 0;
            Progress.Reset();
            foreach (var assetsFile in assetsManager.assetsFileList)
            {
                foreach (var asset in assetsFile.Objects)
                {
                    var assetItem = new AssetItem(asset);
                    objectAssetItemDic.Add(asset, assetItem);
                    assetItem.UniqueID = "#" + i;
                    var exportable = false;
                    switch (asset)
                    {
                        case GameObject m_GameObject:
                            assetItem.Text = m_GameObject.m_Name;
                            break;
                        case Texture2D m_Texture2D:
                            if (!string.IsNullOrEmpty(m_Texture2D.m_StreamData?.path))
                                assetItem.FullSize = asset.byteSize + m_Texture2D.m_StreamData.size;
                            assetItem.Text = m_Texture2D.m_Name;
                            exportable = true;
                            break;
                        case AudioClip m_AudioClip:
                            if (!string.IsNullOrEmpty(m_AudioClip.m_Source))
                                assetItem.FullSize = asset.byteSize + m_AudioClip.m_Size;
                            assetItem.Text = m_AudioClip.m_Name;
                            exportable = true;
                            break;
                        case VideoClip m_VideoClip:
                            if (!string.IsNullOrEmpty(m_VideoClip.m_OriginalPath))
                                assetItem.FullSize = asset.byteSize + (long)m_VideoClip.m_ExternalResources.m_Size;
                            assetItem.Text = m_VideoClip.m_Name;
                            exportable = true;
                            break;
                        case Shader m_Shader:
                            assetItem.Text = m_Shader.m_ParsedForm?.m_Name ?? m_Shader.m_Name;
                            exportable = true;
                            break;
                        case Mesh _:
                        case TextAsset _:
                        case AnimationClip _:
                        case Font _:
                        case MovieTexture _:
                        case Sprite _:
                        case Material _:
                            assetItem.Text = ((NamedObject)asset).m_Name;
                            exportable = true;
                            break;
                        case Animator m_Animator:
                            if (m_Animator.m_GameObject.TryGet(out var gameObject))
                            {
                                assetItem.Text = gameObject.m_Name;
                            }
                            exportable = true;
                            break;
                        case MonoBehaviour m_MonoBehaviour:
                            if (m_MonoBehaviour.m_Name == "" && m_MonoBehaviour.m_Script.TryGet(out var m_Script))
                            {
                                assetItem.Text = m_Script.m_ClassName;
                            }
                            else
                            {
                                assetItem.Text = m_MonoBehaviour.m_Name;
                            }
                            exportable = true;
                            break;
                        case PlayerSettings m_PlayerSettings:
                            productName = m_PlayerSettings.productName;
                            break;
                        case AssetBundle m_AssetBundle:
                            foreach (var m_Container in m_AssetBundle.Container)
                            {
                                var preloadIndex = m_Container.Value.preloadIndex;
                                var preloadSize = m_Container.Value.preloadSize;
                                var preloadEnd = preloadIndex + preloadSize;
                                for (int k = preloadIndex; k < preloadEnd; k++)
                                {
                                    if (Game.Name == "GI" || Game.Name == "GI_CB2" || Game.Name == "GI_CB3")
                                    {
                                        if (long.TryParse(m_Container.Key, out var containerValue))
                                        {
                                            var last = unchecked((uint)containerValue);
                                            var path = ResourceIndex.GetBundlePath(last);
                                            if (!string.IsNullOrEmpty(path))
                                            {
                                                containers.Add((m_AssetBundle.PreloadTable[k], path));
                                                continue;
                                            }
                                        }
                                    }
                                    containers.Add((m_AssetBundle.PreloadTable[k], m_Container.Key));
                                }
                            }
                            assetItem.Text = m_AssetBundle.m_Name;
                            exportable = AssetBundle.Exportable;
                            break;
                        case IndexObject m_IndexObject:
                            assetItem.Text = "IndexObject";
                            exportable = IndexObject.Exportable;
                            break;
                        case ResourceManager m_ResourceManager:
                            foreach (var m_Container in m_ResourceManager.m_Container)
                            {
                                containers.Add((m_Container.Value, m_Container.Key));
                            }
                            break;
                        case MiHoYoBinData m_MiHoYoBinData:
                            if (m_MiHoYoBinData.assetsFile.ObjectsDic.TryGetValue(2, out var obj) && obj is IndexObject indexObject)
                            {
                                if (indexObject.Names.TryGetValue(m_MiHoYoBinData.m_PathID, out var binName))
                                {
                                    string path = "";
                                    var game = GameManager.GetGame("GI");
                                    if (Path.GetExtension(assetsFile.originalPath) == game.Extension)
                                    {
                                        path = ResourceIndex.GetContainerFromBinName(binName);
                                    }
                                    else
                                    {
                                        var last = Convert.ToUInt32(binName, 16);
                                        path = ResourceIndex.GetBundlePath(last) ?? "";
                                    }
                                    assetItem.Container = path;
                                    assetItem.Text = !string.IsNullOrEmpty(path) ? Path.GetFileName(path) : binName;
                                } 
                            }
                            else assetItem.Text = string.Format("BinFile #{0}", assetItem.m_PathID);
                            exportable = true;
                            break;
                        case NamedObject m_NamedObject:
                            assetItem.Text = m_NamedObject.m_Name;
                            break;
                    }
                    if (assetItem.Text == "")
                    {
                        assetItem.Text = assetItem.TypeString + assetItem.UniqueID;
                    }
                    if (Properties.Settings.Default.displayAll || exportable)
                    {
                        exportableAssets.Add(assetItem);
                    }
                    Progress.Report(++i, objectCount);
                }
            }

            StatusStripUpdate("编译拆解清单列表");

            i = 0;
            Progress.Reset();
            var containersCount = containers.Count;
            foreach ((var pptr, var container) in containers)
            {
                if (pptr.TryGet(out var obj))
                {
                    objectAssetItemDic[obj].Container = container;
                }
                Progress.Report(++i, containersCount);
            }
            foreach (var tmp in exportableAssets)
            {
                tmp.SetSubItems();
            }
            containers.Clear();

            visibleAssets = exportableAssets;

            StatusStripUpdate("建筑树形结构…");

            var treeNodeCollection = new List<TreeNode>();
            var treeNodeDictionary = new Dictionary<GameObject, GameObjectTreeNode>();
            var assetsFileCount = assetsManager.assetsFileList.Count;
            int j = 0;
            Progress.Reset();
            foreach (var assetsFile in assetsManager.assetsFileList)
            {
                var fileNode = new TreeNode(assetsFile.fileName); //RootNode

                foreach (var obj in assetsFile.Objects)
                {
                    if (obj is GameObject m_GameObject)
                    {
                        if (!treeNodeDictionary.TryGetValue(m_GameObject, out var currentNode))
                        {
                            currentNode = new GameObjectTreeNode(m_GameObject);
                            treeNodeDictionary.Add(m_GameObject, currentNode);
                        }

                        foreach (var pptr in m_GameObject.m_Components)
                        {
                            if (pptr.TryGet(out var m_Component))
                            {
                                objectAssetItemDic[m_Component].TreeNode = currentNode;
                                if (m_Component is MeshFilter m_MeshFilter)
                                {
                                    if (m_MeshFilter.m_Mesh.TryGet(out var m_Mesh))
                                    {
                                        objectAssetItemDic[m_Mesh].TreeNode = currentNode;
                                    }
                                }
                                else if (m_Component is SkinnedMeshRenderer m_SkinnedMeshRenderer)
                                {
                                    if (m_SkinnedMeshRenderer.m_Mesh.TryGet(out var m_Mesh))
                                    {
                                        objectAssetItemDic[m_Mesh].TreeNode = currentNode;
                                    }
                                }
                            }
                        }

                        var parentNode = fileNode;

                        if (m_GameObject.m_Transform != null)
                        {
                            if (m_GameObject.m_Transform.m_Father.TryGet(out var m_Father))
                            {
                                if (m_Father.m_GameObject.TryGet(out var parentGameObject))
                                {
                                    if (!treeNodeDictionary.TryGetValue(parentGameObject, out var parentGameObjectNode))
                                    {
                                        parentGameObjectNode = new GameObjectTreeNode(parentGameObject);
                                        treeNodeDictionary.Add(parentGameObject, parentGameObjectNode);
                                    }
                                    parentNode = parentGameObjectNode;
                                }
                            }
                        }

                        parentNode.Nodes.Add(currentNode);
                    }
                }

                if (fileNode.Nodes.Count > 0)
                {
                    treeNodeCollection.Add(fileNode);
                }

                Progress.Report(++j, assetsFileCount);
            }
            treeNodeDictionary.Clear();

            objectAssetItemDic.Clear();

            return (productName, treeNodeCollection);
        }

        public static Dictionary<string, SortedDictionary<int, TypeTreeItem>> BuildClassStructure()
        {
            var typeMap = new Dictionary<string, SortedDictionary<int, TypeTreeItem>>();
            foreach (var assetsFile in assetsManager.assetsFileList)
            {
                if (typeMap.TryGetValue(assetsFile.unityVersion, out var curVer))
                {
                    foreach (var type in assetsFile.m_Types.Where(x => x.m_Type != null))
                    {
                        var key = type.classID;
                        if (type.m_ScriptTypeIndex >= 0)
                        {
                            key = -1 - type.m_ScriptTypeIndex;
                        }
                        curVer[key] = new TypeTreeItem(key, type.m_Type);
                    }
                }
                else
                {
                    var items = new SortedDictionary<int, TypeTreeItem>();
                    foreach (var type in assetsFile.m_Types.Where(x => x.m_Type != null))
                    {
                        var key = type.classID;
                        if (type.m_ScriptTypeIndex >= 0)
                        {
                            key = -1 - type.m_ScriptTypeIndex;
                        }
                        items[key] = new TypeTreeItem(key, type.m_Type);
                    }
                    typeMap.Add(assetsFile.unityVersion, items);
                }
            }

            return typeMap;
        }

        public static void ExportAssets(string savePath, List<AssetItem> toExportAssets, ExportType exportType)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                int toExportCount = toExportAssets.Count;
                int exportedCount = 0;
                int i = 0;
                Progress.Reset();
                foreach (var asset in toExportAssets)
                {
                    string exportPath;
                    switch ((AssetGroupOption)Properties.Settings.Default.assetGroupOption)
                    {
                        case AssetGroupOption.ByType: //type name
                            exportPath = Path.Combine(savePath, asset.TypeString);
                            break;
                        case AssetGroupOption.ByContainer: //container path
                            if (!string.IsNullOrEmpty(asset.Container))
                            {
                                exportPath = Path.HasExtension(asset.Container) ? Path.Combine(savePath, Path.GetDirectoryName(asset.Container)) : Path.Combine(savePath, asset.Container);
                            }
                            else
                            {
                                exportPath = Path.Combine(savePath, asset.TypeString);
                            }
                            break;
                        case AssetGroupOption.BySource: //source file
                            if (string.IsNullOrEmpty(asset.SourceFile.originalPath))
                            {
                                exportPath = Path.Combine(savePath, asset.SourceFile.fileName + "_export");
                            }
                            else
                            {
                                exportPath = Path.Combine(savePath, Path.GetFileName(asset.SourceFile.originalPath) + "_export", asset.SourceFile.fileName);
                            }
                            break;
                        default:
                            exportPath = savePath;
                            break;
                    }
                    exportPath += Path.DirectorySeparatorChar;
                    StatusStripUpdate($"[{exportedCount}/{toExportCount}] 导出 {asset.TypeString}: {asset.Text}");
                    try
                    {
                        switch (exportType)
                        {
                            case ExportType.Raw:
                                if (ExportRawFile(asset, exportPath))
                                {
                                    exportedCount++;
                                }
                                break;
                            case ExportType.Dump:
                                if (ExportDumpFile(asset, exportPath))
                                {
                                    exportedCount++;
                                }
                                break;
                            case ExportType.Convert:
                                if (ExportConvertFile(asset, exportPath))
                                {
                                    exportedCount++;
                                }
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"导出 {asset.Type}:{asset.Text} 错误\r\n{ex.Message}\r\n{ex.StackTrace}");
                    }

                    Progress.Report(++i, toExportCount);
                }

                var statusText = exportedCount == 0 ? "没有导出任何内容." : $"完成导出 {exportedCount} 个素材";

                if (toExportCount > exportedCount)
                {
                    statusText += $" {toExportCount - exportedCount}项资产已跳过 (无法提取或文件已存在)";
                }

                StatusStripUpdate(statusText);

                if (Properties.Settings.Default.openAfterExport && exportedCount > 0)
                {
                    OpenFolderInExplorer(savePath);
                }
            });
        }

        public static void ExportAssetsMap(string savePath, List<AssetEntry> toExportAssets, ExportListType exportListType)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                Progress.Reset();

                string filename;
                switch (exportListType)
                {
                    case ExportListType.XML:
                        filename = Path.Combine(savePath, $"assets_map_{Game.Name}.xml");
                        var doc = new XDocument(
                            new XElement("Assets",
                                new XAttribute("filename", filename),
                                new XAttribute("createdAt", DateTime.UtcNow.ToString("s")),
                                toExportAssets.Select(
                                    asset => new XElement("Asset",
                                        new XElement("Name", asset.Name),
                                        new XElement("Container", asset.Container),
                                        new XElement("Type", new XAttribute("id", (int)asset.Type), asset.Type.ToString()),
                                        new XElement("PathID", asset.PathID),
                                        new XElement("Source", asset.Source)
                                    )
                                )
                            )
                        );
                        doc.Save(filename);
                        break;
                }

                var statusText = $"完成了包含 {toExportAssets.Count()} 个素材的导出";

                StatusStripUpdate(statusText);

                Logger.Info($"资产映射成功编译!!");

                if (Properties.Settings.Default.openAfterExport && toExportAssets.Count() > 0)
                {
                    OpenFolderInExplorer(savePath);
                }
            });
        }

        public static void ExportAssetsList(string savePath, List<AssetItem> toExportAssets, ExportListType exportListType)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                Progress.Reset();

                switch (exportListType)
                {
                    case ExportListType.XML:
                        var filename = Path.Combine(savePath, "Assets.xml");
                        var doc = new XDocument(
                            new XElement("Assets",
                                new XAttribute("filename", filename),
                                new XAttribute("createdAt", DateTime.UtcNow.ToString("s")),
                                toExportAssets.Select(
                                    asset => new XElement("Asset",
                                        new XElement("Name", asset.Text),
                                        new XElement("Container", asset.Container),
                                        new XElement("Type", new XAttribute("id", (int)asset.Type), asset.TypeString),
                                        new XElement("PathID", asset.m_PathID),
                                        new XElement("Source", asset.SourceFile.fullName),
                                        new XElement("OriginalPath", asset.SourceFile.originalPath),
                                        new XElement("Size", asset.FullSize)
                                    )
                                )
                            )
                        );

                        doc.Save(filename);

                        break;
                }

                var statusText = $"完成导出含有 {toExportAssets.Count()} 项的资产列表。";

                StatusStripUpdate(statusText);

                if (Properties.Settings.Default.openAfterExport && toExportAssets.Count() > 0)
                {
                    OpenFolderInExplorer(savePath);
                }
            });
        }

        public static void ExportSplitObjects(string savePath, TreeNodeCollection nodes)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                var count = nodes.Cast<TreeNode>().Sum(x => x.Nodes.Count);
                int k = 0;
                Progress.Reset();
                foreach (TreeNode node in nodes)
                {
                    //遍历一级子节点
                    foreach (GameObjectTreeNode j in node.Nodes)
                    {
                        //收集所有子节点
                        var gameObjects = new List<GameObject>();
                        CollectNode(j, gameObjects);
                        //跳过一些不需要导出的object
                        if (gameObjects.All(x => x.m_SkinnedMeshRenderer == null && x.m_MeshFilter == null))
                        {
                            Progress.Report(++k, count);
                            continue;
                        }
                        //处理非法文件名
                        var filename = FixFileName(j.Text);
                        //每个文件存放在单独的文件夹
                        var targetPath = $"{savePath}{filename}{Path.DirectorySeparatorChar}";
                        //重名文件处理
                        for (int i = 1; ; i++)
                        {
                            if (Directory.Exists(targetPath))
                            {
                                targetPath = $"{savePath}{filename} ({i}){Path.DirectorySeparatorChar}";
                            }
                            else
                            {
                                break;
                            }
                        }
                        Directory.CreateDirectory(targetPath);
                        //导出FBX
                        StatusStripUpdate($"导出 {filename}.fbx");
                        try
                        {
                            ExportGameObject(j.gameObject, targetPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"导出游戏对象：{j.Text} 错误\r\n{ex.Message}\r\n{ex.StackTrace}");
                        }

                        Progress.Report(++k, count);
                        StatusStripUpdate($"完成导出 {filename}.fbx");
                    }
                }
                if (Properties.Settings.Default.openAfterExport)
                {
                    OpenFolderInExplorer(savePath);
                }
                StatusStripUpdate("完成");
            });
        }

        private static void CollectNode(GameObjectTreeNode node, List<GameObject> gameObjects)
        {
            gameObjects.Add(node.gameObject);
            foreach (GameObjectTreeNode i in node.Nodes)
            {
                CollectNode(i, gameObjects);
            }
        }

        public static void ExportAnimatorWithAnimationClip(AssetItem animator, List<AssetItem> animationList, string exportPath)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                Progress.Reset();
                StatusStripUpdate($"导出 {{animator.Text}}");
                try
                {
                    ExportAnimator(animator, exportPath, animationList);
                    if (Properties.Settings.Default.openAfterExport)
                    {
                        OpenFolderInExplorer(exportPath);
                    }
                    Progress.Report(1, 1);
                    StatusStripUpdate($"完成导出 {animator.Text}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出动画器：{animator.Text} 错误\r\n{ex.Message}\r\n{ex.StackTrace}");
                    StatusStripUpdate("导出中的错误");
                }
            });
        }

        public static void ExportObjectsWithAnimationClip(string exportPath, TreeNodeCollection nodes, List<AssetItem> animationList = null)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                var gameObjects = new List<GameObject>();
                GetSelectedParentNode(nodes, gameObjects);
                if (gameObjects.Count > 0)
                {
                    var count = gameObjects.Count;
                    int i = 0;
                    Progress.Reset();
                    foreach (var gameObject in gameObjects)
                    {
                        StatusStripUpdate($"导出 {gameObject.m_Name}");
                        try
                        {
                            var subExportPath = Path.Combine(exportPath, gameObject.m_Name) + Path.DirectorySeparatorChar;
                            ExportGameObject(gameObject, subExportPath, animationList);
                            StatusStripUpdate($"完成导出 {gameObject.m_Name}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"导出游戏对象：{gameObject.m_Name} 错误\r\n{ex.Message}\r\n{ex.StackTrace}");
                            StatusStripUpdate("导出错误");
                        }

                        Progress.Report(++i, count);
                    }
                    if (Properties.Settings.Default.openAfterExport)
                    {
                        OpenFolderInExplorer(exportPath);
                    }
                }
                else
                {
                    StatusStripUpdate("没有选择对象进行导出。");
                }
            });
        }

        public static void ExportObjectsMergeWithAnimationClip(string exportPath, List<GameObject> gameObjects, List<AssetItem> animationList = null)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                var name = Path.GetFileName(exportPath);
                Progress.Reset();
                StatusStripUpdate($"导出 {name}");
                try
                {
                    ExportGameObjectMerge(gameObjects, exportPath, animationList);
                    Progress.Report(1, 1);
                    StatusStripUpdate($"导出完成{name}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出模型：{{name}} 错误\n{{ex.Message}}\n{{ex.StackTrace}}");
                    StatusStripUpdate("导出时出错");
                }
                if (Properties.Settings.Default.openAfterExport)
                {
                    OpenFolderInExplorer(Path.GetDirectoryName(exportPath));
                }
            });
        }

        public static void GetSelectedParentNode(TreeNodeCollection nodes, List<GameObject> gameObjects)
        {
            foreach (TreeNode i in nodes)
            {
                if (i is GameObjectTreeNode gameObjectTreeNode && i.Checked)
                {
                    gameObjects.Add(gameObjectTreeNode.gameObject);
                }
                else
                {
                    GetSelectedParentNode(i.Nodes, gameObjects);
                }
            }
        }

        public static TypeTree MonoBehaviourToTypeTree(MonoBehaviour m_MonoBehaviour)
        {
            if (!assemblyLoader.Loaded)
            {
                var openFolderDialog = new OpenFolderDialog();
                openFolderDialog.Title = "选择程序集文件夹";
                if (openFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    assemblyLoader.Load(openFolderDialog.Folder);
                }
                else
                {
                    assemblyLoader.Loaded = true;
                }
            }
            return m_MonoBehaviour.ConvertToTypeTree(assemblyLoader);
        }

        public static string DumpAsset(Object obj)
        {
            var str = obj.Dump();
            if (str == null && obj is MonoBehaviour m_MonoBehaviour)
            {
                if (m_MonoBehaviour.m_Name.EndsWith("_Atlas"))
                {
                    str = "ATLAS格式暂时无法Dump";
                }
                else {
                    var type = MonoBehaviourToTypeTree(m_MonoBehaviour);
                    str = m_MonoBehaviour.Dump(type);
                }
            }
            return str;
        }

        public static void OpenFolderInExplorer(string path)
        {
            var info = new ProcessStartInfo(path);
            info.UseShellExecute = true;
            Process.Start(info);
        }
    }
}
