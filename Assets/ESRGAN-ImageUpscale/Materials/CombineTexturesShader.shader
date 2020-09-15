Shader "Hidden/CombineTexturesShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _AlphaTex ("Alpha Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            Texture2D _AlphaTex;
            SamplerState my_point_clamp_sampler;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 a = _AlphaTex.Sample(my_point_clamp_sampler, i.uv);
                
                return fixed4(col.r, col.g, col.b, a.r);
            }
            ENDCG
        }
    }
}
