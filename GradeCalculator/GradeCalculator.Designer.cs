namespace GradeCalculator
{
    partial class frmGradeCalculatorShoo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGradeCalculatorShoo));
            this.grbGradingMethodShoo = new System.Windows.Forms.GroupBox();
            this.rdbParabolaShoo = new System.Windows.Forms.RadioButton();
            this.rdbLinearShoo = new System.Windows.Forms.RadioButton();
            this.lblGradeMethodStaticShoo = new System.Windows.Forms.Label();
            this.tbxCeasuraShoo = new System.Windows.Forms.TextBox();
            this.lblCeasuraStaticShoo = new System.Windows.Forms.Label();
            this.tbxMaxPointsShoo = new System.Windows.Forms.TextBox();
            this.lblMaxPointsStaticShoo = new System.Windows.Forms.Label();
            this.grbGradeOutputShoo = new System.Windows.Forms.GroupBox();
            this.btnGeneratePdfShoo = new System.Windows.Forms.Button();
            this.lblGradeShoo = new System.Windows.Forms.Label();
            this.lblPointsShoo = new System.Windows.Forms.Label();
            this.lblGradeStaticShoo = new System.Windows.Forms.Label();
            this.lblPointsStaticShoo = new System.Windows.Forms.Label();
            this.lblGradeAtPointsStaticShoo = new System.Windows.Forms.Label();
            this.lblCalculateGradeStatic2Shoo = new System.Windows.Forms.Label();
            this.lblCalculateGradeStatic1Shoo = new System.Windows.Forms.Label();
            this.tbxPointAmountShoo = new System.Windows.Forms.TextBox();
            this.grbGradingMethodShoo.SuspendLayout();
            this.grbGradeOutputShoo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbGradingMethodShoo
            // 
            this.grbGradingMethodShoo.Controls.Add(this.rdbParabolaShoo);
            this.grbGradingMethodShoo.Controls.Add(this.rdbLinearShoo);
            this.grbGradingMethodShoo.Controls.Add(this.lblGradeMethodStaticShoo);
            this.grbGradingMethodShoo.Controls.Add(this.tbxCeasuraShoo);
            this.grbGradingMethodShoo.Controls.Add(this.lblCeasuraStaticShoo);
            this.grbGradingMethodShoo.Controls.Add(this.tbxMaxPointsShoo);
            this.grbGradingMethodShoo.Controls.Add(this.lblMaxPointsStaticShoo);
            this.grbGradingMethodShoo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGradingMethodShoo.Location = new System.Drawing.Point(12, 12);
            this.grbGradingMethodShoo.Name = "grbGradingMethodShoo";
            this.grbGradingMethodShoo.Size = new System.Drawing.Size(521, 78);
            this.grbGradingMethodShoo.TabIndex = 0;
            this.grbGradingMethodShoo.TabStop = false;
            this.grbGradingMethodShoo.Text = "Grading method";
            // 
            // rdbParabolaShoo
            // 
            this.rdbParabolaShoo.AutoSize = true;
            this.rdbParabolaShoo.Location = new System.Drawing.Point(430, 49);
            this.rdbParabolaShoo.Name = "rdbParabolaShoo";
            this.rdbParabolaShoo.Size = new System.Drawing.Size(85, 22);
            this.rdbParabolaShoo.TabIndex = 4;
            this.rdbParabolaShoo.Text = "Parabola";
            this.rdbParabolaShoo.UseVisualStyleBackColor = true;
            this.rdbParabolaShoo.CheckedChanged += new System.EventHandler(this.rdbParabolaShoo_CheckedChanged);
            // 
            // rdbLinearShoo
            // 
            this.rdbLinearShoo.AutoSize = true;
            this.rdbLinearShoo.Checked = true;
            this.rdbLinearShoo.Location = new System.Drawing.Point(341, 49);
            this.rdbLinearShoo.Name = "rdbLinearShoo";
            this.rdbLinearShoo.Size = new System.Drawing.Size(66, 22);
            this.rdbLinearShoo.TabIndex = 3;
            this.rdbLinearShoo.TabStop = true;
            this.rdbLinearShoo.Text = "Linear";
            this.rdbLinearShoo.UseVisualStyleBackColor = true;
            this.rdbLinearShoo.CheckedChanged += new System.EventHandler(this.rdbLinearShoo_CheckedChanged);
            // 
            // lblGradeMethodStaticShoo
            // 
            this.lblGradeMethodStaticShoo.AutoSize = true;
            this.lblGradeMethodStaticShoo.Location = new System.Drawing.Point(338, 28);
            this.lblGradeMethodStaticShoo.Name = "lblGradeMethodStaticShoo";
            this.lblGradeMethodStaticShoo.Size = new System.Drawing.Size(177, 18);
            this.lblGradeMethodStaticShoo.TabIndex = 2;
            this.lblGradeMethodStaticShoo.Text = "Grade calculation method";
            // 
            // tbxCeasuraShoo
            // 
            this.tbxCeasuraShoo.Location = new System.Drawing.Point(174, 48);
            this.tbxCeasuraShoo.MaxLength = 6;
            this.tbxCeasuraShoo.Name = "tbxCeasuraShoo";
            this.tbxCeasuraShoo.Size = new System.Drawing.Size(117, 24);
            this.tbxCeasuraShoo.TabIndex = 1;
            this.tbxCeasuraShoo.Text = "5.5";
            this.tbxCeasuraShoo.TextChanged += new System.EventHandler(this.tbxCeasuraShoo_TextChanged);
            this.tbxCeasuraShoo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumericKeyPressShoo);
            // 
            // lblCeasuraStaticShoo
            // 
            this.lblCeasuraStaticShoo.AutoSize = true;
            this.lblCeasuraStaticShoo.Location = new System.Drawing.Point(171, 27);
            this.lblCeasuraStaticShoo.Name = "lblCeasuraStaticShoo";
            this.lblCeasuraStaticShoo.Size = new System.Drawing.Size(64, 18);
            this.lblCeasuraStaticShoo.TabIndex = 0;
            this.lblCeasuraStaticShoo.Text = "Ceasura";
            // 
            // tbxMaxPointsShoo
            // 
            this.tbxMaxPointsShoo.Location = new System.Drawing.Point(6, 48);
            this.tbxMaxPointsShoo.MaxLength = 6;
            this.tbxMaxPointsShoo.Name = "tbxMaxPointsShoo";
            this.tbxMaxPointsShoo.Size = new System.Drawing.Size(117, 24);
            this.tbxMaxPointsShoo.TabIndex = 1;
            this.tbxMaxPointsShoo.Text = "10";
            this.tbxMaxPointsShoo.TextChanged += new System.EventHandler(this.tbxMaxPointsShoo_TextChanged);
            this.tbxMaxPointsShoo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumericKeyPressShoo);
            // 
            // lblMaxPointsStaticShoo
            // 
            this.lblMaxPointsStaticShoo.AutoSize = true;
            this.lblMaxPointsStaticShoo.Location = new System.Drawing.Point(6, 27);
            this.lblMaxPointsStaticShoo.Name = "lblMaxPointsStaticShoo";
            this.lblMaxPointsStaticShoo.Size = new System.Drawing.Size(117, 18);
            this.lblMaxPointsStaticShoo.TabIndex = 0;
            this.lblMaxPointsStaticShoo.Text = "Maximum points";
            // 
            // grbGradeOutputShoo
            // 
            this.grbGradeOutputShoo.Controls.Add(this.btnGeneratePdfShoo);
            this.grbGradeOutputShoo.Controls.Add(this.lblGradeShoo);
            this.grbGradeOutputShoo.Controls.Add(this.lblPointsShoo);
            this.grbGradeOutputShoo.Controls.Add(this.lblGradeStaticShoo);
            this.grbGradeOutputShoo.Controls.Add(this.lblPointsStaticShoo);
            this.grbGradeOutputShoo.Controls.Add(this.lblGradeAtPointsStaticShoo);
            this.grbGradeOutputShoo.Controls.Add(this.lblCalculateGradeStatic2Shoo);
            this.grbGradeOutputShoo.Controls.Add(this.lblCalculateGradeStatic1Shoo);
            this.grbGradeOutputShoo.Controls.Add(this.tbxPointAmountShoo);
            this.grbGradeOutputShoo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGradeOutputShoo.Location = new System.Drawing.Point(12, 96);
            this.grbGradeOutputShoo.Name = "grbGradeOutputShoo";
            this.grbGradeOutputShoo.Size = new System.Drawing.Size(521, 99);
            this.grbGradeOutputShoo.TabIndex = 1;
            this.grbGradeOutputShoo.TabStop = false;
            this.grbGradeOutputShoo.Text = "Grade output";
            // 
            // btnGeneratePdfShoo
            // 
            this.btnGeneratePdfShoo.Location = new System.Drawing.Point(341, 23);
            this.btnGeneratePdfShoo.Name = "btnGeneratePdfShoo";
            this.btnGeneratePdfShoo.Size = new System.Drawing.Size(174, 64);
            this.btnGeneratePdfShoo.TabIndex = 6;
            this.btnGeneratePdfShoo.Text = "Generate PDF";
            this.btnGeneratePdfShoo.UseVisualStyleBackColor = true;
            this.btnGeneratePdfShoo.Click += new System.EventHandler(this.btnGeneratePdfShoo_Click);
            // 
            // lblGradeShoo
            // 
            this.lblGradeShoo.AutoSize = true;
            this.lblGradeShoo.Location = new System.Drawing.Point(231, 69);
            this.lblGradeShoo.Name = "lblGradeShoo";
            this.lblGradeShoo.Size = new System.Drawing.Size(24, 18);
            this.lblGradeShoo.TabIndex = 5;
            this.lblGradeShoo.Text = "10";
            // 
            // lblPointsShoo
            // 
            this.lblPointsShoo.AutoSize = true;
            this.lblPointsShoo.Location = new System.Drawing.Point(231, 46);
            this.lblPointsShoo.Name = "lblPointsShoo";
            this.lblPointsShoo.Size = new System.Drawing.Size(24, 18);
            this.lblPointsShoo.TabIndex = 5;
            this.lblPointsShoo.Text = "10";
            // 
            // lblGradeStaticShoo
            // 
            this.lblGradeStaticShoo.AutoSize = true;
            this.lblGradeStaticShoo.Location = new System.Drawing.Point(171, 69);
            this.lblGradeStaticShoo.Name = "lblGradeStaticShoo";
            this.lblGradeStaticShoo.Size = new System.Drawing.Size(53, 18);
            this.lblGradeStaticShoo.TabIndex = 4;
            this.lblGradeStaticShoo.Text = "Grade:";
            // 
            // lblPointsStaticShoo
            // 
            this.lblPointsStaticShoo.AutoSize = true;
            this.lblPointsStaticShoo.Location = new System.Drawing.Point(171, 45);
            this.lblPointsStaticShoo.Name = "lblPointsStaticShoo";
            this.lblPointsStaticShoo.Size = new System.Drawing.Size(54, 18);
            this.lblPointsStaticShoo.TabIndex = 3;
            this.lblPointsStaticShoo.Text = "Points:";
            // 
            // lblGradeAtPointsStaticShoo
            // 
            this.lblGradeAtPointsStaticShoo.AutoSize = true;
            this.lblGradeAtPointsStaticShoo.Location = new System.Drawing.Point(171, 20);
            this.lblGradeAtPointsStaticShoo.Name = "lblGradeAtPointsStaticShoo";
            this.lblGradeAtPointsStaticShoo.Size = new System.Drawing.Size(125, 18);
            this.lblGradeAtPointsStaticShoo.TabIndex = 2;
            this.lblGradeAtPointsStaticShoo.Text = "Grade at # points:";
            // 
            // lblCalculateGradeStatic2Shoo
            // 
            this.lblCalculateGradeStatic2Shoo.AutoSize = true;
            this.lblCalculateGradeStatic2Shoo.Location = new System.Drawing.Point(6, 45);
            this.lblCalculateGradeStatic2Shoo.Name = "lblCalculateGradeStatic2Shoo";
            this.lblCalculateGradeStatic2Shoo.Size = new System.Drawing.Size(76, 18);
            this.lblCalculateGradeStatic2Shoo.TabIndex = 0;
            this.lblCalculateGradeStatic2Shoo.Text = "at # points";
            // 
            // lblCalculateGradeStatic1Shoo
            // 
            this.lblCalculateGradeStatic1Shoo.AutoSize = true;
            this.lblCalculateGradeStatic1Shoo.Location = new System.Drawing.Point(6, 27);
            this.lblCalculateGradeStatic1Shoo.Name = "lblCalculateGradeStatic1Shoo";
            this.lblCalculateGradeStatic1Shoo.Size = new System.Drawing.Size(110, 18);
            this.lblCalculateGradeStatic1Shoo.TabIndex = 0;
            this.lblCalculateGradeStatic1Shoo.Text = "Calculate grade";
            // 
            // tbxPointAmountShoo
            // 
            this.tbxPointAmountShoo.Location = new System.Drawing.Point(6, 66);
            this.tbxPointAmountShoo.MaxLength = 6;
            this.tbxPointAmountShoo.Name = "tbxPointAmountShoo";
            this.tbxPointAmountShoo.Size = new System.Drawing.Size(117, 24);
            this.tbxPointAmountShoo.TabIndex = 1;
            this.tbxPointAmountShoo.Text = "10";
            this.tbxPointAmountShoo.TextChanged += new System.EventHandler(this.tbxPointAmountShoo_TextChanged);
            this.tbxPointAmountShoo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumericKeyPressShoo);
            // 
            // frmGradeCalculatorShoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 207);
            this.Controls.Add(this.grbGradeOutputShoo);
            this.Controls.Add(this.grbGradingMethodShoo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGradeCalculatorShoo";
            this.Text = "Grade Calculator";
            this.grbGradingMethodShoo.ResumeLayout(false);
            this.grbGradingMethodShoo.PerformLayout();
            this.grbGradeOutputShoo.ResumeLayout(false);
            this.grbGradeOutputShoo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGradingMethodShoo;
        private System.Windows.Forms.TextBox tbxMaxPointsShoo;
        private System.Windows.Forms.Label lblMaxPointsStaticShoo;
        private System.Windows.Forms.GroupBox grbGradeOutputShoo;
        private System.Windows.Forms.RadioButton rdbParabolaShoo;
        private System.Windows.Forms.RadioButton rdbLinearShoo;
        private System.Windows.Forms.Label lblGradeMethodStaticShoo;
        private System.Windows.Forms.TextBox tbxCeasuraShoo;
        private System.Windows.Forms.Label lblCeasuraStaticShoo;
        private System.Windows.Forms.Label lblCalculateGradeStatic1Shoo;
        private System.Windows.Forms.Label lblGradeStaticShoo;
        private System.Windows.Forms.Label lblPointsStaticShoo;
        private System.Windows.Forms.Label lblGradeAtPointsStaticShoo;
        private System.Windows.Forms.Label lblCalculateGradeStatic2Shoo;
        private System.Windows.Forms.TextBox tbxPointAmountShoo;
        private System.Windows.Forms.Label lblPointsShoo;
        private System.Windows.Forms.Button btnGeneratePdfShoo;
        private System.Windows.Forms.Label lblGradeShoo;
    }
}

