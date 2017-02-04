using System;
using System.Collections.Generic;

using Amethyst.Graphics.OpenGL;
using Amethyst.Math;

namespace Amethyst.Graphics
{
    /// <summary>
    /// Class for handling GLSL Program
    /// </summary>
    public class GLSLProgram : IDisposable
    {
        Dictionary<string, int> m_Attributes = new Dictionary<string, int>();
        Dictionary<string, int> m_Uniforms = new Dictionary<string, int>();
        
        public int VertexPositionLocation { get; private set; }
        public int VertexColorLocation { get; private set; }
        public int VertexTextureCoordLocation { get; private set; }
        public int TextureSamplerLocation { get; private set; }
        public int MVPMatrixLocation { get; private set; }

        public void SetVertexPositionAttribName(string attribName)
        {
            VertexPositionLocation = GetAttribLocation(attribName);
        }
        public void SetVertexColorAttribName(string attribName)
        {
            VertexColorLocation = GetAttribLocation(attribName);
        }
        public void SetVertexTextureCoordAttribName(string attribName)
        {
            VertexTextureCoordLocation = GetAttribLocation(attribName);
        }
        public void SetTextureSamplerUniformName(string uniformName)
        {
            TextureSamplerLocation = GetUniformLocation(uniformName);
        }
        public void SetMVPMatrixUniformName(string uniformName)
        {
            MVPMatrixLocation = GetUniformLocation(uniformName);
        }

        public void ChangeTextureSampler(int sampler)
        {
            Use();
            GL.Uniform1(TextureSamplerLocation, sampler);
        }
        public void ChangeMVPMatrix(ref Matrix4 matrix)
        {
            Use();
            GL.UniformMatrix4(MVPMatrixLocation, ref matrix);
        }

        /// <summary>
        /// Create a new GLSL program by compiling and linking the vertex and fragment shaders sources codes
        /// </summary>
        /// <param name="vertexShaderSRC">Source code of the vertex shader</param>
        /// <param name="fragmentShaderSRC">Source code of the fragment shader</param>
        public GLSLProgram(string vertexShaderSRC, string fragmentShaderSRC)
        {
            if ((vertexShaderSRC == null) || (fragmentShaderSRC == null))
            {
                throw new Exception("You must specify a vertex shader and a fragment shader");
            }

            Logger.WriteLine("Creating GLSL Program");
            ID = GL.CreateProgram();

            #region VERTEX SHADER
            int vertexShader = GL.CreateShader(ShaderType.GL_VERTEX_SHADER);
            GL.ShaderSource(vertexShader, vertexShaderSRC);
            GL.CompileShader(vertexShader);
            Logger.WriteLine("Vertex Shader : " + GL.GetShaderInfoLog(vertexShader));
            GL.AttachShader(ID, vertexShader);
            #endregion
            #region FRAGMENT SHADER
            int fragmentShader = GL.CreateShader(ShaderType.GL_FRAGMENT_SHADER);
            GL.ShaderSource(fragmentShader, fragmentShaderSRC);
            GL.CompileShader(fragmentShader);
            Logger.WriteLine("Fragment Shader : " + GL.GetShaderInfoLog(fragmentShader));
            GL.AttachShader(ID, fragmentShader);
            #endregion
            GL.LinkProgram(ID);
            Logger.WriteLine("Program : " + GL.GetProgramInfoLog(ID));
            #region CLEANUP
            GL.DetachShader(ID, vertexShader);
            GL.DeleteShader(vertexShader);
            GL.DetachShader(ID, fragmentShader);
            GL.DeleteShader(fragmentShader);
            #endregion

            PopulateDictionnaries();
            SetDefaultLocations();
            Logger.WriteLine("GLSL Program created");
        }

        void PopulateDictionnaries()
        {
            Use();
            #region ATTRIBUTES
            int num = GetParam(ProgramParamName.GL_ACTIVE_ATTRIBUTES);
            for (int i = 0; i < num; ++i)
            {
                string name = GL.GetActiveAttrib(ID, i);
                int location = GL.GetAttribLocation(ID, name);
                m_Attributes.Add(name, location);
            }
            #endregion
            #region UNIFORMS
            num = GetParam(ProgramParamName.GL_ACTIVE_UNIFORMS);
            for (int i = 0; i < num; ++i)
            {
                string name = GL.GetActiveUniform(ID, i);
                int location = GL.GetUniformLocation(ID, name);
                m_Uniforms.Add(name, location);
            }
            #endregion
        }
        void SetDefaultLocations()
        {
            SetVertexPositionAttribName("vertexPosition");
            SetVertexColorAttribName("vertexColor");
            SetVertexTextureCoordAttribName("vertexTexCoord");
            SetTextureSamplerUniformName("texSampler");
            SetMVPMatrixUniformName("MVP");
        }

        /// <summary>
        /// Delete the GLSL program
        /// </summary>
        public void Dispose()
        {
            Logger.WriteLine("Deleting GLSL Program");
            GL.DeleteProgram(ID);
            Logger.WriteLine("GLSL Program deleted");
        }

        /// <summary>
        /// Get the GLSL program ID
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Get if this program is a GLSL program
        /// </summary>
        public bool IsProgram
        {
            get { return GL.IsProgram(ID); }
        }
        /// <summary>
        /// Get the GLSL program info log
        /// </summary>
        public string InfoLog
        {
            get { return GL.GetProgramInfoLog(ID); }
        }
        
        /// <summary>
        /// Retrieves a given GLSL program parameter
        /// </summary>
        /// <param name="pname">The parameter we want the value</param>
        /// <returns></returns>
        public int GetParam(ProgramParamName pname)
        {
            int param;
            GL.GetProgram(ID, pname, out param);
            return param;
        }
        /// <summary>
        /// Set the GLSL program as active
        /// </summary>
        public void Use()
        {
            GL.UseProgram(ID);
        }
        /// <summary>
        /// Validate the program<br />
        /// This will update the program info log
        /// </summary>
        public void Validate()
        {
            GL.ValidateProgram(ID);
        }

        /// <summary>
        /// Get the given attribute location
        /// </summary>
        /// <param name="name">The attribute's name</param>
        /// <returns>The location of the attribute</returns>
        public int GetAttribLocation(string name)
        {
            if (m_Attributes.ContainsKey(name))
            {
                return m_Attributes[name];
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Get the given uniform location
        /// </summary>
        /// <param name="name">The uniform's name</param>
        /// <returns>The location of the uniform</returns>
        public int GetUniformLocation(string name)
        {
            if (m_Uniforms.ContainsKey(name))
            {
                return m_Uniforms[name];
            }
            else
            {
                return -1;
            }
        }
        
        /// <summary>
        /// Set the given uniform matrix with the given Matrix4
        /// </summary>
        /// <param name="name">The uniform matrix's name</param>
        /// <param name="matrix">The Matrix4 that will feed the uniform matrix</param>
        public void UniformMatrix(string name, ref Matrix4 matrix)
        {
            Use();
            int loc = GetUniformLocation(name);
            GL.UniformMatrix4(loc, ref matrix);
        }
        /// <summary>
        /// Set the given uniform with an int value
        /// </summary>
        /// <param name="name">The uniform's name</param>
        /// <param name="value">The int value that will feed the uniform</param>
        public void Uniform(string name, int value)
        {
            Use();
            int loc = GetUniformLocation(name);
            GL.Uniform1(loc, value);
        }
        /// <summary>
        /// Set the given uniform with a float value
        /// </summary>
        /// <param name="name">The uniform's name</param>
        /// <param name="value">The float value that will feed the uniform</param>
        public void Uniform(string name, float value)
        {
            Use();
            int loc = GetUniformLocation(name);
            GL.Uniform1(loc, value);
        }
        /// <summary>
        /// Set the given uniform with a Vector4
        /// </summary>
        /// <param name="name">The uniform's name</param>
        /// <param name="v">The Vector4 that will feed the uniform</param>
        public void Uniform(string name, Vector4 v)
        {
            Use();
            int loc = GetUniformLocation(name);
            GL.Uniform4(loc, v.X, v.Y, v.Z, v.W);
        }
        /// <summary>
        /// Set the given uniform with a Vector2
        /// </summary>
        /// <param name="name">The uniform's name</param>
        /// <param name="v">The Vector2 that will feed the uniform</param>
        public void Uniform(string name, Vector2 v)
        {
            Use();
            int loc = GetUniformLocation(name);
            GL.Uniform2(loc, v.X, v.Y);
        }

        public static GLSLProgram CreateDefaultProgram()
        {
            return new GLSLProgram(Shaders.VertexShader2D, Shaders.FragmentShader2D);
        }
    }
}
