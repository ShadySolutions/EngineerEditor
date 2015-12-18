﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Engineer.Draw.GLSL
{
    public class GLSLShaderManager : ShaderManager
    {
        public GLSLShaderManager()
        {

        }
        public override bool AddShader(string ID)
        {
            for (int i = 0; i <_Shader.Count; i++)
            {
                if (_Shader[i].ShaderID == ID) return false;
            }
            GLSLShaderProgram NewProgram;
            NewProgram = new GLSLShaderProgram(ID);
            _Shader.Add(NewProgram);
            return true;
        }
    }
}
