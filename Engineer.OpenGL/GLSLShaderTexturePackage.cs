using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Runtime.InteropServices;

namespace Engineer.Draw.OpenGL
{
    public class GLSLShaderTexturePackage : ShaderTexturePackage
    {
        private uint TexturesPointer;
        private GCHandle _BufferPointer;
        public GLSLShaderTexturePackage() : base()
        {

        }
        public GLSLShaderTexturePackage(ShaderTexturePackage Package) : base(Package)
        {

        }
        public override bool Activate()
        {
            //if (this._Active == true) return true;
            if (this._TexturesNumber == 0) return true;
            GL.GenTextures(1, out TexturesPointer);
            GL.BindTexture(TextureTarget.Texture2DArray, TexturesPointer);
            GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Modulate);
            GL.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureWrapS, (float)All.Clamp);
            GL.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureWrapT, (float)All.Clamp);
            GL.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureMagFilter, (float)All.Nearest);
            GL.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureMinFilter, (float)All.Nearest);
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);
            _BufferPointer = GCHandle.Alloc(this._Textures, GCHandleType.Pinned);
            IntPtr TextureBuffer = _BufferPointer.AddrOfPinnedObject();
            GL.TexImage3D(TextureTarget.Texture2DArray, 0, PixelInternalFormat.Rgba, 256, 256, this._TexturesNumber, 0, PixelFormat.Bgra, PixelType.UnsignedByte, TextureBuffer);
            this._Active = true;
            return true;
        }
        public override void ClearData()
        {
            this._Active = false;
            GL.DeleteTexture(TexturesPointer);
            this._TexturesNumber = 0;
            this._Textures = null;
        }
    }
}
