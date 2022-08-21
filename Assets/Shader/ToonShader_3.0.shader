Shader "Unlit/ToonShader 3.0"
{
	Properties
	{
		[Header(Main)]
        _Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_MainTex("Texture", 2D) = "white" {}
		
		//빛
		[Header(Light)]
		[HDR]
		_LightController("Light Controller", Color) = (0.5, 0.5, 0.5, 1.0)

		//정반사광
		[Header(Highlight)]
		_HLighSize("HLight Size", Range(50.0, 0.0)) = 15.0
		[HDR]
		_HLightController("HLight Controller", Color) = (1.0, 1.0, 1.0, 1.0)
		
		//반사광
		[Header(Reflected Light)]
		_RLightSize("RLight Size", Range(0.0, 1.0)) = 0.65
		[HDR]
		_RLightController("RLight Controller", Color) = (1.0, 1.0, 1.0, 1.0)
		_RLightThreshold("RLight Threshold", Range(0.0, 1.0)) = 0.1

		//그림자
		[Header(Shadow Core)]
		_ShdowSmoothness("Shadow Smoothness",Range(0.01, 1.0)) = 0.01

		// //투명도
		// [Header(Transparency)]
		// [Toggle(ENABLE_EXAMPLE_FEATURE)]
        // _Transparency ("Transparency", Range(0.0, 0.5)) = 0.25
	}

	SubShader
	{
		// zwrite off
		// Blend SrcAlpha OneMinusSrcAlpha
     
		Pass
		{
			//패스 설정
			Tags
			{
				//"Queue" = "Transparent"
				"RenderType"= "Transparent"
				"LightMode" = "ForwardBase"
				"PassFlags" = "OnlyDirectional"
			}
			
			CGPROGRAM
			#pragma multi_compile_fwdbase
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			struct appdata
			{
				float4 vertex : POSITION;				
				float4 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};
			

			struct v2f
			{
				float4 pos : SV_POSITION;
				float3 worldNormal : NORMAL;
				float2 uv : TEXCOORD0;
				float3 viewDir : TEXCOORD1;	
				SHADOW_COORDS(2)
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
				
			v2f vert (appdata v)
			{
				//버택스값을 월드 스페이스에서 쉐도우맵 스페이스로 변환
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);		
				o.viewDir = WorldSpaceViewDir(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				TRANSFER_SHADOW(o)
				return o;
			}
				
			float4 _Color;
			float4 _LightController;
			float4 _HLightController;
			float  _HLighSize;		
			float4 _RLightController;
			float  _RLightSize;
			float  _RLightThreshold;	
			float  _ShdowSmoothness;
			//float  _Transparency;

			float4 frag (v2f i) : SV_Target
			{
				float3 normal = normalize(i.worldNormal);
				float3 viewDir = normalize(i.viewDir);

				//정반사 계산
				float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
				float NdotH = dot(normal, halfVector);

				//그림자 맵 샘플링
				float shadow = SHADOW_ATTENUATION(i);

				//조명 계산
				float NdotL = dot(_WorldSpaceLightPos0, normal);

				//빛 명암 분할 및 강도
				float lightIntensity = smoothstep(0, _ShdowSmoothness, NdotL * shadow);	
				float4 light = lightIntensity * _LightColor0;

				//광택
				float specularIntensity = pow(NdotH * lightIntensity, _HLighSize * _HLighSize);
				float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
				float4 specular = specularIntensitySmooth * _HLightController;				
					
				//반사광 계산
				float rimDot = 1 - dot(viewDir, normal);
				float rimIntensity = rimDot * pow(NdotL, _RLightThreshold);
				rimIntensity = smoothstep(_RLightSize - 0.01, _RLightSize + 0.01, rimIntensity);
				float4 rim = rimIntensity * _RLightController;
				float4 sample = tex2D(_MainTex, i.uv);
				//sample.a = _Transparency;

				return (light + _LightController + specular + rim) * _Color * sample;
			}
			ENDCG
		}
		//그림자 부여
		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
	}
}