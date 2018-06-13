namespace AStarAlgorithm
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMap = new System.Windows.Forms.DataGridView();
            this.btnCreateMap = new System.Windows.Forms.Button();
            this.btnSetStart = new System.Windows.Forms.Button();
            this.btnSetFinish = new System.Windows.Forms.Button();
            this.btnClearMap = new System.Windows.Forms.Button();
            this.btnSetWall = new System.Windows.Forms.Button();
            this.btnPathFinding = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMap
            // 
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dgvMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMap.ColumnHeadersVisible = false;
            this.dgvMap.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMap.Location = new System.Drawing.Point(18, 18);
            this.dgvMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMap.Name = "dgvMap";
            this.dgvMap.RowHeadersVisible = false;
            this.dgvMap.Size = new System.Drawing.Size(869, 718);
            this.dgvMap.TabIndex = 0;
            this.dgvMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvMap_MouseClick);
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCreateMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateMap.Location = new System.Drawing.Point(1044, 77);
            this.btnCreateMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateMap.Name = "btnCreateMap";
            this.btnCreateMap.Size = new System.Drawing.Size(180, 55);
            this.btnCreateMap.TabIndex = 1;
            this.btnCreateMap.Text = "Create a Map (1)";
            this.btnCreateMap.UseVisualStyleBackColor = false;
            this.btnCreateMap.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSetStart
            // 
            this.btnSetStart.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSetStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetStart.Location = new System.Drawing.Point(18, 763);
            this.btnSetStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetStart.Name = "btnSetStart";
            this.btnSetStart.Size = new System.Drawing.Size(291, 44);
            this.btnSetStart.TabIndex = 2;
            this.btnSetStart.Text = "set START (2)";
            this.btnSetStart.UseVisualStyleBackColor = false;
            this.btnSetStart.Click += new System.EventHandler(this.btnSetStart_Click);
            // 
            // btnSetFinish
            // 
            this.btnSetFinish.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSetFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetFinish.Location = new System.Drawing.Point(602, 763);
            this.btnSetFinish.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetFinish.Name = "btnSetFinish";
            this.btnSetFinish.Size = new System.Drawing.Size(285, 44);
            this.btnSetFinish.TabIndex = 3;
            this.btnSetFinish.Text = "set FINISH (4)";
            this.btnSetFinish.UseVisualStyleBackColor = false;
            this.btnSetFinish.Click += new System.EventHandler(this.btnSetFinish_Click);
            // 
            // btnClearMap
            // 
            this.btnClearMap.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClearMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearMap.Location = new System.Drawing.Point(1044, 142);
            this.btnClearMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearMap.Name = "btnClearMap";
            this.btnClearMap.Size = new System.Drawing.Size(180, 51);
            this.btnClearMap.TabIndex = 4;
            this.btnClearMap.Text = "Clear a Map";
            this.btnClearMap.UseVisualStyleBackColor = false;
            this.btnClearMap.Click += new System.EventHandler(this.btnClearMap_Click);
            // 
            // btnSetWall
            // 
            this.btnSetWall.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSetWall.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetWall.Location = new System.Drawing.Point(331, 763);
            this.btnSetWall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetWall.Name = "btnSetWall";
            this.btnSetWall.Size = new System.Drawing.Size(254, 44);
            this.btnSetWall.TabIndex = 5;
            this.btnSetWall.Text = "Set Obstacle Path (3)";
            this.btnSetWall.UseVisualStyleBackColor = false;
            this.btnSetWall.Click += new System.EventHandler(this.btnSetWall_Click);
            // 
            // btnPathFinding
            // 
            this.btnPathFinding.BackColor = System.Drawing.Color.Maroon;
            this.btnPathFinding.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathFinding.Location = new System.Drawing.Point(1044, 410);
            this.btnPathFinding.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPathFinding.Name = "btnPathFinding";
            this.btnPathFinding.Size = new System.Drawing.Size(166, 45);
            this.btnPathFinding.TabIndex = 6;
            this.btnPathFinding.Text = "Find a Path (5)";
            this.btnPathFinding.UseVisualStyleBackColor = false;
            this.btnPathFinding.Click += new System.EventHandler(this.btnPathFinding_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(1183, 749);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 48);
            this.label1.TabIndex = 7;
            this.label1.Text = "Suraj Fehintola (CSC831 Assignment)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1866, 874);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPathFinding);
            this.Controls.Add(this.btnSetWall);
            this.Controls.Add(this.btnClearMap);
            this.Controls.Add(this.btnSetFinish);
            this.Controls.Add(this.btnSetStart);
            this.Controls.Add(this.btnCreateMap);
            this.Controls.Add(this.dgvMap);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMap;
        private System.Windows.Forms.Button btnCreateMap;
        private System.Windows.Forms.Button btnSetStart;
        private System.Windows.Forms.Button btnSetFinish;
        private System.Windows.Forms.Button btnClearMap;
        private System.Windows.Forms.Button btnSetWall;
        private System.Windows.Forms.Button btnPathFinding;
        private System.Windows.Forms.Label label1;
    }
}

