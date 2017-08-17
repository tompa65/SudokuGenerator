namespace Sudoku.Win
{
    partial class SudokuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SudokuForm));
            this.btnNewBoard = new System.Windows.Forms.Button();
            this.btnShowSolution = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewBoard
            // 
            this.btnNewBoard.Location = new System.Drawing.Point(182, 317);
            this.btnNewBoard.Name = "btnNewBoard";
            this.btnNewBoard.Size = new System.Drawing.Size(75, 23);
            this.btnNewBoard.TabIndex = 0;
            this.btnNewBoard.Text = "Nytt spel";
            this.btnNewBoard.UseVisualStyleBackColor = true;
            this.btnNewBoard.Click += new System.EventHandler(this.btnNewBoard_Click);
            // 
            // btnShowSolution
            // 
            this.btnShowSolution.Location = new System.Drawing.Point(84, 317);
            this.btnShowSolution.Name = "btnShowSolution";
            this.btnShowSolution.Size = new System.Drawing.Size(92, 23);
            this.btnShowSolution.TabIndex = 1;
            this.btnShowSolution.Text = "Visa lösningen";
            this.btnShowSolution.UseVisualStyleBackColor = true;
            this.btnShowSolution.Click += new System.EventHandler(this.btnShowSolution_Click);
            // 
            // SudokuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 366);
            this.Controls.Add(this.btnShowSolution);
            this.Controls.Add(this.btnNewBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SudokuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku board generator";
            this.Load += new System.EventHandler(this.SudokuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewBoard;
        private System.Windows.Forms.Button btnShowSolution;
    }
}