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
            else if (_Scene.Type == SceneType.Scene2D)
            {
                _Engine.Draw3DScene((Scene3D)_Scene, this.ClientRectangle.Width, this.ClientRectangle.Height);
            }
            SwapBuffers();
        }
    }
}
