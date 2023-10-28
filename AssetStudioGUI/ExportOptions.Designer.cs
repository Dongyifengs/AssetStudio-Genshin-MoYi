namespace AssetStudioGUI
{
    partial class ExportOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            OKbutton = new System.Windows.Forms.Button();
            Cancel = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            disableShader = new System.Windows.Forms.CheckBox();
            ignoreController = new System.Windows.Forms.CheckBox();
            disableRndrr = new System.Windows.Forms.CheckBox();
            exportIndexObject = new System.Windows.Forms.CheckBox();
            exportAssetBundle = new System.Windows.Forms.CheckBox();
            openAfterExport = new System.Windows.Forms.CheckBox();
            restoreExtensionName = new System.Windows.Forms.CheckBox();
            assetGroupOptions = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            convertAudio = new System.Windows.Forms.CheckBox();
            panel1 = new System.Windows.Forms.Panel();
            totga = new System.Windows.Forms.RadioButton();
            tojpg = new System.Windows.Forms.RadioButton();
            topng = new System.Windows.Forms.RadioButton();
            tobmp = new System.Windows.Forms.RadioButton();
            converttexture = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            exportUV0UV1 = new System.Windows.Forms.CheckBox();
            exportAllUvsAsDiffuseMaps = new System.Windows.Forms.CheckBox();
            exportBlendShape = new System.Windows.Forms.CheckBox();
            exportAnimations = new System.Windows.Forms.CheckBox();
            scaleFactor = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            fbxFormat = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            fbxVersion = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            boneSize = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            exportSkins = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            filterPrecision = new System.Windows.Forms.NumericUpDown();
            castToBone = new System.Windows.Forms.CheckBox();
            exportAllNodes = new System.Windows.Forms.CheckBox();
            eulerFilter = new System.Windows.Forms.CheckBox();
            exportUvsTooltip = new System.Windows.Forms.ToolTip(components);
            groupBox3 = new System.Windows.Forms.GroupBox();
            enableXor = new System.Windows.Forms.CheckBox();
            key = new System.Windows.Forms.NumericUpDown();
            label7 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scaleFactor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boneSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filterPrecision).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)key).BeginInit();
            SuspendLayout();
            // 
            // OKbutton
            // 
            OKbutton.Location = new System.Drawing.Point(371, 496);
            OKbutton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            OKbutton.Name = "OKbutton";
            OKbutton.Size = new System.Drawing.Size(88, 31);
            OKbutton.TabIndex = 6;
            OKbutton.Text = "确定";
            OKbutton.UseVisualStyleBackColor = true;
            OKbutton.Click += OKbutton_Click;
            // 
            // Cancel
            // 
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point(465, 496);
            Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size(88, 31);
            Cancel.TabIndex = 7;
            Cancel.Text = "取消";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(disableShader);
            groupBox1.Controls.Add(ignoreController);
            groupBox1.Controls.Add(disableRndrr);
            groupBox1.Controls.Add(exportIndexObject);
            groupBox1.Controls.Add(exportAssetBundle);
            groupBox1.Controls.Add(openAfterExport);
            groupBox1.Controls.Add(restoreExtensionName);
            groupBox1.Controls.Add(assetGroupOptions);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(convertAudio);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(converttexture);
            groupBox1.Location = new System.Drawing.Point(14, 17);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(271, 363);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "导出";
            // 
            // disableShader
            // 
            disableShader.AutoSize = true;
            disableShader.Location = new System.Drawing.Point(113, 287);
            disableShader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            disableShader.Name = "disableShader";
            disableShader.Size = new System.Drawing.Size(99, 21);
            disableShader.TabIndex = 22;
            disableShader.Text = "关闭渲染效果";
            disableShader.UseVisualStyleBackColor = true;
            // 
            // ignoreController
            // 
            ignoreController.AutoSize = true;
            ignoreController.Checked = true;
            ignoreController.CheckState = System.Windows.Forms.CheckState.Checked;
            ignoreController.Location = new System.Drawing.Point(7, 315);
            ignoreController.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ignoreController.Name = "ignoreController";
            ignoreController.Size = new System.Drawing.Size(111, 21);
            ignoreController.TabIndex = 21;
            ignoreController.Text = "忽略控制器动画";
            ignoreController.UseVisualStyleBackColor = true;
            // 
            // disableRndrr
            // 
            disableRndrr.AutoSize = true;
            disableRndrr.Location = new System.Drawing.Point(126, 256);
            disableRndrr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            disableRndrr.Name = "disableRndrr";
            disableRndrr.Size = new System.Drawing.Size(75, 21);
            disableRndrr.TabIndex = 13;
            disableRndrr.Text = "关闭渲染";
            disableRndrr.UseVisualStyleBackColor = true;
            // 
            // exportIndexObject
            // 
            exportIndexObject.AutoSize = true;
            exportIndexObject.Checked = true;
            exportIndexObject.CheckState = System.Windows.Forms.CheckState.Checked;
            exportIndexObject.Location = new System.Drawing.Point(7, 287);
            exportIndexObject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exportIndexObject.Name = "exportIndexObject";
            exportIndexObject.Size = new System.Drawing.Size(75, 21);
            exportIndexObject.TabIndex = 12;
            exportIndexObject.Text = "资源计数";
            exportIndexObject.UseVisualStyleBackColor = true;
            // 
            // exportAssetBundle
            // 
            exportAssetBundle.AutoSize = true;
            exportAssetBundle.Checked = true;
            exportAssetBundle.CheckState = System.Windows.Forms.CheckState.Checked;
            exportAssetBundle.Location = new System.Drawing.Point(7, 256);
            exportAssetBundle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exportAssetBundle.Name = "exportAssetBundle";
            exportAssetBundle.Size = new System.Drawing.Size(122, 21);
            exportAssetBundle.TabIndex = 11;
            exportAssetBundle.Text = "导出AssetBundle";
            exportAssetBundle.UseVisualStyleBackColor = true;
            // 
            // openAfterExport
            // 
            openAfterExport.AutoSize = true;
            openAfterExport.Checked = true;
            openAfterExport.CheckState = System.Windows.Forms.CheckState.Checked;
            openAfterExport.Location = new System.Drawing.Point(7, 227);
            openAfterExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            openAfterExport.Name = "openAfterExport";
            openAfterExport.Size = new System.Drawing.Size(123, 21);
            openAfterExport.TabIndex = 10;
            openAfterExport.Text = "导出后打开文件夹";
            openAfterExport.UseVisualStyleBackColor = true;
            // 
            // restoreExtensionName
            // 
            restoreExtensionName.AutoSize = true;
            restoreExtensionName.Checked = true;
            restoreExtensionName.CheckState = System.Windows.Forms.CheckState.Checked;
            restoreExtensionName.Location = new System.Drawing.Point(7, 83);
            restoreExtensionName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            restoreExtensionName.Name = "restoreExtensionName";
            restoreExtensionName.Size = new System.Drawing.Size(166, 21);
            restoreExtensionName.TabIndex = 9;
            restoreExtensionName.Text = "TextAsset格式带有扩展名";
            restoreExtensionName.UseVisualStyleBackColor = true;
            // 
            // assetGroupOptions
            // 
            assetGroupOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            assetGroupOptions.FormattingEnabled = true;
            assetGroupOptions.Items.AddRange(new object[] { "type name", "container path", "source file name", "do not group" });
            assetGroupOptions.Location = new System.Drawing.Point(7, 45);
            assetGroupOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            assetGroupOptions.Name = "assetGroupOptions";
            assetGroupOptions.Size = new System.Drawing.Size(173, 25);
            assetGroupOptions.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 24);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(80, 17);
            label6.TabIndex = 7;
            label6.Text = "资源分组方式";
            // 
            // convertAudio
            // 
            convertAudio.AutoSize = true;
            convertAudio.Checked = true;
            convertAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            convertAudio.Location = new System.Drawing.Point(7, 196);
            convertAudio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            convertAudio.Name = "convertAudio";
            convertAudio.Size = new System.Drawing.Size(194, 21);
            convertAudio.TabIndex = 6;
            convertAudio.Text = "将AudioClip转换为WAV(PCM)";
            convertAudio.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(totga);
            panel1.Controls.Add(tojpg);
            panel1.Controls.Add(topng);
            panel1.Controls.Add(tobmp);
            panel1.Location = new System.Drawing.Point(23, 145);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(236, 42);
            panel1.TabIndex = 5;
            // 
            // totga
            // 
            totga.AutoSize = true;
            totga.Location = new System.Drawing.Point(175, 8);
            totga.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            totga.Name = "totga";
            totga.Size = new System.Drawing.Size(48, 21);
            totga.TabIndex = 2;
            totga.Text = "Tga";
            totga.UseVisualStyleBackColor = true;
            // 
            // tojpg
            // 
            tojpg.AutoSize = true;
            tojpg.Location = new System.Drawing.Point(113, 8);
            tojpg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tojpg.Name = "tojpg";
            tojpg.Size = new System.Drawing.Size(54, 21);
            tojpg.TabIndex = 4;
            tojpg.Text = "Jpeg";
            tojpg.UseVisualStyleBackColor = true;
            // 
            // topng
            // 
            topng.AutoSize = true;
            topng.Checked = true;
            topng.Location = new System.Drawing.Point(58, 8);
            topng.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            topng.Name = "topng";
            topng.Size = new System.Drawing.Size(48, 21);
            topng.TabIndex = 3;
            topng.TabStop = true;
            topng.Text = "Png";
            topng.UseVisualStyleBackColor = true;
            // 
            // tobmp
            // 
            tobmp.AutoSize = true;
            tobmp.Location = new System.Drawing.Point(4, 8);
            tobmp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tobmp.Name = "tobmp";
            tobmp.Size = new System.Drawing.Size(53, 21);
            tobmp.TabIndex = 2;
            tobmp.Text = "Bmp";
            tobmp.UseVisualStyleBackColor = true;
            // 
            // converttexture
            // 
            converttexture.AutoSize = true;
            converttexture.Checked = true;
            converttexture.CheckState = System.Windows.Forms.CheckState.Checked;
            converttexture.Location = new System.Drawing.Point(7, 113);
            converttexture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            converttexture.Name = "converttexture";
            converttexture.Size = new System.Drawing.Size(146, 21);
            converttexture.TabIndex = 1;
            converttexture.Text = "Texture2D格式转换为";
            converttexture.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(exportUV0UV1);
            groupBox2.Controls.Add(exportAllUvsAsDiffuseMaps);
            groupBox2.Controls.Add(exportBlendShape);
            groupBox2.Controls.Add(exportAnimations);
            groupBox2.Controls.Add(scaleFactor);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(fbxFormat);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(fbxVersion);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(boneSize);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(exportSkins);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(filterPrecision);
            groupBox2.Controls.Add(castToBone);
            groupBox2.Controls.Add(exportAllNodes);
            groupBox2.Controls.Add(eulerFilter);
            groupBox2.Location = new System.Drawing.Point(292, 17);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(261, 474);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Fbx格式";
            // 
            // exportUV0UV1
            // 
            exportUV0UV1.AccessibleDescription = "";
            exportUV0UV1.AutoSize = true;
            exportUV0UV1.Location = new System.Drawing.Point(7, 270);
            exportUV0UV1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exportUV0UV1.Name = "exportUV0UV1";
            exportUV0UV1.Size = new System.Drawing.Size(128, 21);
            exportUV0UV1.TabIndex = 24;
            exportUV0UV1.Text = "仅导出二维UV贴图";
            exportUvsTooltip.SetToolTip(exportUV0UV1, "Unchecked: Export UV0/UV1 only. Check this if your facing issues with vertex color/tangent.");
            exportUV0UV1.UseVisualStyleBackColor = true;
            // 
            // exportAllUvsAsDiffuseMaps
            // 
            exportAllUvsAsDiffuseMaps.AccessibleDescription = "";
            exportAllUvsAsDiffuseMaps.AutoSize = true;
            exportAllUvsAsDiffuseMaps.Location = new System.Drawing.Point(7, 241);
            exportAllUvsAsDiffuseMaps.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exportAllUvsAsDiffuseMaps.Name = "exportAllUvsAsDiffuseMaps";
            exportAllUvsAsDiffuseMaps.Size = new System.Drawing.Size(188, 21);
            exportAllUvsAsDiffuseMaps.TabIndex = 23;
            exportAllUvsAsDiffuseMaps.Text = "导出UV贴图时转化为离散表格";
            exportUvsTooltip.SetToolTip(exportAllUvsAsDiffuseMaps, "Unchecked: UV1 exported as normal map. Check this if your export is missing a UV map.");
            exportAllUvsAsDiffuseMaps.UseVisualStyleBackColor = true;
            // 
            // exportBlendShape
            // 
            exportBlendShape.AutoSize = true;
            exportBlendShape.Checked = true;
            exportBlendShape.CheckState = System.Windows.Forms.CheckState.Checked;
            exportBlendShape.Location = new System.Drawing.Point(7, 180);
            exportBlendShape.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exportBlendShape.Name = "exportBlendShape";
            exportBlendShape.Size = new System.Drawing.Size(99, 21);
            exportBlendShape.TabIndex = 22;
            exportBlendShape.Text = "导出脸部特征";
            exportBlendShape.UseVisualStyleBackColor = true;
            // 
            // exportAnimations
            // 
            exportAnimations.AutoSize = true;
            exportAnimations.Checked = true;
            exportAnimations.CheckState = System.Windows.Forms.CheckState.Checked;
            exportAnimations.Location = new System.Drawing.Point(7, 150);
            exportAnimations.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exportAnimations.Name = "exportAnimations";
            exportAnimations.Size = new System.Drawing.Size(75, 21);
            exportAnimations.TabIndex = 21;
            exportAnimations.Text = "导出动画";
            exportAnimations.UseVisualStyleBackColor = true;
            // 
            // scaleFactor
            // 
            scaleFactor.DecimalPlaces = 2;
            scaleFactor.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            scaleFactor.Location = new System.Drawing.Point(72, 337);
            scaleFactor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            scaleFactor.Name = "scaleFactor";
            scaleFactor.Size = new System.Drawing.Size(70, 23);
            scaleFactor.TabIndex = 20;
            scaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            scaleFactor.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 340);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(56, 17);
            label5.TabIndex = 19;
            label5.Text = "缩放大小";
            // 
            // fbxFormat
            // 
            fbxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            fbxFormat.FormattingEnabled = true;
            fbxFormat.Items.AddRange(new object[] { "Binary", "Ascii" });
            fbxFormat.Location = new System.Drawing.Point(72, 379);
            fbxFormat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            fbxFormat.Name = "fbxFormat";
            fbxFormat.Size = new System.Drawing.Size(70, 25);
            fbxFormat.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 385);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(54, 17);
            label4.TabIndex = 17;
            label4.Text = "FBX格式";
            // 
            // fbxVersion
            // 
            fbxVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            fbxVersion.FormattingEnabled = true;
            fbxVersion.Items.AddRange(new object[] { "6.1", "7.1", "7.2", "7.3", "7.4", "7.5" });
            fbxVersion.Location = new System.Drawing.Point(72, 422);
            fbxVersion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            fbxVersion.Name = "fbxVersion";
            fbxVersion.Size = new System.Drawing.Size(54, 25);
            fbxVersion.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 426);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(54, 17);
            label3.TabIndex = 15;
            label3.Text = "FBX版本";
            // 
            // boneSize
            // 
            boneSize.Location = new System.Drawing.Point(72, 298);
            boneSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            boneSize.Name = "boneSize";
            boneSize.Size = new System.Drawing.Size(54, 23);
            boneSize.TabIndex = 11;
            boneSize.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(7, 301);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 17);
            label2.TabIndex = 10;
            label2.Text = "骨骼大小";
            // 
            // exportSkins
            // 
            exportSkins.AutoSize = true;
            exportSkins.Checked = true;
            exportSkins.CheckState = System.Windows.Forms.CheckState.Checked;
            exportSkins.Location = new System.Drawing.Point(7, 118);
            exportSkins.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exportSkins.Name = "exportSkins";
            exportSkins.Size = new System.Drawing.Size(75, 21);
            exportSkins.TabIndex = 8;
            exportSkins.Text = "导出贴图";
            exportSkins.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(30, 54);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 17);
            label1.TabIndex = 7;
            label1.Text = "筛子精度";
            // 
            // filterPrecision
            // 
            filterPrecision.DecimalPlaces = 2;
            filterPrecision.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            filterPrecision.Location = new System.Drawing.Point(111, 52);
            filterPrecision.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            filterPrecision.Name = "filterPrecision";
            filterPrecision.Size = new System.Drawing.Size(59, 23);
            filterPrecision.TabIndex = 6;
            filterPrecision.Value = new decimal(new int[] { 25, 0, 0, 131072 });
            // 
            // castToBone
            // 
            castToBone.AutoSize = true;
            castToBone.Location = new System.Drawing.Point(7, 211);
            castToBone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            castToBone.Name = "castToBone";
            castToBone.Size = new System.Drawing.Size(135, 21);
            castToBone.TabIndex = 5;
            castToBone.Text = "所有节点转换为骨骼";
            castToBone.UseVisualStyleBackColor = true;
            // 
            // exportAllNodes
            // 
            exportAllNodes.AutoSize = true;
            exportAllNodes.Checked = true;
            exportAllNodes.CheckState = System.Windows.Forms.CheckState.Checked;
            exportAllNodes.Location = new System.Drawing.Point(7, 86);
            exportAllNodes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exportAllNodes.Name = "exportAllNodes";
            exportAllNodes.Size = new System.Drawing.Size(99, 21);
            exportAllNodes.TabIndex = 4;
            exportAllNodes.Text = "导出所有节点";
            exportAllNodes.UseVisualStyleBackColor = true;
            // 
            // eulerFilter
            // 
            eulerFilter.AutoSize = true;
            eulerFilter.Checked = true;
            eulerFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            eulerFilter.Location = new System.Drawing.Point(7, 28);
            eulerFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            eulerFilter.Name = "eulerFilter";
            eulerFilter.Size = new System.Drawing.Size(87, 21);
            eulerFilter.TabIndex = 3;
            eulerFilter.Text = "欧拉筛算法";
            eulerFilter.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.AutoSize = true;
            groupBox3.Controls.Add(enableXor);
            groupBox3.Controls.Add(key);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new System.Drawing.Point(14, 388);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Size = new System.Drawing.Size(271, 103);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "MiHoYoBinData格式";
            // 
            // enableXor
            // 
            enableXor.AutoSize = true;
            enableXor.Checked = true;
            enableXor.CheckState = System.Windows.Forms.CheckState.Checked;
            enableXor.Location = new System.Drawing.Point(10, 32);
            enableXor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            enableXor.Name = "enableXor";
            enableXor.Size = new System.Drawing.Size(99, 21);
            enableXor.TabIndex = 12;
            enableXor.Text = "启用异或算法";
            enableXor.UseVisualStyleBackColor = true;
            // 
            // key
            // 
            key.Hexadecimal = true;
            key.Location = new System.Drawing.Point(145, 30);
            key.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            key.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            key.Name = "key";
            key.Size = new System.Drawing.Size(71, 23);
            key.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(113, 33);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(29, 17);
            label7.TabIndex = 7;
            label7.Text = "Key";
            // 
            // ExportOptions
            // 
            AcceptButton = OKbutton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new System.Drawing.Size(567, 544);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Cancel);
            Controls.Add(OKbutton);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExportOptions";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "导出选项";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scaleFactor).EndInit();
            ((System.ComponentModel.ISupportInitialize)boneSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)filterPrecision).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)key).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox converttexture;
        private System.Windows.Forms.RadioButton tojpg;
        private System.Windows.Forms.RadioButton topng;
        private System.Windows.Forms.RadioButton tobmp;
        private System.Windows.Forms.RadioButton totga;
        private System.Windows.Forms.CheckBox convertAudio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown boneSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox exportSkins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown filterPrecision;
        private System.Windows.Forms.CheckBox castToBone;
        private System.Windows.Forms.CheckBox exportAllNodes;
        private System.Windows.Forms.CheckBox eulerFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fbxVersion;
        private System.Windows.Forms.ComboBox fbxFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown scaleFactor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox exportBlendShape;
        private System.Windows.Forms.CheckBox exportAnimations;
        private System.Windows.Forms.ComboBox assetGroupOptions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox restoreExtensionName;
        private System.Windows.Forms.CheckBox openAfterExport;
        private System.Windows.Forms.CheckBox exportAllUvsAsDiffuseMaps;
        private System.Windows.Forms.ToolTip exportUvsTooltip;
        private System.Windows.Forms.CheckBox exportIndexObject;
        private System.Windows.Forms.CheckBox exportAssetBundle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown key;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox enableXor;
        private System.Windows.Forms.CheckBox disableRndrr;
        private System.Windows.Forms.CheckBox ignoreController;
        private System.Windows.Forms.CheckBox disableShader;
        private System.Windows.Forms.CheckBox exportUV0UV1;
    }
}