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
            this._Time.Elapsed += Event_TimerTick;
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
            EventArguments Arguments = new EventArguments();
            CallEvents("Closing", _CurrentScene.Events.Events("Closing"), Arguments);
        }
        private void Event_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            EventArguments Arguments = new EventArguments();
            Arguments.KeyDown = (KeyType)e.Key;
            Arguments.Control = e.Control;
            Arguments.Alt = e.Alt;
            Arguments.Shift = e.Shift;
            CallEvents("KeyDown", _CurrentScene.Events.Events("KeyDown"), Arguments);
        }
        private void Event_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            EventArguments Arguments = new EventArguments();
            Arguments.KeyDown = (KeyType)e.Key;
            Arguments.Control = e.Control;
            Arguments.Alt = e.Alt;
            Arguments.Shift = e.Shift;
            CallEvents("KeyUp", _CurrentScene.Events.Events("KeyUp"), Arguments);
        }
        private void Event_KeyPress(object sender, KeyboardKeyEventArgs e)
        {
            EventArguments Arguments = new EventArguments();
            Arguments.KeyDown = (KeyType)e.Key;
            Arguments.Control = e.Control;
            Arguments.Alt = e.Alt;
            Arguments.Shift = e.Shift;
            CallEvents("KeyPress", _CurrentScene.Events.Events("KeyPress"), Arguments);
        }
        private void Event_Load()
        {
            EventArguments Arguments = new EventArguments();
            CallEvents("Load", _CurrentScene.Events.Events("Load"), Arguments);
        }
        private void Event_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EventArguments Arguments = new EventArguments();
            Arguments.Location = new Vertex(e.X, e.Y, 0);
            Arguments.ButtonDown = (MouseClickType)e.Button;
            CallEvents("MouseDown", _CurrentScene.Events.Events("MouseDown"), Arguments);
        }
        private void Event_MouseUp(object sender, MouseButtonEventArgs e)
        {
            EventArguments Arguments = new EventArguments();
            Arguments.Location = new Vertex(e.X, e.Y, 0);
            Arguments.ButtonDown = (MouseClickType)e.Button;
            CallEvents("MouseUp", _CurrentScene.Events.Events("MouseUp"), Arguments);
        }
        private void Event_MouseClick(object sender, MouseButtonEventArgs e)
        {
            EventArguments Arguments = new EventArguments();
            Arguments.Location = new Vertex(e.X, e.Y, 0);
            Arguments.ButtonDown = (MouseClickType)e.Button;
            CallEvents("MouseClick", _CurrentScene.Events.Events("MouseClick"), Arguments);
        }
        private void Event_MouseMove(object sender, MouseMoveEventArgs e)
        {
            EventArguments Arguments = new EventArguments();
            Arguments.Location = new Vertex(e.X, e.Y, 0);
            CallEvents("MouseMove", _CurrentScene.Events.Events("MouseMove"), Arguments);
        }
        private void Event_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            EventArguments Arguments = new EventArguments();
            Arguments.Location = new Vertex(e.X, e.Y, 0);
            Arguments.Delta = e.Delta;
            CallEvents("MouseWheel", _CurrentScene.Events.Events("MouseWheel"), Arguments);
        }
        private void Event_RenderFrame(object sender, EventArgs e)
        {
            EventArguments Arguments = new EventArguments();
            CallEvents("RenderFrame", _CurrentScene.Events.Events("RenderFrame"), Arguments);
        }
        private void Event_TimerTick(object sender, ElapsedEventArgs e)
        {
            if(_CurrentScene.Type == SceneType.Scene2D)
            {
                Scene2D C2DS = (Scene2D)_CurrentScene;
                for(int i = 0; i < C2DS.Sprites.Count; i++)
                {
                    C2DS.Sprites[i].RaiseIndex();
                } 
            }
            EventArguments Arguments = new EventArguments();
            CallEvents("TimerTick", _CurrentScene.Events.Events("TimerTick"), Arguments);
        }
        private void CallEvents(string EventName, List<ScriptSceneObject> Events, EventArguments Args)
        {
            for (int i = 0; i < Events.Count; i++)
            {
                dynamic Script = CSScript.Evaluator.LoadCode(Events[i].Script);
                Script.Invoke(EventName, _CurrentScene, Args);
                //Script.Load(_CurrentGame, Args);
                /*try
                {
                    
                }
                catch (Exception ex)
                {
                    string ErrorString = "";
                    if (ex.InnerException != null)
                    {
                        ErrorString = ex.InnerException.ToString();
                    }
                    else ErrorString = ex.Message;
                    if(ErrorString == "") Console.WriteLine(Events[i].Name + " FAILED!");
                    else Console.WriteLine(Events[i].Name + " FAILED!\n"+ErrorString);
                }*/
            }
        }
    }
}
