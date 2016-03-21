//#define FixedPipeline
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Engineer.Mathematics;
using Engineer.Data;
using Engineer.Draw;
using Engineer.Draw.OpenGL;
using Engineer.Draw.OpenGL.FixedGL;
using Engineer.Draw.OpenGL.GLSL;
using Engineer.Engine;
using CSScriptLibrary;
using OpenTK.Input;

namespace Engineer.Runner
{
    public class Runner : OpenTK.GameWindow
    {
        private bool _SceneInit;
        private bool _EngineInit;
        private object _PreviousTarget;
        private Scene _Scene;
        private DrawEngine _Engine;
        public Runner(int width, int height, GraphicsMode mode, string title) : base(width, height, mode, title)
        {
            this._SceneInit = false;
            this._EngineInit = false;
        }
        public void Init(Scene CurrentScene, DrawEngine CurrentEngine)
        {
            this._SceneInit = true;
            this._EngineInit = true;
            this._Scene = CurrentScene;
            this._Engine = CurrentEngine;
            this._PreviousTarget = this._Engine.CurrentRenderer.RenderDestination;
            this._Engine.CurrentRenderer.RenderDestination = this;
            this._Engine.CurrentRenderer.TargetType = RenderTargetType.Runner;
            this.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(Event_Closing);
            this.KeyDown += new EventHandler<KeyboardKeyEventArgs>(Event_KeyPress);
            this.KeyDown += new EventHandler<KeyboardKeyEventArgs>(Event_KeyDown);
            this.KeyUp += new EventHandler<KeyboardKeyEventArgs>(Event_KeyUp);
            this.MouseDown += new EventHandler<MouseButtonEventArgs>(Event_MouseClick);
            this.MouseDown += new EventHandler<MouseButtonEventArgs>(Event_MouseDown);
            this.MouseUp += new EventHandler<MouseButtonEventArgs>(Event_MouseUp);
            this.MouseMove += new EventHandler<MouseMoveEventArgs>(Event_MouseMove);
            this.MouseWheel += new EventHandler<MouseWheelEventArgs>(Event_MouseWheel);
            Event_Load();
        }
        protected override void OnResize(EventArgs e)
        {
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            if (!_SceneInit || !_EngineInit) return;
            if (_Scene.Type == SceneType.Scene2D)
            {
                _Engine.Draw2DScene((Scene2D)_Scene, this.ClientRectangle.Width, this.ClientRectangle.Height);
            }
            else if (_Scene.Type == SceneType.Scene3D)
            {
                _Engine.Draw3DScene((Scene3D)_Scene, this.ClientRectangle.Width, this.ClientRectangle.Height);
            }
            Event_RenderFrame(this, e);
            SwapBuffers();
        }
        private void Event_Closing(object sender, EventArgs e)
        {
            this._Engine.CurrentRenderer.TargetType = RenderTargetType.Editor;
            this._Engine.CurrentRenderer.RenderDestination = this._PreviousTarget;
            for (int i = 0; i < _Scene.Events.Closing.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.Closing[i].Script);
                    Script.Closing(_Scene);
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.Closing[i].Name + " FAILED!");
                }
            }
        }
        private void Event_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.KeyDown.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.KeyDown[i].Script);
                    Script.KeyDown(_Scene, e.Key, e.Control, e.Alt, e.Shift);
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.KeyDown[i].Name + " FAILED!");
                }
            }
        }
        private void Event_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.KeyUp.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.KeyUp[i].Script);
                    Script.KeyUp(_Scene, e.Key, e.Control, e.Alt, e.Shift);
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.KeyUp[i].Name + " FAILED!");
                }
            }
        }
        private void Event_KeyPress(object sender, KeyboardKeyEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.KeyPress.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.KeyPress[i].Script);
                    Script.KeyPress(_Scene, e.Key, e.Control, e.Alt, e.Shift);
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.KeyPress[i].Name + " FAILED!");
                }
            }
        }
        private void Event_Load()
        {
            for (int i = 0; i < _Scene.Events.Load.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.Load[i].Script);
                    Script.Load(_Scene);
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.Load[i].Name + " FAILED!");
                }
            }
        }
        private void Event_MouseDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.MouseDown.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.MouseDown[i].Script);
                    Script.MouseDown(_Scene, (MouseClickButtonType)e.Button, new Vertex(e.X, e.Y, 0));
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.MouseDown[i].Name + " FAILED!");
                }
            }
        }
        private void Event_MouseUp(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.MouseUp.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.MouseUp[i].Script);
                    Script.MouseUp(_Scene, (MouseClickButtonType)e.Button, new Vertex(e.X, e.Y, 0));
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.MouseUp[i].Name + " FAILED!");
                }
            }
        }
        private void Event_MouseClick(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.MousePress.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.MousePress[i].Script);
                    Script.MousePress(_Scene, (MouseClickButtonType)e.Button, new Vertex(e.X, e.Y, 0));
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.MousePress[i].Name + " FAILED!");
                }
            }
        }
        private void Event_MouseMove(object sender, MouseMoveEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.MouseMove.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.MouseMove[i].Script);
                    Script.MouseMove(_Scene, new Vertex(e.X, e.Y, 0));
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.MouseMove[i].Name + " FAILED!");
                }
            }
        }
        private void Event_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.MouseWheel.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.MouseWheel[i].Script);
                    Script.OnMouseWheel(_Scene, new Vertex(e.X, e.Y, 0), e.Delta);
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.MouseWheel[i].Name + " FAILED!");
                }
            }
        }
        private void Event_RenderFrame(object sender, EventArgs e)
        {
            for (int i = 0; i < _Scene.Events.RenderFrame.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.RenderFrame[i].Script);
                    Script.RenderFrame(_Scene);
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.RenderFrame[i].Name + " FAILED!");
                }
            }
        }
        private void Event_EverySecond(object sender, EventArgs e)
        {
            for (int i = 0; i < _Scene.Events.EverySecond.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.EverySecond[i].Script);
                    Script.OnEverySecond(_Scene);
                }
                catch
                {
                    Console.WriteLine(_Scene.Events.EverySecond[i].Name + " FAILED!");
                }
            }
        }
    }
}
