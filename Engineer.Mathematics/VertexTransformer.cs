using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Mathematics
{
    public class VertexTransformer
    {
        public static Vertex CrossProduct(Vertex V1, Vertex V2)
        {
            return new Vertex(V1.Y * V2.Z - V1.Z * V2.Y, V1.Z * V2.X - V1.X * V2.Z, V1.X * V2.Y - V1.Y * V2.X);
        }
        public static Vertex CalculateNormal(Vertex[] Vertices)
        {
            if (Vertices.Length == 2) return Normalize(CrossProduct(Vertices[0], Vertices[1]));
            return Normalize(CrossProduct(CrossProduct(Vertices[0], Vertices[1]), Vertices[2]));
        }
        public static Vertex Average(Vertex[] Vertices)
        {
            VertexBuilder Average = new VertexBuilder(0, 0, 0);
            for(int i = 0; i < Vertices.Length; i++)
            {
                Average.X += Vertices[i].X;
                Average.Y += Vertices[i].Y;
                Average.Z += Vertices[i].Z;
            }
            return (Average *= 1.0f/Vertices.Length).ToVertex();
        }
        public static Vertex Normalize(Vertex V)
        {
            return (new VertexBuilder(V.X, V.Y, V.Z).Normalize()).ToVertex();
        }
    }
}
