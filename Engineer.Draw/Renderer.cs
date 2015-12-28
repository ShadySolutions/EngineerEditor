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
        public virtual void Transform2D(int Width, int Height)
        {

        }
        public virtual void TransformOrtho(int Left, int Right, int Bottom, int Top)
        {

        }
        public virtual void TransformPerspective(int Width, int Height, int Angle)
        {

        }
        public virtual void TransformView(Vertex Eye, Vertex Sight)
        {

        }
        public virtual void RenderGeometry(List<Vertex> Vertices, List<Vertex> Normals, List<Vertex> TexCoords, List<Face> Faces)
        {

        }
    }
}
