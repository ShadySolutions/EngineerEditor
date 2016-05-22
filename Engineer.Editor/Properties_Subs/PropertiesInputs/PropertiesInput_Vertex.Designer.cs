namespace Engineer.Editor
{
    partial class PropertiesInput_Vertex
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ValueVertex = new Engineer.Editor.VertexControl();
            this.SuspendLayout();
            // 
            // ValueVertex
            // 
            this.ValueVertex.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ValueVertex.Location = new System.Drawing.Point(100, 14);
            this.ValueVertex.Name = "ValueVertex";
            this.ValueVertex.Size = new System.Drawing.Size(200, 16);
            this.ValueVertex.TabIndex = 9;
            // 
            // PropertiesInput_Vertex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValueVertex);
            this.Name = "PropertiesInput_Vertex";
            this.Controls.SetChildIndex(this.ValueVertex, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private VertexControl ValueVertex;
    }
}
