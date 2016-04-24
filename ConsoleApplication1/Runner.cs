//#define FixedPipeline
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        private bool _GameInit;
        private bool _EngineInit;
        private Timer _Time;
        private Scene _CurrentScene;
        private Game _CurrentGame;
        private DrawEngine _Engine;
        public Runner(int width, int height, GraphicsMode mode, string title) : base(width, height, mode, title)
        {
            this._GameInit = false;
            this._EngineInit = false;
            this._Time = new Timer(100);
            this._Time.Elapsed += Event_EverySecond;
            this._Time.AutoReset = true;
        }
        private void EngineInit()
        {
            this._EngineInit = true;
            _Engine = new DrawEngine();
            GLSLShaderRenderer Render = new GLSLShaderRenderer();
            Render.RenderDestination = this;
            Render.TargetType = RenderTargetType.Runner;
            _Engine.CurrentRenderer = Render;
            GLSLShaderMaterialTranslator Translator = new GLSLShaderMaterialTranslator();
            _Engine.CurrentTranslator = Translator;
            _Engine.SetDefaults();
        }
        public void Init(Game CurrentGame, Scene CurrentScene)
        {
            if (!_EngineInit) EngineInit();
            this._GameInit = true;
            this._CurrentGame = CurrentGame;
            this._CurrentScene = CurrentScene;
            this.Closing += new EventHandler<System.ComponentModel.CancelEventArgs>(Event_Closing);
            this.KeyDown += new EventHandler<KeyboardKeyEventArgs>(Event_KeyPress);
            this.KeyDown += new EventHandler<KeyboardKeyEventArgs>(Event_KeyDown);
            this.KeyUp += new EventHandler<KeyboardKeyEventArgs>(Event_KeyUp);
            this.MouseDown += new EventHandler<MouseButtonEventArgs>(Event_MouseClick);
            this.MouseDown += new EventHandler<MouseButtonEventArgs>(Event_MouseDown);
            this.MouseUp += new EventHandler<MouseButtonEventArgs>(Event_MouseUp);
            this.MouseMove += new EventHandler<MouseMoveEventArgs>(Event_MouseMove);
            this.MouseWheel += new EventHandler<MouseWheelEventArgs>(Event_MouseWheel);
            this._Time.Enabled = true;
            Event_Load();
        }
        protected override void OnResize(EventArgs e)
        {
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            if (!_GameInit || !_EngineInit) return;
            this.MakeCurrent();
            if (_CurrentScene.Type == SceneType.Scene2D)
            {
                _Engine.Draw2DScene((Scene2D)_CurrentScene, this.ClientRectangle.Width, this.ClientRectangle.Height);
            }
            else if (_CurrentScene.Type == SceneType.Scene3D)
            {
                _Engine.Draw3DScene((Scene3D)_CurrentScene, this.ClientRectangle.Width, this.ClientRectangle.Height);
            }
            Event_RenderFrame(this, e);
            SwapBuffers();
        }
        private void Event_Closing(object sender, EventArgs e)
        {
            for (int i = 0; i < _CurrentScene.Events.Closing.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.Closing[i].Script);
                    Script.Closing(_CurrentScene);
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.Closing[i].Name + " FAILED!");
                }
            }
        }
        private void Event_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            for (int i = 0; i < _CurrentScene.Events.KeyDown.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.KeyDown[i].Script);
                    Script.KeyDown(_CurrentScene, e.Key, e.Control, e.Alt, e.Shift);
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.KeyDown[i].Name + " FAILED!");
                }
            }
        }
        private void Event_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            for (int i = 0; i < _CurrentScene.Events.KeyUp.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.KeyUp[i].Script);
                    Script.KeyUp(_CurrentScene, e.Key, e.Control, e.Alt, e.Shift);
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.KeyUp[i].Name + " FAILED!");
                }
            }
        }
        private void Event_KeyPress(object sender, KeyboardKeyEventArgs e)
        {
            for (int i = 0; i < _CurrentScene.Events.KeyPress.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.KeyPress[i].Script);
                    Script.KeyPress(_CurrentScene, e.Key, e.Control, e.Alt, e.Shift);
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.KeyPress[i].Name + " FAILED!");
                }
            }
        }
        private void Event_Load()
        {
            for (int i = 0; i < _CurrentScene.Events.Load.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.Load[i].Script);
                    Script.Load(_CurrentScene);
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.Load[i].Name + " FAILED!");
                }
            }
        }
        private void Event_MouseDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _CurrentScene.Events.MouseDown.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.MouseDown[i].Script);
                    Script.MouseDown(_CurrentScene, (MouseClickButtonType)e.Button, new Vertex(e.X, e.Y, 0));
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.MouseDown[i].Name + " FAILED!");
                }
            }
        }
        private void Event_MouseUp(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _CurrentScene.Events.MouseUp.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.MouseUp[i].Script);
                    Script.MouseUp(_CurrentScene, (MouseClickButtonType)e.Button, new Vertex(e.X, e.Y, 0));
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.MouseUp[i].Name + " FAILED!");
                }
            }
        }
        private void Event_MouseClick(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < _CurrentScene.Events.MousePress.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.MousePress[i].Script);
                    Script.MousePress(_CurrentScene, (MouseClickButtonType)e.Button, new Vertex(e.X, e.Y, 0));
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.MousePress[i].Name + " FAILED!");
                }
            }
        }
        private void Event_MouseMove(object sender, MouseMoveEventArgs e)
        {
            for (int i = 0; i < _CurrentScene.Events.MouseMove.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.MouseMove[i].Script);
                    Script.MouseMove(_CurrentScene, new Vertex(e.X, e.Y, 0));
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.MouseMove[i].Name + " FAILED!");
                }
            }
        }
        private void Event_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            for (int i = 0; i < _CurrentScene.Events.MouseWheel.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.MouseWheel[i].Script);
                    Script.OnMouseWheel(_CurrentScene, new Vertex(e.X, e.Y, 0), e.Delta);
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.MouseWheel[i].Name + " FAILED!");
                }
            }
        }
        private void Event_RenderFrame(object sender, EventArgs e)
        {
            for (int i = 0; i < _CurrentScene.Events.RenderFrame.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.RenderFrame[i].Script);
                    Script.RenderFrame(_CurrentScene);
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.RenderFrame[i].Name + " FAILED!");
                }
            }
        }
        private void Event_EverySecond(object sender, ElapsedEventArgs e)
        {
            if(_CurrentScene.Type == SceneType.Scene2D)
            {
                Scene2D C2DS = (Scene2D)_CurrentScene;
                for(int i = 0; i < C2DS.Sprites.Count; i++)
                {
                    C2DS.Sprites[i].RaiseIndex();
                } 
            }
            for (int i = 0; i < _CurrentScene.Events.EverySecond.Count; i++)
            {
                try
                {
                    dynamic Script = CSScript.Evaluator.LoadCode(_CurrentScene.Events.EverySecond[i].Script);
                    Script.OnEverySecond(_CurrentScene);
                }
                catch
                {
                    Console.WriteLine(_CurrentScene.Events.EverySecond[i].Name + " FAILED!");
                }
            }
        }
    }
}
