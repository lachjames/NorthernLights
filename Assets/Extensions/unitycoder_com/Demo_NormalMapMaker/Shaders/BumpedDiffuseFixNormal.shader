Shader "UnityCoder/Bumped Diffuse FixNormal" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 300

CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
sampler2D _BumpMap;
fixed4 _Color;

struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
	o.Alpha = c.a;
//	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	o.Normal = tex2D(_BumpMap, IN.uv_BumpMap)*2-1; // fix for using custom normal maps
}
ENDCG  
}

FallBack "Diffuse"
}
