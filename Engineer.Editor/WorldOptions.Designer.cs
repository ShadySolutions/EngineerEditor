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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldOptions));
            this.Cube = new System.Windows.Forms.Button();
            this.GlobalItemsIcons = new System.Windows.Forms.ImageList(this.components);
            this.Soldier = new System.Windows.Forms.Button();
            this.Light = new System.Windows.Forms.Button();
            this.Camera = new System.Windows.Forms.Button();
            this.Sprite = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Events = new System.Windows.Forms.Button();
            this.Lights = new System.Windows.Forms.Button();
            this.Cameras = new System.Windows.Forms.Button();
            this.Characters = new System.Windows.Forms.Button();
            this.Primitives = new System.Windows.Forms.Button();
            this.All = new System.Windows.Forms.Button();
            this.Floor = new System.Windows.Forms.Button();
            this.Event = new System.Windows.Forms.Button();
            this.ContentPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.Event);
            this.ContentPanel.Controls.Add(this.Sprite);
            this.ContentPanel.Controls.Add(this.Camera);
            this.ContentPanel.Controls.Add(this.Light);
            this.ContentPanel.Controls.Add(this.Soldier);
            this.ContentPanel.Controls.Add(this.Cube);
            this.ContentPanel.Controls.Add(this.Floor);
            this.ContentPanel.Controls.Add(this.panel1);
            // 
            // Cube
            // 
            this.Cube.Dock = System.Windows.Forms.DockStyle.Top;
            this.Cube.FlatAppearance.BorderSize = 0;
            this.Cube.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cube.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cube.ForeColor = System.Drawing.Color.White;
            this.Cube.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cube.ImageIndex = 0;
            this.Cube.ImageList = this.GlobalItemsIcons;
            this.Cube.Location = new System.Drawing.Point(131, 50);
            this.Cube.Name = "Cube";
            this.Cube.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Cube.Size = new System.Drawing.Size(359, 50);
            this.Cube.TabIndex = 1;
            this.Cube.Tag = "1";
            this.Cube.Text = "Cube";
            this.Cube.UseVisualStyleBackColor = true;
            this.Cube.Click += new System.EventHandler(this.Floor_Click);
            this.Cube.MouseEnter += new System.EventHandler(this.Floor_MouseEnter);
            this.Cube.MouseLeave += new System.EventHandler(this.Floor_MouseLeave);
            // 
            // GlobalItemsIcons
            // 
            this.GlobalItemsIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("GlobalItemsIcons.ImageStream")));
            this.GlobalItemsIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.GlobalItemsIcons.Images.SetKeyName(0, "Primitive.png");
            this.GlobalItemsIcons.Images.SetKeyName(1, "Object.png");
            this.GlobalItemsIcons.Images.SetKeyName(2, "Actor.png");
            this.GlobalItemsIcons.Images.SetKeyName(3, "Camera.png");
            this.GlobalItemsIcons.Images.SetKeyName(4, "Event.png");
            this.GlobalItemsIcons.Images.SetKeyName(5, "Sound.png");
            this.GlobalItemsIcons.Images.SetKeyName(6, "Light.png");
            this.GlobalItemsIcons.Images.SetKeyName(7, "Sprite.png");
            // 
            // Soldier
            // 
            this.Soldier.Dock = System.Windows.Forms.DockStyle.Top;
            this.Soldier.FlatAppearance.BorderSize = 0;
            this.Soldier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Soldier.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Soldier.ForeColor = System.Drawing.Color.White;
            this.Soldier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Soldier.ImageIndex = 1;
            this.Soldier.ImageList = this.GlobalItemsIcons;
            this.Soldier.Location = new System.Drawing.Point(131, 100);
            this.Soldier.Name = "Soldier";
            this.Soldier.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Soldier.Size = new System.Drawing.Size(359, 50);
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
            this.Light.ImageIndex = 6;
            this.Light.ImageList = this.GlobalItemsIcons;
            this.Light.Location = new System.Drawing.Point(131, 150);
            this.Light.Name = "Light";
            this.Light.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Light.Size = new System.Drawing.Size(359, 50);
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
            this.Camera.ImageIndex = 3;
            this.Camera.ImageList = this.GlobalItemsIcons;
            this.Camera.Location = new System.Drawing.Point(131, 200);
            this.Camera.Name = "Camera";
            this.Camera.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Camera.Size = new System.Drawing.Size(359, 50);
            this.Camera.TabIndex = 4;
            this.Camera.Tag = "4";
            this.Camera.Text = "Camera";
            this.Camera.UseVisualStyleBackColor = true;
            this.Camera.Click += new System.EventHandler(this.Floor_Click);
            this.Camera.MouseEnter += new System.EventHandler(this.Floor_MouseEnter);
            this.Camera.MouseLeave += new System.EventHandler(this.Floor_MouseLeave);
            // 
            // Sprite
            // 
            this.Sprite.Dock = System.Windows.Forms.DockStyle.Top;
            this.Sprite.FlatAppearance.BorderSize = 0;
            this.Sprite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sprite.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sprite.ForeColor = System.Drawing.Color.White;
            this.Sprite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Sprite.ImageIndex = 7;
            this.Sprite.ImageList = this.GlobalItemsIcons;
            this.Sprite.Location = new System.Drawing.Point(131, 250);
            this.Sprite.Name = "Sprite";
            this.Sprite.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Sprite.Size = new System.Drawing.Size(359, 50);
            this.Sprite.TabIndex = 5;
            this.Sprite.Tag = "5";
            this.Sprite.Text = "Sprite";
            this.Sprite.UseVisualStyleBackColor = true;
            this.Sprite.Click += new System.EventHandler(this.Floor_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.Events);
            this.panel1.Controls.Add(this.Lights);
            this.panel1.Controls.Add(this.Cameras);
            this.panel1.Controls.Add(this.Characters);
            this.panel1.Controls.Add(this.Primitives);
            this.panel1.Controls.Add(this.All);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 370);
            this.panel1.TabIndex = 6;
            // 
            // Events
            // 
            this.Events.Dock = System.Windows.Forms.DockStyle.Top;
            this.Events.FlatAppearance.BorderSize = 0;
            this.Events.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Events.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Events.ForeColor = System.Drawing.Color.White;
            this.Events.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Events.Location = new System.Drawing.Point(0, 150);
            this.Events.Name = "Events";
            this.Events.Size = new System.Drawing.Size(131, 30);
            this.Events.TabIndex = 5;
            this.Events.Tag = "5";
            this.Events.Text = "Scripts";
            this.Events.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Events.UseVisualStyleBackColor = true;
            this.Events.Click += new System.EventHandler(this.All_Click);
            // 
            // Lights
            // 
            this.Lights.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lights.FlatAppearance.BorderSize = 0;
            this.Lights.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lights.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lights.ForeColor = System.Drawing.Color.White;
            this.Lights.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lights.Location = new System.Drawing.Point(0, 120);
            this.Lights.Name = "Lights";
            this.Lights.Size = new System.Drawing.Size(131, 30);
            this.Lights.TabIndex = 4;
            this.Lights.Tag = "4";
            this.Lights.Text = "Lights";
            this.Lights.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Lights.UseVisualStyleBackColor = true;
            this.Lights.Click += new System.EventHandler(this.All_Click);
            // 
            // Cameras
            // 
            this.Cameras.Dock = System.Windows.Forms.DockStyle.Top;
            this.Cameras.FlatAppearance.BorderSize = 0;
            this.Cameras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cameras.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cameras.ForeColor = System.Drawing.Color.White;
            this.Cameras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cameras.Location = new System.Drawing.Point(0, 90);
            this.Cameras.Name = "Cameras";
            this.Cameras.Size = new System.Drawing.Size(131, 30);
            this.Cameras.TabIndex = 3;
            this.Cameras.Tag = "3";
            this.Cameras.Text = "Cameras";
            this.Cameras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cameras.UseVisualStyleBackColor = true;
            this.Cameras.Click += new System.EventHandler(this.All_Click);
            // 
            // Characters
            // 
            this.Characters.Dock = System.Windows.Forms.DockStyle.Top;
            this.Characters.FlatAppearance.BorderSize = 0;
            this.Characters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Characters.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Characters.ForeColor = System.Drawing.Color.White;
            this.Characters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Characters.Location = new System.Drawing.Point(0, 60);
            this.Characters.Name = "Characters";
            this.Characters.Size = new System.Drawing.Size(131, 30);
            this.Characters.TabIndex = 2;
            this.Characters.Tag = "2";
            this.Characters.Text = "Characters";
            this.Characters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Characters.UseVisualStyleBackColor = true;
            this.Characters.Click += new System.EventHandler(this.All_Click);
            // 
            // Primitives
            // 
            this.Primitives.Dock = System.Windows.Forms.DockStyle.Top;
            this.Primitives.FlatAppearance.BorderSize = 0;
            this.Primitives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Primitives.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Primitives.ForeColor = System.Drawing.Color.White;
            this.Primitives.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Primitives.Location = new System.Drawing.Point(0, 30);
            this.Primitives.Name = "Primitives";
            this.Primitives.Size = new System.Drawing.Size(131, 30);
            this.Primitives.TabIndex = 1;
            this.Primitives.Tag = "1";
            this.Primitives.Text = "Primitives";
            this.Primitives.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Primitives.UseVisualStyleBackColor = true;
            this.Primitives.Click += new System.EventHandler(this.All_Click);
            // 
            // All
            // 
            this.All.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.All.Dock = System.Windows.Forms.DockStyle.Top;
            this.All.FlatAppearance.BorderSize = 0;
            this.All.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.All.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.All.ForeColor = System.Drawing.Color.White;
            this.All.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.All.Location = new System.Drawing.Point(0, 0);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(131, 30);
            this.All.TabIndex = 6;
            this.All.Tag = "0";
            this.All.Text = "All";
            this.All.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.All.UseVisualStyleBackColor = false;
            this.All.Click += new System.EventHandler(this.All_Click);
            // 
            // Floor
            // 
            this.Floor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Floor.Dock = System.Windows.Forms.DockStyle.Top;
            this.Floor.FlatAppearance.BorderSize = 0;
            this.Floor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Floor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Floor.ForeColor = System.Drawing.Color.White;
            this.Floor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Floor.ImageIndex = 0;
            this.Floor.ImageList = this.GlobalItemsIcons;
            this.Floor.Location = new System.Drawing.Point(131, 0);
            this.Floor.Name = "Floor";
            this.Floor.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Floor.Size = new System.Drawing.Size(359, 50);
            this.Floor.TabIndex = 0;
            this.Floor.Tag = "0";
            this.Floor.Text = "Floor";
            this.Floor.UseVisualStyleBackColor = true;
            this.Floor.Click += new System.EventHandler(this.Floor_Click);
            this.Floor.MouseEnter += new System.EventHandler(this.Floor_MouseEnter);
            this.Floor.MouseLeave += new System.EventHandler(this.Floor_MouseLeave);
            // 
            // Event
            // 
            this.Event.Dock = System.Windows.Forms.DockStyle.Top;
            this.Event.FlatAppearance.BorderSize = 0;
            this.Event.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Event.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Event.ForeColor = System.Drawing.Color.White;
            this.Event.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Event.ImageIndex = 4;
            this.Event.ImageList = this.GlobalItemsIcons;
            this.Event.Location = new System.Drawing.Point(131, 300);
            this.Event.Name = "Event";
            this.Event.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Event.Size = new System.Drawing.Size(359, 50);
            this.Event.TabIndex = 7;
            this.Event.Tag = "6";
            this.Event.Text = "Event";
            this.Event.UseVisualStyleBackColor = true;
            this.Event.Click += new System.EventHandler(this.Floor_Click);
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Floor;
        private System.Windows.Forms.Button Camera;
        private System.Windows.Forms.Button Light;
        private System.Windows.Forms.Button Soldier;
        private System.Windows.Forms.Button Cube;
        private System.Windows.Forms.Button Sprite;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Events;
        private System.Windows.Forms.Button Lights;
        private System.Windows.Forms.Button Cameras;
        private System.Windows.Forms.Button Characters;
        private System.Windows.Forms.Button Primitives;
        private System.Windows.Forms.ImageList GlobalItemsIcons;
        private System.Windows.Forms.Button All;
        private System.Windows.Forms.Button Event;
    }
}