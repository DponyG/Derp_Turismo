// EasyRoads3D v3 Shader
// transparency shader receiving shadows, useful for blending roads with the terrain on the outer edges and useful for road decals
// This uses decal:blend so make sure the road lays on top of the terrain or any other object

Shader "EasyRoads3D/ER Road Transparency" {
    Properties {

		[Header(Road Texture)]
        _MainTex ("Road", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _BumpMap ("Road Normal", 2D) = "bump" {}
        _Metallic ("Road Metallic", Range(0.0, 1.0)) = 0.0 
        _Glossiness ("Road Smoothness", Range(0.0, 1.0)) = 0.5  

    }

    SubShader {
        Tags {
            "SplatCount" = "3"
            "Queue" = "AlphaTest"
            "RenderType" = "TransparentCutout"
            "ForceNoShadowCasting"="True"

        }
        LOD 200
		Offset 0, 0

        CGPROGRAM
        #pragma surface surf Standard  fullforwardshadows decal:blend
        #pragma target 3.0
        #pragma multi_compile_fog
        #pragma exclude_renderers gles
        #include "UnityPBSLighting.cginc"

        half _depthThresh;

        uniform sampler2D _Control;

        sampler2D _MainTex;
        sampler2D _BumpMap;

		half _Metallic;
		half _Glossiness;


        half _NormalStrengh;

        struct Input {
            float3 worldPos;
            float3 worldNormal;
            float2 uv_MainTex : TEXCOORD0;
            float2 uv4_BumpMap : TEXCOORD1;

            float4 color : COLOR;

            INTERNAL_DATA
        };

        fixed4 _Color, _Color2;
        half _Threshold;

        void surf (Input IN, inout SurfaceOutputStandard o) {

            fixed4 alb = 0.0f;
			float4 c = IN.color;

			float4 _main = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			float4 _main1 = tex2D (_MainTex, IN.uv4_BumpMap) * _Color;
			
            fixed4 nrm = tex2D(_BumpMap, IN.uv_MainTex);

			half alpha = 0;
			alpha = _main.a * c.a * IN.color.a;
			
            o.Normal = UnpackNormal(nrm);
            o.Albedo = _main.rgb;
            o.Alpha = alpha;
            o.Smoothness = _Glossiness;
            o.Metallic = _Metallic;
        }
        ENDCG
    }

    Fallback "Standard"
}
