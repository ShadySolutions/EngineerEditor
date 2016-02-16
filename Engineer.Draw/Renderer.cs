﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Mathematics;
using Engineer.Engine;

namespace Engineer.Draw
{
    public class Renderer
    {
        private object _RenderDestination;
        protected int _NumLights;
        public object RenderDestination
        {
            get
            {
                return _RenderDestination;
            }

            set
            {
                _RenderDestination = value;
            }
        }
        public Renderer()
        {
            this._NumLights = 0;
        }
        public virtual void SetViewport(int Width, int Height)
        {

        }
        public virtual void Clear()
        {
        }
        public virtual void ClearColor(float[] Color)
        {
            
        }
        public virtual void SetSurface(float[] Color)
        {

        }
        public virtual bool IsMaterialReady(string ID)
        {
            return false;
        }
        public virtual void SetMaterial(object[] MaterialData, bool Update)
        {

        }
        public virtual void UpdateMaterial()
        {

        }
        public virtual void SetProjectionMatrix(float[] Matrix)
        {

        }
        public virtual void SetModelViewMatrix(float[] Matrix)
        {

        }
        public virtual void SetCameraPosition(Vertex CameraPosition)
        {
        }
        public virtual bool SetViewLight(int Index, Vertex[] LightParameters)
        {
            return false;
        }
        public virtual void ResetLights()
        {
            this._NumLights = 0;
        }
        public virtual void RenderGeometry(List<Vertex> Vertices, List<Vertex> Normals, List<Vertex> TexCoords, List<Face> Faces, bool Update)
        {

        }  
        public virtual void PushPreferences()
        {

        }
        public virtual void PopPreferences()
        {

        }
    }
}
