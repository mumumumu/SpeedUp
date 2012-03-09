using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace speedup {
    /**
     * Class for drawing simple polygons.
     * You can use this in your game, if you'd
     * like.  You'll probably want to change the
     * above namespace from "PhysicsDemo" to something
     * more appropriate, though.
     * 
     * If you want me to add features, feel free
     * to contact the course staff.
     * 
     *  -Don
     */
    public class Polygondrawer : IDisposable {
        protected BasicEffect effect;
        protected VertexDeclaration decl;
        protected GraphicsDevice m_device;
        protected SamplerState m_samplerstate;

        public Polygondrawer( GraphicsDevice device, int width, int height, Camera eye, BlendState blendMode ) {
            m_device = device;
            effect = new BasicEffect( m_device );
            effect.Projection = Matrix.CreateOrthographicOffCenter( 0, width, height, 0, 0, 1 );

            effect.TextureEnabled = true;
            effect.LightingEnabled = false;




            if ( blendMode == BlendState.AlphaBlend ) {
                m_device.BlendState = BlendState.AlphaBlend;
            }
            else if ( blendMode == BlendState.Additive ) {
                m_device.BlendState = BlendState.Additive;
            }




        }

        public void Dispose() {
            effect.Dispose();
        }

        public void drawPolygons(Matrix worldeffect,
                  Texture2D texture, VertexPositionTexture[] vertices, BlendState blendMode, Camera eye)
        {


            effect.View = eye.get_transformation();
            effect.World = worldeffect;
            effect.Texture = texture;

            m_samplerstate = new SamplerState();



            m_samplerstate.AddressU = TextureAddressMode.Wrap;
            m_samplerstate.AddressV = TextureAddressMode.Wrap;

            m_device.SamplerStates[0] = m_samplerstate; 

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

            }
            m_device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, vertices, 0, vertices.Length / 3);
        }
    }
}