﻿//#define FixedPipeline
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
            this._Engine.CurrentRenderer.RenderDestination = this;
            this._Engine.CurrentRenderer.TargetType = RenderTargetType.Runner;
            this.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(Event_Closing);
            this.KeyDown += new EventHandler<KeyboardKeyEventArgs>(Event_KeyDown);
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
            SwapBuffers();
        }
        private void Event_Closing(object sender, EventArgs e)
        {
            for(int i = 0; i < _Scene.Events.Closing.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.Closing[i].Script);
                try
                {
                    Script.Closing(_Scene);
                }
                catch
                {

                }
            }
        }
        private void Event_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.KeyDown.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.KeyDown[i].Script);
                try
                {
                    Script.KeyDown(_Scene, e.Key, e.Control, e.Alt, e.Shift);
                }
                catch
                {

                }
            }
        }
        private void Event_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.KeyUp.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.KeyUp[i].Script);
                try
                {
                    Script.KeyUp(_Scene, e.Key, e.Control, e.Alt, e.Shift);
                }
                catch
                {

                }
            }
        }
        private void Event_KeyPress(object sender, KeyboardKeyEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.KeyPress.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.KeyPress[i].Script);
                try
                {
                    Script.KeyPress(_Scene, e.Key, e.Control, e.Alt, e.Shift);
                }
                catch
                {

                }
            }
        }
        private void Event_Load()
        {
            for (int i = 0; i < _Scene.Events.Load.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.Load[i].Script);
                try
                {
                    Script.Load();
                }
                catch
                {

                }
            }
        }
        private void Event_MouseDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.MouseDown.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.MouseDown[i].Script);
                try
                {
                    Script.MouseDown(_Scene, e.Button, e.Position);
                }
                catch
                {

                }
            }
        }
        private void Event_MouseUp(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.MouseUp.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.MouseUp[i].Script);
                try
                {
                    Script.MouseUp(_Scene, e.Button, e.Position);
                }
                catch
                {

                }
            }
        }
        private void Event_MouseClick(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.MousePress.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.MousePress[i].Script);
                try
                {
                    Script.MousePress(_Scene, e.Button, e.Position);
                }
                catch
                {

                }
            }
        }
        private void Event_MouseMove(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.MouseMove.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.MouseMove[i].Script);
                try
                {
                    Script.MouseMove(_Scene, e.Position);
                }
                catch
                {

                }
            }
        }
        private void Event_MouseWheel(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _Scene.Events.MouseWheel.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.MouseWheel[i].Script);
                try
                {
                    Script.OnMouseWheel(_Scene, e.Position);
                }
                catch
                {

                }
            }
        }
        private void Event_RenderFrame(object sender, EventArgs e)
        {
            for (int i = 0; i < _Scene.Events.RenderFrame.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.RenderFrame[i].Script);
                try
                {
                    Script.RenderFrame(_Scene);
                }
                catch
                {

                }
            }
        }
        private void Event_EverySecond(object sender, EventArgs e)
        {
            for (int i = 0; i < _Scene.Events.EverySecond.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(_Scene.Events.EverySecond[i].Script);
                try
                {
                    Script.OnEverySecond(_Scene);
                }
                catch
                {

                }
            }
        }
    }
}
