namespace DistributedSystem_EX02
{
    partial class EntryForm
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
            this.button_enter = new System.Windows.Forms.Button();
            this.label_id = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.label_parkState = new System.Windows.Forms.Label();
            this.label_curTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button_enter
            // 
            this.button_enter.Location = new System.Drawing.Point(12, 111);
            this.button_enter.Name = "button_enter";
            this.button_enter.Size = new System.Drawing.Size(79, 34);
            this.button_enter.TabIndex = 0;
            this.button_enter.Text = "入库";
            this.button_enter.UseVisualStyleBackColor = true;
            this.button_enter.Click += new System.EventHandler(this.button_enter_Click);
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(12, 9);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(53, 12);
            this.label_id.TabIndex = 1;
            this.label_id.Text = "Entry id";
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(12, 53);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(35, 12);
            this.label_state.TabIndex = 2;
            this.label_state.Text = "state";
            // 
            // label_parkState
            // 
            this.label_parkState.AutoSize = true;
            this.label_parkState.Location = new System.Drawing.Point(12, 31);
            this.label_parkState.Name = "label_parkState";
            this.label_parkState.Size = new System.Drawing.Size(53, 12);
            this.label_parkState.TabIndex = 3;
            this.label_parkState.Text = "ParkSate";
            // 
            // label_curTime
            // 
            this.label_curTime.AutoSize = true;
            this.label_curTime.Location = new System.Drawing.Point(12, 96);
            this.label_curTime.Name = "label_curTime";
            this.label_curTime.Size = new System.Drawing.Size(47, 12);
            this.label_curTime.TabIndex = 4;
            this.label_curTime.Text = "curTime";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 170);
            this.Controls.Add(this.label_curTime);
            this.Controls.Add(this.label_parkState);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.button_enter);
            this.Name = "EntryForm";
            this.Text = "EntryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_enter;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label_parkState;
        private System.Windows.Forms.Label label_curTime;
        private System.Windows.Forms.Timer timer1;
    }
}