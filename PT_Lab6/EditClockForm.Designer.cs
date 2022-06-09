namespace PT_Lab6
{
    partial class EditClockForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.formBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.arrowColorBox = new System.Windows.Forms.Button();
            this.secondaryColorBox = new System.Windows.Forms.Button();
            this.primaryColorBox = new System.Windows.Forms.Button();
            this.heightBox = new System.Windows.Forms.NumericUpDown();
            this.widthBox = new System.Windows.Forms.NumericUpDown();
            this.clockFaceComboBox = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.arrowFormComboBox = new System.Windows.Forms.ComboBox();
            this.fontButton = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.OkButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.toDefaultButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JSON|*.json";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "JSON|*.json";
            // 
            // formBox
            // 
            this.formBox.FormattingEnabled = true;
            this.formBox.Location = new System.Drawing.Point(6, 22);
            this.formBox.Name = "formBox";
            this.formBox.Size = new System.Drawing.Size(121, 23);
            this.formBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toDefaultButton);
            this.groupBox1.Controls.Add(this.arrowColorBox);
            this.groupBox1.Controls.Add(this.secondaryColorBox);
            this.groupBox1.Controls.Add(this.primaryColorBox);
            this.groupBox1.Controls.Add(this.heightBox);
            this.groupBox1.Controls.Add(this.widthBox);
            this.groupBox1.Controls.Add(this.formBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 298);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic";
            // 
            // arrowColorBox
            // 
            this.arrowColorBox.Location = new System.Drawing.Point(6, 173);
            this.arrowColorBox.Name = "arrowColorBox";
            this.arrowColorBox.Size = new System.Drawing.Size(159, 23);
            this.arrowColorBox.TabIndex = 7;
            this.arrowColorBox.Text = "Arrows color";
            this.arrowColorBox.UseVisualStyleBackColor = true;
            this.arrowColorBox.Click += new System.EventHandler(this.colorBox_Click);
            // 
            // secondaryColorBox
            // 
            this.secondaryColorBox.Location = new System.Drawing.Point(7, 144);
            this.secondaryColorBox.Name = "secondaryColorBox";
            this.secondaryColorBox.Size = new System.Drawing.Size(158, 23);
            this.secondaryColorBox.TabIndex = 6;
            this.secondaryColorBox.Text = "Secondary color";
            this.secondaryColorBox.UseVisualStyleBackColor = true;
            this.secondaryColorBox.Click += new System.EventHandler(this.colorBox_Click);
            // 
            // primaryColorBox
            // 
            this.primaryColorBox.Location = new System.Drawing.Point(7, 115);
            this.primaryColorBox.Name = "primaryColorBox";
            this.primaryColorBox.Size = new System.Drawing.Size(158, 23);
            this.primaryColorBox.TabIndex = 5;
            this.primaryColorBox.Text = "Primary color";
            this.primaryColorBox.UseVisualStyleBackColor = true;
            this.primaryColorBox.Click += new System.EventHandler(this.colorBox_Click);
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(7, 86);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(120, 23);
            this.heightBox.TabIndex = 2;
            this.heightBox.ValueChanged += new System.EventHandler(this.sizeBox_ValueChanged);
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(6, 51);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(120, 23);
            this.widthBox.TabIndex = 1;
            this.widthBox.ValueChanged += new System.EventHandler(this.sizeBox_ValueChanged);
            // 
            // clockFaceComboBox
            // 
            this.clockFaceComboBox.FormattingEnabled = true;
            this.clockFaceComboBox.Location = new System.Drawing.Point(22, 22);
            this.clockFaceComboBox.Name = "clockFaceComboBox";
            this.clockFaceComboBox.Size = new System.Drawing.Size(121, 23);
            this.clockFaceComboBox.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.arrowFormComboBox);
            this.groupBox2.Controls.Add(this.fontButton);
            this.groupBox2.Controls.Add(this.clockFaceComboBox);
            this.groupBox2.Location = new System.Drawing.Point(264, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 298);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional";
            // 
            // arrowFormComboBox
            // 
            this.arrowFormComboBox.FormattingEnabled = true;
            this.arrowFormComboBox.Location = new System.Drawing.Point(22, 51);
            this.arrowFormComboBox.Name = "arrowFormComboBox";
            this.arrowFormComboBox.Size = new System.Drawing.Size(121, 23);
            this.arrowFormComboBox.TabIndex = 8;
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(22, 80);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(187, 65);
            this.fontButton.TabIndex = 9;
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.FontButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(711, 349);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 11;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(803, 349);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(19, 337);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(159, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save parameters";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(184, 337);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(159, 23);
            this.importButton.TabIndex = 13;
            this.importButton.Text = "Import parameters";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // toDefaultButton
            // 
            this.toDefaultButton.Location = new System.Drawing.Point(6, 269);
            this.toDefaultButton.Name = "toDefaultButton";
            this.toDefaultButton.Size = new System.Drawing.Size(159, 23);
            this.toDefaultButton.TabIndex = 14;
            this.toDefaultButton.Text = "To default parameters";
            this.toDefaultButton.UseVisualStyleBackColor = true;
            this.toDefaultButton.Click += new System.EventHandler(this.toDefaultButton_Click);
            // 
            // EditClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 384);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditClockForm";
            this.Text = "EditClockForm";
            this.Load += new System.EventHandler(this.EditClockForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox formBox;
        private GroupBox groupBox1;
        private NumericUpDown heightBox;
        private NumericUpDown widthBox;
        private ComboBox clockFaceComboBox;
        private ColorDialog colorDialog1;
        private Button primaryColorBox;
        private Button arrowColorBox;
        private Button secondaryColorBox;
        private GroupBox groupBox2;
        private Button fontButton;
        private FontDialog fontDialog1;
        private ComboBox arrowFormComboBox;
        private Button OkButton;
        private Button cancelButton;
        private Button saveButton;
        private Button importButton;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private Button toDefaultButton;
    }
}