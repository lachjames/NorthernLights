// Diffuse Bumped with separate Specular map
// Source: http://answers.unity3d.com/questions/306921/add-specular-map-to-shader.html

Shader "UnityCoder/Bumped Spec.Separate FixNormal" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
	_Shininess ("Shininess", Range (0.03, 1)) = 0.078125
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_BumpMap ("Normal map", 2D) = "bump" {}
	_SpecMap ("Specular map", 2D) = "black" {}
}
SubShader { 
	Tags { "RenderType"="Opaque" }
	LOD 400
	
CGPROGRAM
#pragma surface surf BlinnPhong
#pragma exclude_renderers flash

sampler2D _MainTex;
sampler2D _BumpMap;
sampler2D _SpecMap;
fixed4 _Color;
half _Shininess;

struct Input {
	float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	fixed4 specTex = tex2D(_SpecMap, IN.uv_MainTex);
	o.Albedo = tex.rgb * _Color.rgb;
	o.Gloss = specTex.r;
	o.Alpha = tex.a * _Color.a;
	o.Specular = _Shininess * specTex.g;
//	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
	// http://forum.unity3d.com/threads/creating-runtime-normal-maps-using-rendertotexture.135841/#post-924587
	o.Normal = tex2D(_BumpMap, IN.uv_MainTex)* 2 - 1; // custom normal map, NOT using unity normal map fileformat
	
}
ENDCG
}

FallBack "Specular"
}
