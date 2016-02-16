namespace Engineer.Editor
{
    partial class WorldOptions
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
            this.Floor = new System.Windows.Forms.Button();
            this.Cube = new System.Windows.Forms.Button();
            this.Soldier = new System.Windows.Forms.Button();
            this.Light = new System.Windows.Forms.Button();
            this.Camera = new System.Windows.Forms.Button();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.Camera);
            this.ContentPanel.Controls.Add(this.Light);
            this.ContentPanel.Controls.Add(this.Soldier);
            this.ContentPanel.Controls.Add(this.Cube);
            this.ContentPanel.Controls.Add(this.Floor);
            // 
            // Floor
            // 
            this.Floor.Dock = System.Windows.Forms.DockStyle.Top;
            this.Floor.FlatAppearance.BorderSize = 0;
            this.Floor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Floor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Floor.ForeColor = System.Drawing.Color.White;
            this.Floor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Floor.Location = new System.Drawing.Point(0, 0);
            this.Floor.Name = "Floor";
            this.Floor.Size = new System.Drawing.Size(490, 30);
            this.Floor.TabIndex = 0;
            this.Floor.Tag = "0";
            this.Floor.Text = "Floor";
            this.Floor.UseVisualStyleBackColor = true;
            this.Floor.Click += new System.EventHandler(this.Floor_Click);
            this.Floor.MouseEnter += new System.EventHandler(this.Floor_MouseEnter);
            this.Floor.MouseLeave += new System.EventHandler(this.Floor_MouseLeave);
            // 
            // Cube
            // 
            this.Cube.Dock = System.Windows.Forms.DockStyle.Top;
            this.Cube.FlatAppearance.BorderSize = 0;
            this.Cube.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cube.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cube.ForeColor = System.Drawing.Color.White;
            this.Cube.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cube.Location = new System.Drawing.Point(0, 30);
            this.Cube.Name = "Cube";
            this.Cube.Size = new System.Drawing.Size(490, 30);
            this.Cube.TabIndex = 1;
            this.Cube.Tag = "1";
            this.Cube.Text = "Cube";
            this.Cube.UseVisualStyleBackColor = true;
            this.Cube.Click += new System.EventHandler(this.Floor_Click);
            this.Cube.MouseEnter += new System.EventHandler(this.Floor_MouseEnter);
            this.Cube.MouseLeave += new System.EventHandler(this.Floor_MouseLeave);
            // 
            // Soldier
            // 
            this.Soldier.Dock = System.Windows.Forms.DockStyle.Top;
            this.Soldier.FlatAppearance.BorderSize = 0;
            this.Soldier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Soldier.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Soldier.ForeColor = System.Drawing.Color.White;
            this.Soldier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Soldier.Location = new System.Drawing.Point(0, 60);
            this.Soldier.Name = "Soldier";
            this.Soldier.Size = new System.Drawing.Size(490, 30);
            this.Soldier.TabIndex = 2;
            this.Soldier.Tag = "2";
            this.Soldier.Text = "Soldier";
            this.Soldier.UseVisualStyleBackColor = true;
            this.Soldier.Click += new System.EventHandler(this.Floor_Click);
            this.Soldier.MouseEnter += new System.EventHandler(this.Floor_MouseEnter);
            this.Soldier.MouseLeave += new System.EventHandler(this.Floor_MouseLeave);
            // 
            // Light
            // 
            this.Light.Dock = System.Windows.Forms.DockStyle.Top;
            this.Light.FlatAppearance.BorderSize = 0;
            this.Light.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Light.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Light.ForeColor = System.Drawing.Color.White;
            this.Light.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Light.Location = new System.Drawing.Point(0, 90);
            this.Light.Name = "Light";
            this.Light.Size = new System.Drawing.Size(490, 30);
            this.Light.TabIndex = 3;
            this.Light.Tag = "3";
            this.Light.Text = "Light";
            this.Light.UseVisualStyleBackColor = true;
            this.Light.Click += new System.EventHandler(this.Floor_Click);
            this.Light.MouseEnter += new System.EventHandler(this.Floor_MouseEnter);
            this.Light.MouseLeave += new System.EventHandler(this.Floor_MouseLeave);
            // 
            // Camera
            // 
            this.Camera.Dock = System.Windows.Forms.DockStyle.Top;
            this.Camera.FlatAppearance.BorderSize = 0;
            this.Camera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Camera.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Camera.ForeColor = System.Drawing.Color.White;
            this.Camera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Camera.Location = new System.Drawing.Point(0, 120);
            this.Camera.Name = "Camera";
            this.Camera.Size = new System.Drawing.Size(490, 30);
            this.Camera.TabIndex = 4;
            this.Camera.Tag = "4";
            this.Camera.Text = "Camera";
            this.Camera.UseVisualStyleBackColor = true;
            this.Camera.Click += new System.EventHandler(this.Floor_Click);
            this.Camera.MouseEnter += new System.EventHandler(this.Floor_MouseEnter);
            this.Camera.MouseLeave += new System.EventHandler(this.Floor_MouseLeave);
            // 
            // WorldOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.CloseVisible = true;
            this.ControlsVisible = true;
            this.MaximiseVisible = true;
            this.Name = "WorldOptions";
            this.Text = "World";
            this.Title = "World Options";
            this.ContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Floor;
        private System.Windows.Forms.Button Camera;
        private System.Windows.Forms.Button Light;
        private System.Windows.Forms.Button Soldier;
        private System.Windows.Forms.Button Cube;
    }
}