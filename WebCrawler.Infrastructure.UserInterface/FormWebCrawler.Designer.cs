namespace ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface
{
    partial class FormWebCrawler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebCrawler));
            this.btnStart = new System.Windows.Forms.Button();
            this.txtUri = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblForNudInstances = new System.Windows.Forms.Label();
            this.nudInstances = new System.Windows.Forms.NumericUpDown();
            this.guiUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.lblLinksSavedCount = new System.Windows.Forms.Label();
            this.nudDepth = new System.Windows.Forms.NumericUpDown();
            this.lblForNudDepth = new System.Windows.Forms.Label();
            this.dgvInstanceInfo = new System.Windows.Forms.DataGridView();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnInstance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTasks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblForTxtUrl = new System.Windows.Forms.Label();
            this.lblForNudTimeout = new System.Windows.Forms.Label();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.nudRetries = new System.Windows.Forms.NumericUpDown();
            this.lblForNudRetries = new System.Windows.Forms.Label();
            this.nudUpdateIntervalBreak = new System.Windows.Forms.NumericUpDown();
            this.lblForNudUpdateIntervalBreak = new System.Windows.Forms.Label();
            this.nudMaxTasks = new System.Windows.Forms.NumericUpDown();
            this.lblForNudMaxTasks = new System.Windows.Forms.Label();
            this.nudTaskRestockThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblForNudTaskRestockThreshold = new System.Windows.Forms.Label();
            this.nudTasksBufferSize = new System.Windows.Forms.NumericUpDown();
            this.lblForNudTasksBufferSize = new System.Windows.Forms.Label();
            this.gbInstanceHandler = new System.Windows.Forms.GroupBox();
            this.gbInstance = new System.Windows.Forms.GroupBox();
            this.nudNoTaskIntervalBreak = new System.Windows.Forms.NumericUpDown();
            this.lblForNudNoTaskIntervalBreak = new System.Windows.Forms.Label();
            this.gbCrawler = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblForNudInterfaceUpdateInterval = new System.Windows.Forms.Label();
            this.nudInterfaceUpdateInterval = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudInstances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstanceInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateIntervalBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaskRestockThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTasksBufferSize)).BeginInit();
            this.gbInstanceHandler.SuspendLayout();
            this.gbInstance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoTaskIntervalBreak)).BeginInit();
            this.gbCrawler.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterfaceUpdateInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(244, 434);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(173, 44);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtUri
            // 
            this.txtUri.Location = new System.Drawing.Point(163, 19);
            this.txtUri.Name = "txtUri";
            this.txtUri.Size = new System.Drawing.Size(415, 20);
            this.txtUri.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(423, 434);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(173, 44);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblForNudInstances
            // 
            this.lblForNudInstances.AutoSize = true;
            this.lblForNudInstances.Location = new System.Drawing.Point(6, 47);
            this.lblForNudInstances.Name = "lblForNudInstances";
            this.lblForNudInstances.Size = new System.Drawing.Size(53, 13);
            this.lblForNudInstances.TabIndex = 4;
            this.lblForNudInstances.Text = "Instances";
            // 
            // nudInstances
            // 
            this.nudInstances.Location = new System.Drawing.Point(368, 45);
            this.nudInstances.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInstances.Name = "nudInstances";
            this.nudInstances.Size = new System.Drawing.Size(210, 20);
            this.nudInstances.TabIndex = 6;
            this.nudInstances.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // guiUpdateTimer
            // 
            this.guiUpdateTimer.Interval = 2000;
            this.guiUpdateTimer.Tick += new System.EventHandler(this.guiUpdateTimer_Tick);
            // 
            // lblLinksSavedCount
            // 
            this.lblLinksSavedCount.AutoSize = true;
            this.lblLinksSavedCount.Location = new System.Drawing.Point(18, 450);
            this.lblLinksSavedCount.Name = "lblLinksSavedCount";
            this.lblLinksSavedCount.Size = new System.Drawing.Size(0, 13);
            this.lblLinksSavedCount.TabIndex = 7;
            // 
            // nudDepth
            // 
            this.nudDepth.Location = new System.Drawing.Point(368, 71);
            this.nudDepth.Name = "nudDepth";
            this.nudDepth.Size = new System.Drawing.Size(210, 20);
            this.nudDepth.TabIndex = 9;
            this.nudDepth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblForNudDepth
            // 
            this.lblForNudDepth.AutoSize = true;
            this.lblForNudDepth.Location = new System.Drawing.Point(6, 73);
            this.lblForNudDepth.Name = "lblForNudDepth";
            this.lblForNudDepth.Size = new System.Drawing.Size(36, 13);
            this.lblForNudDepth.TabIndex = 8;
            this.lblForNudDepth.Text = "Depth";
            // 
            // dgvInstanceInfo
            // 
            this.dgvInstanceInfo.AllowUserToAddRows = false;
            this.dgvInstanceInfo.AllowUserToDeleteRows = false;
            this.dgvInstanceInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInstanceInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvInstanceInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstanceInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStatus,
            this.ColumnInstance,
            this.ColumnTasks});
            this.dgvInstanceInfo.Location = new System.Drawing.Point(618, 11);
            this.dgvInstanceInfo.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInstanceInfo.MultiSelect = false;
            this.dgvInstanceInfo.Name = "dgvInstanceInfo";
            this.dgvInstanceInfo.ReadOnly = true;
            this.dgvInstanceInfo.RowHeadersVisible = false;
            this.dgvInstanceInfo.RowTemplate.Height = 33;
            this.dgvInstanceInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInstanceInfo.Size = new System.Drawing.Size(353, 467);
            this.dgvInstanceInfo.TabIndex = 10;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "Status";
            this.ColumnStatus.FillWeight = 1F;
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnStatus.MinimumWidth = 50;
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // ColumnInstance
            // 
            this.ColumnInstance.DataPropertyName = "Instance";
            this.ColumnInstance.FillWeight = 75.21624F;
            this.ColumnInstance.HeaderText = "Instance";
            this.ColumnInstance.MinimumWidth = 100;
            this.ColumnInstance.Name = "ColumnInstance";
            this.ColumnInstance.ReadOnly = true;
            this.ColumnInstance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnTasks
            // 
            this.ColumnTasks.DataPropertyName = "Tasks";
            this.ColumnTasks.FillWeight = 1F;
            this.ColumnTasks.HeaderText = "Tasks";
            this.ColumnTasks.MinimumWidth = 75;
            this.ColumnTasks.Name = "ColumnTasks";
            this.ColumnTasks.ReadOnly = true;
            this.ColumnTasks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblForTxtUrl
            // 
            this.lblForTxtUrl.AutoSize = true;
            this.lblForTxtUrl.Location = new System.Drawing.Point(6, 22);
            this.lblForTxtUrl.Name = "lblForTxtUrl";
            this.lblForTxtUrl.Size = new System.Drawing.Size(59, 13);
            this.lblForTxtUrl.TabIndex = 11;
            this.lblForTxtUrl.Text = "Starting Uri";
            // 
            // lblForNudTimeout
            // 
            this.lblForNudTimeout.AutoSize = true;
            this.lblForNudTimeout.Location = new System.Drawing.Point(6, 99);
            this.lblForNudTimeout.Name = "lblForNudTimeout";
            this.lblForNudTimeout.Size = new System.Drawing.Size(67, 13);
            this.lblForNudTimeout.TabIndex = 12;
            this.lblForNudTimeout.Text = "Timeout (ms)";
            // 
            // nudTimeout
            // 
            this.nudTimeout.Location = new System.Drawing.Point(368, 97);
            this.nudTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTimeout.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(210, 20);
            this.nudTimeout.TabIndex = 13;
            this.nudTimeout.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // nudRetries
            // 
            this.nudRetries.Location = new System.Drawing.Point(368, 123);
            this.nudRetries.Name = "nudRetries";
            this.nudRetries.Size = new System.Drawing.Size(210, 20);
            this.nudRetries.TabIndex = 15;
            this.nudRetries.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblForNudRetries
            // 
            this.lblForNudRetries.AutoSize = true;
            this.lblForNudRetries.Location = new System.Drawing.Point(6, 125);
            this.lblForNudRetries.Name = "lblForNudRetries";
            this.lblForNudRetries.Size = new System.Drawing.Size(40, 13);
            this.lblForNudRetries.TabIndex = 14;
            this.lblForNudRetries.Text = "Retries";
            // 
            // nudUpdateIntervalBreak
            // 
            this.nudUpdateIntervalBreak.Location = new System.Drawing.Point(368, 19);
            this.nudUpdateIntervalBreak.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudUpdateIntervalBreak.Name = "nudUpdateIntervalBreak";
            this.nudUpdateIntervalBreak.Size = new System.Drawing.Size(210, 20);
            this.nudUpdateIntervalBreak.TabIndex = 17;
            this.nudUpdateIntervalBreak.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // lblForNudUpdateIntervalBreak
            // 
            this.lblForNudUpdateIntervalBreak.AutoSize = true;
            this.lblForNudUpdateIntervalBreak.Location = new System.Drawing.Point(6, 21);
            this.lblForNudUpdateIntervalBreak.Name = "lblForNudUpdateIntervalBreak";
            this.lblForNudUpdateIntervalBreak.Size = new System.Drawing.Size(133, 13);
            this.lblForNudUpdateIntervalBreak.TabIndex = 16;
            this.lblForNudUpdateIntervalBreak.Text = "Update Interval Break (ms)";
            // 
            // nudMaxTasks
            // 
            this.nudMaxTasks.Location = new System.Drawing.Point(368, 19);
            this.nudMaxTasks.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMaxTasks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxTasks.Name = "nudMaxTasks";
            this.nudMaxTasks.Size = new System.Drawing.Size(210, 20);
            this.nudMaxTasks.TabIndex = 19;
            this.nudMaxTasks.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblForNudMaxTasks
            // 
            this.lblForNudMaxTasks.AutoSize = true;
            this.lblForNudMaxTasks.Location = new System.Drawing.Point(6, 21);
            this.lblForNudMaxTasks.Name = "lblForNudMaxTasks";
            this.lblForNudMaxTasks.Size = new System.Drawing.Size(59, 13);
            this.lblForNudMaxTasks.TabIndex = 18;
            this.lblForNudMaxTasks.Text = "Max Tasks";
            // 
            // nudTaskRestockThreshold
            // 
            this.nudTaskRestockThreshold.Location = new System.Drawing.Point(368, 45);
            this.nudTaskRestockThreshold.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTaskRestockThreshold.Name = "nudTaskRestockThreshold";
            this.nudTaskRestockThreshold.Size = new System.Drawing.Size(210, 20);
            this.nudTaskRestockThreshold.TabIndex = 21;
            this.nudTaskRestockThreshold.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblForNudTaskRestockThreshold
            // 
            this.lblForNudTaskRestockThreshold.AutoSize = true;
            this.lblForNudTaskRestockThreshold.Location = new System.Drawing.Point(6, 47);
            this.lblForNudTaskRestockThreshold.Name = "lblForNudTaskRestockThreshold";
            this.lblForNudTaskRestockThreshold.Size = new System.Drawing.Size(124, 13);
            this.lblForNudTaskRestockThreshold.TabIndex = 20;
            this.lblForNudTaskRestockThreshold.Text = "Task Restock Threshold";
            // 
            // nudTasksBufferSize
            // 
            this.nudTasksBufferSize.Location = new System.Drawing.Point(368, 45);
            this.nudTasksBufferSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTasksBufferSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTasksBufferSize.Name = "nudTasksBufferSize";
            this.nudTasksBufferSize.Size = new System.Drawing.Size(210, 20);
            this.nudTasksBufferSize.TabIndex = 23;
            this.nudTasksBufferSize.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblForNudTasksBufferSize
            // 
            this.lblForNudTasksBufferSize.AutoSize = true;
            this.lblForNudTasksBufferSize.Location = new System.Drawing.Point(6, 47);
            this.lblForNudTasksBufferSize.Name = "lblForNudTasksBufferSize";
            this.lblForNudTasksBufferSize.Size = new System.Drawing.Size(90, 13);
            this.lblForNudTasksBufferSize.TabIndex = 22;
            this.lblForNudTasksBufferSize.Text = "Tasks Buffer Size";
            // 
            // gbInstanceHandler
            // 
            this.gbInstanceHandler.BackColor = System.Drawing.SystemColors.Window;
            this.gbInstanceHandler.Controls.Add(this.lblForNudUpdateIntervalBreak);
            this.gbInstanceHandler.Controls.Add(this.nudTasksBufferSize);
            this.gbInstanceHandler.Controls.Add(this.nudUpdateIntervalBreak);
            this.gbInstanceHandler.Controls.Add(this.lblForNudTasksBufferSize);
            this.gbInstanceHandler.Location = new System.Drawing.Point(12, 169);
            this.gbInstanceHandler.Name = "gbInstanceHandler";
            this.gbInstanceHandler.Size = new System.Drawing.Size(584, 75);
            this.gbInstanceHandler.TabIndex = 24;
            this.gbInstanceHandler.TabStop = false;
            this.gbInstanceHandler.Text = "Instance Handler";
            // 
            // gbInstance
            // 
            this.gbInstance.BackColor = System.Drawing.SystemColors.Window;
            this.gbInstance.Controls.Add(this.nudNoTaskIntervalBreak);
            this.gbInstance.Controls.Add(this.lblForNudNoTaskIntervalBreak);
            this.gbInstance.Controls.Add(this.lblForNudMaxTasks);
            this.gbInstance.Controls.Add(this.nudMaxTasks);
            this.gbInstance.Controls.Add(this.nudTaskRestockThreshold);
            this.gbInstance.Controls.Add(this.lblForNudTaskRestockThreshold);
            this.gbInstance.Location = new System.Drawing.Point(12, 250);
            this.gbInstance.Name = "gbInstance";
            this.gbInstance.Size = new System.Drawing.Size(584, 100);
            this.gbInstance.TabIndex = 25;
            this.gbInstance.TabStop = false;
            this.gbInstance.Text = "Instance";
            // 
            // nudNoTaskIntervalBreak
            // 
            this.nudNoTaskIntervalBreak.Location = new System.Drawing.Point(368, 71);
            this.nudNoTaskIntervalBreak.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudNoTaskIntervalBreak.Name = "nudNoTaskIntervalBreak";
            this.nudNoTaskIntervalBreak.Size = new System.Drawing.Size(210, 20);
            this.nudNoTaskIntervalBreak.TabIndex = 23;
            this.nudNoTaskIntervalBreak.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblForNudNoTaskIntervalBreak
            // 
            this.lblForNudNoTaskIntervalBreak.AutoSize = true;
            this.lblForNudNoTaskIntervalBreak.Location = new System.Drawing.Point(6, 73);
            this.lblForNudNoTaskIntervalBreak.Name = "lblForNudNoTaskIntervalBreak";
            this.lblForNudNoTaskIntervalBreak.Size = new System.Drawing.Size(139, 13);
            this.lblForNudNoTaskIntervalBreak.TabIndex = 22;
            this.lblForNudNoTaskIntervalBreak.Text = "No Task Interval Break (ms)";
            // 
            // gbCrawler
            // 
            this.gbCrawler.BackColor = System.Drawing.SystemColors.Window;
            this.gbCrawler.Controls.Add(this.lblForTxtUrl);
            this.gbCrawler.Controls.Add(this.txtUri);
            this.gbCrawler.Controls.Add(this.lblForNudInstances);
            this.gbCrawler.Controls.Add(this.nudRetries);
            this.gbCrawler.Controls.Add(this.nudInstances);
            this.gbCrawler.Controls.Add(this.lblForNudRetries);
            this.gbCrawler.Controls.Add(this.nudTimeout);
            this.gbCrawler.Controls.Add(this.lblForNudTimeout);
            this.gbCrawler.Controls.Add(this.lblForNudDepth);
            this.gbCrawler.Controls.Add(this.nudDepth);
            this.gbCrawler.Location = new System.Drawing.Point(12, 11);
            this.gbCrawler.Name = "gbCrawler";
            this.gbCrawler.Size = new System.Drawing.Size(584, 152);
            this.gbCrawler.TabIndex = 26;
            this.gbCrawler.TabStop = false;
            this.gbCrawler.Text = "Crawler";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.lblForNudInterfaceUpdateInterval);
            this.groupBox1.Controls.Add(this.nudInterfaceUpdateInterval);
            this.groupBox1.Location = new System.Drawing.Point(12, 356);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 54);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application";
            // 
            // lblForNudInterfaceUpdateInterval
            // 
            this.lblForNudInterfaceUpdateInterval.AutoSize = true;
            this.lblForNudInterfaceUpdateInterval.Location = new System.Drawing.Point(6, 21);
            this.lblForNudInterfaceUpdateInterval.Name = "lblForNudInterfaceUpdateInterval";
            this.lblForNudInterfaceUpdateInterval.Size = new System.Drawing.Size(147, 13);
            this.lblForNudInterfaceUpdateInterval.TabIndex = 18;
            this.lblForNudInterfaceUpdateInterval.Text = "Interface Update Interval (ms)";
            // 
            // nudInterfaceUpdateInterval
            // 
            this.nudInterfaceUpdateInterval.Location = new System.Drawing.Point(368, 19);
            this.nudInterfaceUpdateInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudInterfaceUpdateInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterfaceUpdateInterval.Name = "nudInterfaceUpdateInterval";
            this.nudInterfaceUpdateInterval.Size = new System.Drawing.Size(210, 20);
            this.nudInterfaceUpdateInterval.TabIndex = 19;
            this.nudInterfaceUpdateInterval.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudInterfaceUpdateInterval.ValueChanged += new System.EventHandler(this.nudInterfaceUpdateInterval_ValueChanged);
            // 
            // FormWebCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(979, 487);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbCrawler);
            this.Controls.Add(this.gbInstance);
            this.Controls.Add(this.gbInstanceHandler);
            this.Controls.Add(this.dgvInstanceInfo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblLinksSavedCount);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormWebCrawler";
            this.Text = "WebCrawler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWebCrawler_FormClosing);
            this.Load += new System.EventHandler(this.FormWebCrawler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudInstances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstanceInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateIntervalBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaskRestockThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTasksBufferSize)).EndInit();
            this.gbInstanceHandler.ResumeLayout(false);
            this.gbInstanceHandler.PerformLayout();
            this.gbInstance.ResumeLayout(false);
            this.gbInstance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoTaskIntervalBreak)).EndInit();
            this.gbCrawler.ResumeLayout(false);
            this.gbCrawler.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterfaceUpdateInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtUri;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblForNudInstances;
        private System.Windows.Forms.NumericUpDown nudInstances;
        private System.Windows.Forms.Timer guiUpdateTimer;
        private System.Windows.Forms.Label lblLinksSavedCount;
        private System.Windows.Forms.NumericUpDown nudDepth;
        private System.Windows.Forms.Label lblForNudDepth;
        private System.Windows.Forms.DataGridView dgvInstanceInfo;
        private System.Windows.Forms.Label lblForTxtUrl;
        private System.Windows.Forms.DataGridViewImageColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInstance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTasks;
        private System.Windows.Forms.Label lblForNudTimeout;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.NumericUpDown nudRetries;
        private System.Windows.Forms.Label lblForNudRetries;
        private System.Windows.Forms.NumericUpDown nudUpdateIntervalBreak;
        private System.Windows.Forms.Label lblForNudUpdateIntervalBreak;
        private System.Windows.Forms.NumericUpDown nudMaxTasks;
        private System.Windows.Forms.Label lblForNudMaxTasks;
        private System.Windows.Forms.NumericUpDown nudTaskRestockThreshold;
        private System.Windows.Forms.Label lblForNudTaskRestockThreshold;
        private System.Windows.Forms.NumericUpDown nudTasksBufferSize;
        private System.Windows.Forms.Label lblForNudTasksBufferSize;
        private System.Windows.Forms.GroupBox gbInstanceHandler;
        private System.Windows.Forms.GroupBox gbInstance;
        private System.Windows.Forms.NumericUpDown nudNoTaskIntervalBreak;
        private System.Windows.Forms.Label lblForNudNoTaskIntervalBreak;
        private System.Windows.Forms.GroupBox gbCrawler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblForNudInterfaceUpdateInterval;
        private System.Windows.Forms.NumericUpDown nudInterfaceUpdateInterval;
    }
}