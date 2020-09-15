// Adapted from https://gist.github.com/mattatz/d14898c16008e3ad1abe
Shader "Mattatz/SobelFilter" {

	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_DeltaX("Delta X", Float) = 0.01
		_DeltaY("Delta Y", Float) = 0.01
	}

		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGINCLUDE

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float _DeltaX;
			float _DeltaY;

			float sobel(sampler2D tex, float2 uv) {
				float2 delta = float2(_DeltaX, _DeltaY);

				float4 hr = float4(0, 0, 0, 0);
				float4 vt = float4(0, 0, 0, 0);

				hr += tex2D(tex, (uv + float2(-1.0, -1.0) * delta)) * 1.0;
				hr += tex2D(tex, (uv + float2(0.0, -1.0) * delta)) * 0.0;
				hr += tex2D(tex, (uv + float2(1.0, -1.0) * delta)) * -1.0;
				hr += tex2D(tex, (uv + float2(-1.0,  0.0) * delta)) * 2.0;
				hr += tex2D(tex, (uv + float2(0.0,  0.0) * delta)) * 0.0;
				hr += tex2D(tex, (uv + float2(1.0,  0.0) * delta)) * -2.0;
				hr += tex2D(tex, (uv + float2(-1.0,  1.0) * delta)) * 1.0;
				hr += tex2D(tex, (uv + float2(0.0,  1.0) * delta)) * 0.0;
				hr += tex2D(tex, (uv + float2(1.0,  1.0) * delta)) * -1.0;

				vt += tex2D(tex, (uv + float2(-1.0, -1.0) * delta)) * 1.0;
				vt += tex2D(tex, (uv + float2(0.0, -1.0) * delta)) * 2.0;
				vt += tex2D(tex, (uv + float2(1.0, -1.0) * delta)) * 1.0;
				vt += tex2D(tex, (uv + float2(-1.0,  0.0) * delta)) * 0.0;
				vt += tex2D(tex, (uv + float2(0.0,  0.0) * delta)) * 0.0;
				vt += tex2D(tex, (uv + float2(1.0,  0.0) * delta)) * 0.0;
				vt += tex2D(tex, (uv + float2(-1.0,  1.0) * delta)) * -1.0;
				vt += tex2D(tex, (uv + float2(0.0,  1.0) * delta)) * -2.0;
				vt += tex2D(tex, (uv + float2(1.0,  1.0) * delta)) * -1.0;

				return sqrt(hr * hr + vt * vt);
			}

			float4 frag(v2f_img IN) : COLOR {
				float s = sobel(_MainTex, IN.uv);
				return float4(s, s, s, 1);
			}

			ENDCG

			Cull Off ZWrite Off ZTest Always
			Pass {
				CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag
				ENDCG
			}

		}
			FallBack "Diffuse"
}