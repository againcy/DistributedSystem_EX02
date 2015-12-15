namespace DistributedSystem_EX02
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_addEntry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_addEntry
            // 
            this.button_addEntry.Location = new System.Drawing.Point(12, 12);
            this.button_addEntry.Name = "button_addEntry";
            this.button_addEntry.Size = new System.Drawing.Size(88, 33);
            this.button_addEntry.TabIndex = 0;
            this.button_addEntry.Text = "添加入口";
            this.button_addEntry.UseVisualStyleBackColor = true;
            this.button_addEntry.Click += new System.EventHandler(this.button_addEntry_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button_addEntry);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_addEntry;
    }
}

