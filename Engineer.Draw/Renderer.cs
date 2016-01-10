using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Mathematics;

namespace Engineer.Draw
{
    public class Renderer
    {
        private object _RenderDestination;
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
        public virtual void SetProjectionMatrix(float[] Matrix)
        {

        }
        public virtual void SetModelViewMatrix(float[] Matrix)
        {

        }
        public virtual void RenderGeometry(List<Vertex> Vertices, List<Vertex> Normals, List<Vertex> TexCoords, List<Face> Faces, bool Update)
        {

        }
    }
}
