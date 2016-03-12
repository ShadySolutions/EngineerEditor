﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShadySolutions.UI.NodeEditor
{
    public partial class NodeEditor : UserControl
    {
        private bool _ConnectionInProgress;
        private int _SeekType;
        private Point _LastMouseLocation;
        private NodeValue _ConnectionSeeker;
        private Bitmap _BackBuffer;
        private List<Node> _Nodes;
        public event NodeUpdateEventHandler NodeUpdate;
        public List<Node> Nodes
        {
            get
            {
                return _Nodes;
            }
        }
        public NodeEditor()
        {
            InitializeComponent();
            this._Nodes = new List<Node>();
            this.NodeUpdate = new NodeUpdateEventHandler(OnUpdate);
        }
        public void OnUpdate(NodeValue Sender)
        {

        }
        public void OnChildrenUpdate(NodeValue Sender)
        {
            this.NodeUpdate.Invoke(Sender);
        }
        public void AddNode(Node NewNode)
        {
            for(int i = 0; i < NewNode.Inputs.Count; i++)
            {
                NewNode.Inputs[i].SetInputClickEvent(Connect_Input_Click);
                NewNode.Inputs[i].NodeUpdate += new NodeUpdateEventHandler(OnChildrenUpdate);
            }
            for (int i = 0; i < NewNode.Outputs.Count; i++)
            {
                NewNode.Outputs[i].SetOutputClickEvent(Connect_Output_Click);
                NewNode.Outputs[i].NodeUpdate += new NodeUpdateEventHandler(OnChildrenUpdate);
            }
            for (int i = 0; i < NewNode.Values.Count; i++)
            {
                NewNode.Values[i].NodeUpdate += new NodeUpdateEventHandler(OnChildrenUpdate);
            }
            NewNode.EditorHolder = this;
            this.Nodes.Add(NewNode);
            this.Controls.Add(NewNode);
        }
        private List<Point> GenerateCurve(Point P0, Point P1)
        {
            List<Point> Points = new List<Point>();
            Point M = new Point(), R = new Point(), M0 = new Point(), M1 = new Point(), M0S = new Point(), M1S = new Point();
            M.X = (P0.X + P1.X) / 2;
            M.Y = (P0.Y + P0.Y) / 2;
            R.X = Math.Abs(P1.X - P0.X);
            R.Y = Math.Abs(P1.Y - P0.Y);
            if (P0.X < P1.X)
            {
                M0.X = P0.X + R.X / 3;
                M1.X = P1.X - R.X / 3;
                M0S.X = P0.X + R.X / 10;
                M1S.X = P1.X - R.X / 10;
            }
            else
            {
                M0.X = P0.X - R.X / 3;
                M1.X = P1.X + R.X / 3;
                M0S.X = P0.X - R.X / 10;
                M1S.X = P1.X + R.X / 10;
            }
            if (P0.Y < P1.Y)
            {
                M0.Y = P0.Y + R.Y / 7;
                M1.Y = P1.Y - R.Y / 7;
            }
            else
            {
                M0.Y = P0.Y - R.Y / 7;
                M1.Y = P1.Y + R.Y / 7;
            }
            M0S.Y = P0.Y;
            M1S.Y = P1.Y;
            for (float i = 0.2f; i <= 1; i += 0.2f)
            {
                Points.Add(PointOnCurve(P0, M0S, M0, M1, i));
            }
            for (float i = 0.2f; i <= 1; i += 0.2f)
            {
                Points.Add(PointOnCurve(M0S, M0, M1, M1S, i));
            }
            for (float i = 0.2f; i <= 1; i += 0.2f)
            {
                Points.Add(PointOnCurve(M0, M1, M1S, P1, i));
            }
            return Points;
        }
        private Point PointOnCurve(Point p0, Point p1, Point p2, Point p3, float Factor)
        {
            Point Result = new Point();
            float Factor2 = Factor * Factor;
            float Factor3 = Factor2 * Factor;
            Result.X = (int)(0.5f * ((2.0f * p1.X) + (-p0.X + p2.X) * Factor + (2.0f * p0.X - 5.0f * p1.X + 4 * p2.X - p3.X) * Factor2 + (-p0.X + 3.0f * p1.X - 3.0f * p2.X + p3.X) * Factor3));
            Result.Y = (int)(0.5f * ((2.0f * p1.Y) + (-p0.Y + p2.Y) * Factor + (2.0f * p0.Y - 5.0f * p1.Y + 4 * p2.Y - p3.Y) * Factor2 + (-p0.Y + 3.0f * p1.Y - 3.0f * p2.Y + p3.Y) * Factor3));
            return Result;
        }
        private void DrawConnection(Graphics Draw, Point P0, Point P1)
        {
            List<Point> Points = GenerateCurve(P0, P1);
            Pen OrangePen = new Pen(Color.Silver, 2);
            Pen BlackPen = new Pen(Color.Gray, 4);
            Points.Insert(0, P0);
            Points.Add(P1);
            for (int i = 0; i < Points.Count - 1; i++)
            {
                Draw.DrawLine(BlackPen, Points[i], Points[i + 1]);
            }
            for (int i = 0; i < Points.Count - 1; i++)
            {
                Draw.DrawLine(OrangePen, Points[i], Points[i + 1]);
            }
        }
        private void DrawConnections()
        {
            Graphics Draw = this.CreateGraphics();
            Bitmap Buffer = new Bitmap(this.Width, this.Height);
            Graphics DrawBuffer = Graphics.FromImage(Buffer);
            DrawBuffer.Clear(Color.FromArgb(255, 40, 40, 40));
            DrawBuffer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if(true)
            {
                for (int i = 0; i < this.Nodes.Count; i++)
                {
                    for (int j = 0; j < this.Nodes[i].Outputs.Count; j++)
                    {
                        for (int k = 0; k < this.Nodes[i].Outputs[j].Outputs.Count; k++)
                        {
                            Point P0 = this.Nodes[i].Outputs[j].Holder.Location;
                            Point P1 = this.Nodes[i].Outputs[j].Outputs[k].Holder.Location;
                            P0.Y += this.Nodes[i].Outputs[j].NodeValueIndex * 20 + 31;
                            P0.X += this.Nodes[i].Outputs[j].Holder.Width;
                            P1.Y += this.Nodes[i].Outputs[j].Outputs[k].NodeValueIndex * 20 + 31;
                            DrawConnection(DrawBuffer, P0, P1);
                        }
                    }
                }
            }
            if(this._ConnectionInProgress)
            {
                Point P0 = this._ConnectionSeeker.Holder.Location;
                P0.Y += this._ConnectionSeeker.NodeValueIndex * 20 + 31;
                if (this._SeekType == 0)
                {
                    DrawConnection(DrawBuffer, this._LastMouseLocation, P0);
                }
                else
                {
                    P0.X += this._ConnectionSeeker.Holder.Width;
                    DrawConnection(DrawBuffer, P0, this._LastMouseLocation);
                }
            }
            Draw.DrawImage(Buffer, 0, 0);
            DrawBuffer.Dispose();
            Buffer.Dispose();
            Draw.Dispose();
        }
        private void NodeEditor_Paint(object sender, PaintEventArgs e)
        {
            DrawConnections();
        }
        private void Connect_Input_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            if (me.Button == MouseButtons.Right)
            {
                this._ConnectionSeeker = null;
                this._ConnectionInProgress = false;
                this.PaintTimer.Enabled = false;
                return;
            }
            Control SenderAsControl = sender as Control;
            NodeValue Input = SenderAsControl.Tag as NodeValue;
            if (this._ConnectionInProgress && this._SeekType == 1)
            {
                if (Input.Holder == this._ConnectionSeeker.Holder)
                {
                    this._ConnectionSeeker = null;
                    this._ConnectionInProgress = false;
                    this.PaintTimer.Enabled = false;
                    return;
                }
                if (Input.Input!=null)
                {
                    Input.Input.Outputs.Remove(Input);
                    Input.Input.Holder.Invalidate();
                }
                this._ConnectionSeeker.Outputs.Add(Input);
                Input.Input = this._ConnectionSeeker;
                this._ConnectionSeeker.InvalidateConnectors();
                this._ConnectionSeeker = null;
                this._ConnectionInProgress = false;
                this.PaintTimer.Enabled = false;
                SenderAsControl.Invalidate();
                this.Invalidate();
            }
            else if(!this._ConnectionInProgress)
            {
                this._ConnectionInProgress = true;
                this.PaintTimer.Enabled = true;
                this._ConnectionSeeker = Input;
                this._SeekType = 0;
            }
            else
            {
                
            }
        }
        private void Connect_Output_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            if (me.Button == MouseButtons.Right)
            {
                this._ConnectionSeeker = null;
                this._ConnectionInProgress = false;
                this.PaintTimer.Enabled = false;
                return;
            }
            Control SenderAsControl = sender as Control;
            NodeValue Output = SenderAsControl.Tag as NodeValue;
            if (this._ConnectionInProgress && this._SeekType == 0)
            {
                if (Output.Holder == this._ConnectionSeeker.Holder)
                {
                    this._ConnectionSeeker = null;
                    this._ConnectionInProgress = false;
                    this.PaintTimer.Enabled = false;
                    return;
                }
                if (this._ConnectionSeeker.Input != null)
                {
                    this._ConnectionSeeker.Input.Outputs.Remove(this._ConnectionSeeker);
                    this._ConnectionSeeker.Input.Holder.Invalidate();
                }
                this._ConnectionSeeker.Input = Output;
                Output.Outputs.Add(this._ConnectionSeeker);
                this._ConnectionSeeker.InvalidateConnectors();
                this._ConnectionSeeker = null;
                this._ConnectionInProgress = false;
                this.PaintTimer.Enabled = false;
                SenderAsControl.Invalidate();
                this.Invalidate();
            }
            else if (!this._ConnectionInProgress)
            {
                this._ConnectionInProgress = true;
                this.PaintTimer.Enabled = true;
                this._ConnectionSeeker = Output;
                this._SeekType = 1;
            }
            else
            {
                
            }
        }
        private void NodeEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_ConnectionInProgress) return;
            this._LastMouseLocation = e.Location;
        }
        private void PaintTimer_Tick(object sender, EventArgs e)
        {
            if (!this._ConnectionInProgress) return;
            this.Invalidate();
        }
        private void NodeEditor_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                this._ConnectionSeeker = null;
                this._ConnectionInProgress = false;
                this.PaintTimer.Enabled = false;
                this.Invalidate();
            }
        }
    }
}
