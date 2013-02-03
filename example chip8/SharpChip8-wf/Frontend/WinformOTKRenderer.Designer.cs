namespace WinformFrontend.Frontend
{
    partial class WinformOTKRenderer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinformOTKRenderer));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelEtatEmu = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.quitItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.emulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.stopItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.resetItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemMenuVirtualController = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.résolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuCRNative = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuCRDouble = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuCRTriple = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuCRPerso = new System.Windows.Forms.ToolStripMenuItem();
            this.couleursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuColorBW = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.itemMenuColorLB = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuColorLO = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuColorLG = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cpuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.vitesseNormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuVNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuVSpeed = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuVMoreSpeed = new System.Windows.Forms.ToolStripMenuItem();
            this.soundItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuSActive = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuSDesactive = new System.Windows.Forms.ToolStripMenuItem();
            this.outilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugerItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.disasmItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.otkGLControl = new OpenTK.GLControl();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelEtatEmu});
            this.statusStrip1.Location = new System.Drawing.Point(0, 286);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(512, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelEtatEmu
            // 
            this.labelEtatEmu.Name = "labelEtatEmu";
            this.labelEtatEmu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelEtatEmu.Size = new System.Drawing.Size(31, 17);
            this.labelEtatEmu.Text = "Stop";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.emulationToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.outilsToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(512, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openItemMenu,
            this.fermerToolStripMenuItem,
            this.toolStripSeparator4,
            this.quitItemMenu});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // openItemMenu
            // 
            this.openItemMenu.Image = global::WinformFrontend.Properties.Resources.open_icon;
            this.openItemMenu.Name = "openItemMenu";
            this.openItemMenu.Size = new System.Drawing.Size(152, 22);
            this.openItemMenu.Text = "Ouvrir";
            this.openItemMenu.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // fermerToolStripMenuItem
            // 
            this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            this.fermerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fermerToolStripMenuItem.Text = "Fermer";
            this.fermerToolStripMenuItem.Click += new System.EventHandler(this.closeItemMenu_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // quitItemMenu
            // 
            this.quitItemMenu.Image = global::WinformFrontend.Properties.Resources.quit_icon;
            this.quitItemMenu.Name = "quitItemMenu";
            this.quitItemMenu.Size = new System.Drawing.Size(152, 22);
            this.quitItemMenu.Text = "Quitter";
            this.quitItemMenu.Click += new System.EventHandler(this.quitItemMenu_Click);
            // 
            // emulationToolStripMenuItem
            // 
            this.emulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startItemMenu,
            this.stopItemMenu,
            this.resetItemMenu,
            this.toolStripSeparator1,
            this.itemMenuVirtualController});
            this.emulationToolStripMenuItem.Name = "emulationToolStripMenuItem";
            this.emulationToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.emulationToolStripMenuItem.Text = "Emulation";
            // 
            // startItemMenu
            // 
            this.startItemMenu.Image = global::WinformFrontend.Properties.Resources.start_icon;
            this.startItemMenu.Name = "startItemMenu";
            this.startItemMenu.Size = new System.Drawing.Size(167, 22);
            this.startItemMenu.Text = "Démarrer";
            this.startItemMenu.Click += new System.EventHandler(this.startItemMenu_Click);
            // 
            // stopItemMenu
            // 
            this.stopItemMenu.Image = global::WinformFrontend.Properties.Resources.stop_icon;
            this.stopItemMenu.Name = "stopItemMenu";
            this.stopItemMenu.Size = new System.Drawing.Size(167, 22);
            this.stopItemMenu.Text = "Arrêter";
            this.stopItemMenu.Click += new System.EventHandler(this.stopItemMenu_Click);
            // 
            // resetItemMenu
            // 
            this.resetItemMenu.Name = "resetItemMenu";
            this.resetItemMenu.Size = new System.Drawing.Size(167, 22);
            this.resetItemMenu.Text = "Reset";
            this.resetItemMenu.Click += new System.EventHandler(this.resetItemMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // itemMenuVirtualController
            // 
            this.itemMenuVirtualController.Name = "itemMenuVirtualController";
            this.itemMenuVirtualController.Size = new System.Drawing.Size(167, 22);
            this.itemMenuVirtualController.Text = "Contrôleur virtuel";
            this.itemMenuVirtualController.Click += new System.EventHandler(this.itemMenuInputController_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphicsItemMenu,
            this.controlsItemMenu,
            this.cpuItemMenu,
            this.soundItemMenu});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // graphicsItemMenu
            // 
            this.graphicsItemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.résolutionToolStripMenuItem,
            this.couleursToolStripMenuItem});
            this.graphicsItemMenu.Name = "graphicsItemMenu";
            this.graphicsItemMenu.Size = new System.Drawing.Size(152, 22);
            this.graphicsItemMenu.Text = "Affichage";
            // 
            // résolutionToolStripMenuItem
            // 
            this.résolutionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMenuCRNative,
            this.itemMenuCRDouble,
            this.itemMenuCRTriple,
            this.itemMenuCRPerso});
            this.résolutionToolStripMenuItem.Name = "résolutionToolStripMenuItem";
            this.résolutionToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.résolutionToolStripMenuItem.Text = "Résolution";
            // 
            // itemMenuCRNative
            // 
            this.itemMenuCRNative.Checked = true;
            this.itemMenuCRNative.CheckOnClick = true;
            this.itemMenuCRNative.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemMenuCRNative.Name = "itemMenuCRNative";
            this.itemMenuCRNative.Size = new System.Drawing.Size(146, 22);
            this.itemMenuCRNative.Text = "Native";
            this.itemMenuCRNative.Click += new System.EventHandler(this.itemMenuCRNative_Click);
            // 
            // itemMenuCRDouble
            // 
            this.itemMenuCRDouble.Name = "itemMenuCRDouble";
            this.itemMenuCRDouble.Size = new System.Drawing.Size(146, 22);
            this.itemMenuCRDouble.Text = "Double";
            this.itemMenuCRDouble.Click += new System.EventHandler(this.itemMenuCRDouble_Click);
            // 
            // itemMenuCRTriple
            // 
            this.itemMenuCRTriple.Name = "itemMenuCRTriple";
            this.itemMenuCRTriple.Size = new System.Drawing.Size(146, 22);
            this.itemMenuCRTriple.Text = "Triple";
            this.itemMenuCRTriple.Click += new System.EventHandler(this.itemMenuCRTriple_Click);
            // 
            // itemMenuCRPerso
            // 
            this.itemMenuCRPerso.Enabled = false;
            this.itemMenuCRPerso.Name = "itemMenuCRPerso";
            this.itemMenuCRPerso.Size = new System.Drawing.Size(146, 22);
            this.itemMenuCRPerso.Text = "Personnalisée";
            this.itemMenuCRPerso.Click += new System.EventHandler(this.itemMenuCRPerso_Click);
            // 
            // couleursToolStripMenuItem
            // 
            this.couleursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMenuColorBW,
            this.toolStripSeparator3,
            this.itemMenuColorLB,
            this.itemMenuColorLO,
            this.itemMenuColorLG});
            this.couleursToolStripMenuItem.Name = "couleursToolStripMenuItem";
            this.couleursToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.couleursToolStripMenuItem.Text = "Couleurs";
            // 
            // itemMenuColorBW
            // 
            this.itemMenuColorBW.Checked = true;
            this.itemMenuColorBW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemMenuColorBW.Name = "itemMenuColorBW";
            this.itemMenuColorBW.Size = new System.Drawing.Size(172, 22);
            this.itemMenuColorBW.Text = "Noir et blanc";
            this.itemMenuColorBW.Click += new System.EventHandler(this.itemMenuColorBW_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // itemMenuColorLB
            // 
            this.itemMenuColorLB.Name = "itemMenuColorLB";
            this.itemMenuColorLB.Size = new System.Drawing.Size(172, 22);
            this.itemMenuColorLB.Text = "Niveaux de bleu";
            this.itemMenuColorLB.Click += new System.EventHandler(this.itemMenuColorLB_Click);
            // 
            // itemMenuColorLO
            // 
            this.itemMenuColorLO.Name = "itemMenuColorLO";
            this.itemMenuColorLO.Size = new System.Drawing.Size(172, 22);
            this.itemMenuColorLO.Text = "Niveaux de orange";
            this.itemMenuColorLO.Click += new System.EventHandler(this.itemMenuColorLO_Click);
            // 
            // itemMenuColorLG
            // 
            this.itemMenuColorLG.Name = "itemMenuColorLG";
            this.itemMenuColorLG.Size = new System.Drawing.Size(172, 22);
            this.itemMenuColorLG.Text = "Niveaux de vert";
            this.itemMenuColorLG.Click += new System.EventHandler(this.itemMenuColorLG_Click);
            // 
            // controlsItemMenu
            // 
            this.controlsItemMenu.Enabled = false;
            this.controlsItemMenu.Name = "controlsItemMenu";
            this.controlsItemMenu.Size = new System.Drawing.Size(152, 22);
            this.controlsItemMenu.Text = "Contrôles";
            // 
            // cpuItemMenu
            // 
            this.cpuItemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vitesseNormalToolStripMenuItem});
            this.cpuItemMenu.Name = "cpuItemMenu";
            this.cpuItemMenu.Size = new System.Drawing.Size(152, 22);
            this.cpuItemMenu.Text = "Cpu";
            // 
            // vitesseNormalToolStripMenuItem
            // 
            this.vitesseNormalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMenuVNormal,
            this.itemMenuVSpeed,
            this.itemMenuVMoreSpeed});
            this.vitesseNormalToolStripMenuItem.Name = "vitesseNormalToolStripMenuItem";
            this.vitesseNormalToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.vitesseNormalToolStripMenuItem.Text = "Vitesse";
            // 
            // itemMenuVNormal
            // 
            this.itemMenuVNormal.Checked = true;
            this.itemMenuVNormal.CheckOnClick = true;
            this.itemMenuVNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemMenuVNormal.Name = "itemMenuVNormal";
            this.itemMenuVNormal.Size = new System.Drawing.Size(132, 22);
            this.itemMenuVNormal.Text = "Normal";
            this.itemMenuVNormal.Click += new System.EventHandler(this.itemMenuVNormal_Click);
            // 
            // itemMenuVSpeed
            // 
            this.itemMenuVSpeed.CheckOnClick = true;
            this.itemMenuVSpeed.Name = "itemMenuVSpeed";
            this.itemMenuVSpeed.Size = new System.Drawing.Size(132, 22);
            this.itemMenuVSpeed.Text = "Rapide";
            this.itemMenuVSpeed.Click += new System.EventHandler(this.itemMenuVSpeed_Click);
            // 
            // itemMenuVMoreSpeed
            // 
            this.itemMenuVMoreSpeed.CheckOnClick = true;
            this.itemMenuVMoreSpeed.Name = "itemMenuVMoreSpeed";
            this.itemMenuVMoreSpeed.Size = new System.Drawing.Size(132, 22);
            this.itemMenuVMoreSpeed.Text = "Très rapide";
            this.itemMenuVMoreSpeed.Click += new System.EventHandler(this.itemMenuVMoreSpeed_Click);
            // 
            // soundItemMenu
            // 
            this.soundItemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMenuSActive,
            this.itemMenuSDesactive});
            this.soundItemMenu.Name = "soundItemMenu";
            this.soundItemMenu.Size = new System.Drawing.Size(152, 22);
            this.soundItemMenu.Text = "Son";
            // 
            // itemMenuSActive
            // 
            this.itemMenuSActive.Checked = true;
            this.itemMenuSActive.CheckOnClick = true;
            this.itemMenuSActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemMenuSActive.Name = "itemMenuSActive";
            this.itemMenuSActive.Size = new System.Drawing.Size(128, 22);
            this.itemMenuSActive.Text = "Activer";
            this.itemMenuSActive.Click += new System.EventHandler(this.itemMenuSActive_Click);
            // 
            // itemMenuSDesactive
            // 
            this.itemMenuSDesactive.CheckOnClick = true;
            this.itemMenuSDesactive.Name = "itemMenuSDesactive";
            this.itemMenuSDesactive.Size = new System.Drawing.Size(128, 22);
            this.itemMenuSDesactive.Text = "Désactiver";
            this.itemMenuSDesactive.Click += new System.EventHandler(this.itemMenuSDesactive_Click);
            // 
            // outilsToolStripMenuItem
            // 
            this.outilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugerItemMenu,
            this.disasmItemMenu});
            this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            this.outilsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.outilsToolStripMenuItem.Text = "Outils";
            // 
            // debugerItemMenu
            // 
            this.debugerItemMenu.Name = "debugerItemMenu";
            this.debugerItemMenu.Size = new System.Drawing.Size(153, 22);
            this.debugerItemMenu.Text = "Débogguer";
            this.debugerItemMenu.Click += new System.EventHandler(this.debugerItemMenu_Click);
            // 
            // disasmItemMenu
            // 
            this.disasmItemMenu.Name = "disasmItemMenu";
            this.disasmItemMenu.Size = new System.Drawing.Size(153, 22);
            this.disasmItemMenu.Text = "Desassembleur";
            this.disasmItemMenu.Click += new System.EventHandler(this.disasmItemMenu_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpItemMenu,
            this.aboutItemMenu});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // helpItemMenu
            // 
            this.helpItemMenu.Name = "helpItemMenu";
            this.helpItemMenu.Size = new System.Drawing.Size(152, 22);
            this.helpItemMenu.Text = "Aide";
            this.helpItemMenu.Click += new System.EventHandler(this.helpItemMenu_Click);
            // 
            // aboutItemMenu
            // 
            this.aboutItemMenu.Name = "aboutItemMenu";
            this.aboutItemMenu.Size = new System.Drawing.Size(152, 22);
            this.aboutItemMenu.Text = "A propos";
            this.aboutItemMenu.Click += new System.EventHandler(this.aboutItemMenu_Click);
            // 
            // otkGLControl
            // 
            this.otkGLControl.BackColor = System.Drawing.Color.Black;
            this.otkGLControl.Location = new System.Drawing.Point(0, 27);
            this.otkGLControl.Name = "otkGLControl";
            this.otkGLControl.Size = new System.Drawing.Size(512, 256);
            this.otkGLControl.TabIndex = 2;
            this.otkGLControl.VSync = false;
            this.otkGLControl.Load += new System.EventHandler(this.otkGLControl_Load);
            this.otkGLControl.Paint += new System.Windows.Forms.PaintEventHandler(this.otkGLControl_Paint);
            this.otkGLControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.otkGLControl_KeyDown);
            this.otkGLControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.otkGLControl_KeyUp);
            this.otkGLControl.Resize += new System.EventHandler(this.otkGLControl_Resize);
            // 
            // WinformOTKRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 308);
            this.Controls.Add(this.otkGLControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WinformOTKRenderer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpChip-8";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelEtatEmu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openItemMenu;
        private System.Windows.Forms.ToolStripMenuItem quitItemMenu;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphicsItemMenu;
        private System.Windows.Forms.ToolStripMenuItem controlsItemMenu;
        private System.Windows.Forms.ToolStripMenuItem cpuItemMenu;
        private System.Windows.Forms.ToolStripMenuItem soundItemMenu;
        private System.Windows.Forms.ToolStripMenuItem outilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugerItemMenu;
        private System.Windows.Forms.ToolStripMenuItem disasmItemMenu;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpItemMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutItemMenu;
        private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startItemMenu;
        private System.Windows.Forms.ToolStripMenuItem stopItemMenu;
        private OpenTK.GLControl otkGLControl;
        private System.Windows.Forms.ToolStripMenuItem resetItemMenu;
        private System.Windows.Forms.ToolStripMenuItem résolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMenuCRNative;
        private System.Windows.Forms.ToolStripMenuItem itemMenuCRDouble;
        private System.Windows.Forms.ToolStripMenuItem itemMenuCRTriple;
        private System.Windows.Forms.ToolStripMenuItem itemMenuCRPerso;
        private System.Windows.Forms.ToolStripMenuItem vitesseNormalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMenuVNormal;
        private System.Windows.Forms.ToolStripMenuItem itemMenuVSpeed;
        private System.Windows.Forms.ToolStripMenuItem itemMenuVMoreSpeed;
        private System.Windows.Forms.ToolStripMenuItem itemMenuSActive;
        private System.Windows.Forms.ToolStripMenuItem itemMenuSDesactive;
        private System.Windows.Forms.ToolStripMenuItem couleursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMenuColorBW;
        private System.Windows.Forms.ToolStripMenuItem itemMenuColorLG;
        private System.Windows.Forms.ToolStripMenuItem itemMenuColorLB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itemMenuVirtualController;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem itemMenuColorLO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}