using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Engineer.Engine;
using Engineer.Mathematics;

namespace Engineer.Draw
{
    public class DrawEngine
    {
        private MatrixTransformer _Matrix;
        private Renderer _CurrentRenderer;
        public Renderer CurrentRenderer
        {
            get
            {
                return _CurrentRenderer;
            }

            set
            {
                _CurrentRenderer = value;
            }
        }
        public DrawEngine()
        {
            this._Matrix = new MatrixTransformer();
        }
        public virtual void DrawScene(Scene CurrentScene, int Width, int Height)
        {
            this._CurrentRenderer.ClearColor(new float[4] {(CurrentScene.BackColor.R *1.0f + 1)/256,
                                                           (CurrentScene.BackColor.G *1.0f + 1)/256,
                                                           (CurrentScene.BackColor.B *1.0f + 1)/256,
                                                           (CurrentScene.BackColor.A *1.0f + 1)/256});
            this._CurrentRenderer.Clear();
            this._CurrentRenderer.SetSurface(new float[4] { 1, 0, 0, 1 });
            this._Matrix.MatrixMode("Projection");
            this._Matrix.DefaultPerspective(Width, Height);
            this._Matrix.MatrixMode("ModelView");
            this._Matrix.LoadIdentity();
            Vertex Eye = new Vertex();
            this._Matrix.DefaultView(Eye, new Vertex(Eye.X, Eye.Y, Eye.Z - 1));
            this._Matrix.Rotate(CurrentScene.Cameras[CurrentScene.ActiveCamera].Rotation.X, 1, 0, 0);
            this._Matrix.Rotate(CurrentScene.Cameras[CurrentScene.ActiveCamera].Rotation.Y, 0, 1, 0);
            this._Matrix.Rotate(CurrentScene.Cameras[CurrentScene.ActiveCamera].Rotation.Z, 0, 0, 1);
            this._Matrix.Translate(-CurrentScene.Cameras[CurrentScene.ActiveCamera].Translation.X,
                                   -CurrentScene.Cameras[CurrentScene.ActiveCamera].Translation.Y,
                                   -CurrentScene.Cameras[CurrentScene.ActiveCamera].Translation.Z);
            this._CurrentRenderer.SetProjectionMatrix(_Matrix.ProjectionMatrix);
            this._CurrentRenderer.SetModelViewMatrix(_Matrix.ModelViewMatrix);
            for (int i = 0; i < CurrentScene.Actors.Count; i++)
            {
                if(CurrentScene.Actors[i].Active)
                {
                    this._Matrix.PushMatrix();
                    this._Matrix.Scale(CurrentScene.Actors[i].Scale.X, CurrentScene.Actors[i].Scale.Y, CurrentScene.Actors[i].Scale.Z);
                    this._Matrix.Rotate(CurrentScene.Actors[i].Rotation.X, 1, 0, 0);
                    this._Matrix.Rotate(CurrentScene.Actors[i].Rotation.Y, 0, 1, 0);
                    this._Matrix.Rotate(CurrentScene.Actors[i].Rotation.Z, 0, 0, 1);
                    this._Matrix.Translate(CurrentScene.Actors[i].Translation.X,
                                           CurrentScene.Actors[i].Translation.Y,
                                           CurrentScene.Actors[i].Translation.Z);
                    this._CurrentRenderer.SetModelViewMatrix(_Matrix.ModelViewMatrix);
                    for (int j = 0; j < CurrentScene.Actors[i].Geometries.Count; j++)
                    {
                        this._CurrentRenderer.RenderGeometry(CurrentScene.Actors[i].Geometries[j].Vertices,
                                                             CurrentScene.Actors[i].Geometries[j].Normals,
                                                             CurrentScene.Actors[i].Geometries[j].TexCoords,
                                                             CurrentScene.Actors[i].Geometries[j].Faces,
                                                             CurrentScene.Actors[i].Animated);
                    }
                    this._Matrix.PopMatrix();
                }
            }
        }
    }
}
