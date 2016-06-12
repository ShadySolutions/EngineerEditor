﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSScriptLibrary;
using OpenTK.Input;
using Engineer.Engine;

namespace Engineer.Runner
{
    public class EventManager
    {
        private Dictionary<string, EventDelegates> _Events;
        public void AddEvents(string Name, List<ScriptSceneObject> Events)
        {
            if (_Events == null) _Events = new Dictionary<string, EventDelegates>();
            EventDelegates EventDelegates = new EventDelegates(Events);
            _Events.Add(Name, EventDelegates);
        }
        public void Run(string Name, Game CurrentGame, EventArguments Args)
        {
            _Events[Name].Run(CurrentGame, Args);
        }
    }
    public class EventDelegates
    {
        private static string _ScriptHeader =       "using Engineer.Data;\n"+
                                                    "using Engineer.Engine;\n"+
                                                    "using Engineer.Mathematics;\n"+
                                                    "using System;\n"+
                                                    "using System.Collections.Generic;\n";
        private List<ScriptSceneObject> _Events;
        private List<MethodDelegate> _Delegates;
        public EventDelegates(List<ScriptSceneObject> Events)
        {
            this._Events = Events;
            this._Delegates = new List<MethodDelegate>();
            for(int i = 0; i < Events.Count; i++)
            {
                _Delegates.Add(CSScript.Evaluator.CreateDelegate(_ScriptHeader + Events[i].Script));
            }
        }
        public void Run(Game CurrentGame, EventArguments Args)
        {
            for(int i = 0; i < _Events.Count; i++)
            {
                if(_Events[i].Enabled)
                {
                    try
                    {
                        _Delegates[i](CurrentGame, Args);
                    }
                    catch (Exception ex)
                    {
                        string ErrorString = "";
                        if (ex.InnerException != null)
                        {
                            ErrorString = ex.InnerException.ToString();
                        }
                        else ErrorString = ex.Message;
                        if(ErrorString == "") Console.WriteLine(_Events[i].Name + " FAILED!");
                        else Console.WriteLine(_Events[i].Name + " FAILED!\n"+ErrorString);
                    }
                }
            }
        }
    }
}
