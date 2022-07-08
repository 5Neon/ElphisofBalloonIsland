Shader "Roystan/ToonShader"
{
Properties
{
	_Color("Color", Color) = (1,1,1,1)
	_MainTex("Main Texture", 2D) = "white" {}

	//정반사 제어
	[HDR]
	_AmbientColor("Ambient Color", Color) = (0.4,0.4,0.4,1)
	[HDR]
	_SpecularColor("Specular Color", Color) = (0.9,0.9,0.9,1)
	_Glossiness("Glossiness", Float) = 32
	
	//반사광 제어
	[HDR]
	_RimColor("Rim Color", Color) = (1,1,1,1)
	_RimAmount("Rim Amount", Range(0, 1)) = 0.716
	_RimThreshold("Rim Threshold", Range(0, 1)) = 0.1		
}

SubShader
{
	Pass
	{
		//패스값 설정
		Tags
		{
			"LightMode" = "ForwardBase"
			"PassFlags" = "OnlyDirectional"
		}
		
		CGPROGRAM
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

			float4 _AmbientColor;

			float4 _SpecularColor;
			float _Glossiness;		

			float4 _RimColor;
			float _RimAmount;
			float _RimThreshold;	

			float4 frag (v2f i) : SV_Target
			{
				float3 normal = normalize(i.worldNormal);
				float3 viewDir = normalize(i.viewDir);

				//방향광에서 조명 계산
				float NdotL = dot(_WorldSpaceLightPos0, normal);

				//그림자 맵 샘플링
				float shadow = SHADOW_ATTENUATION(i);

				//명암 분할 및 부드럽게 보간
				float lightIntensity = smoothstep(0, 0.01, NdotL * shadow);	

				//빛 강화
				float4 light = lightIntensity * _LightColor0;
				
				//정반사 계산
				float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
				float NdotH = dot(normal, halfVector);

				//광택
				float specularIntensity = pow(NdotH * lightIntensity, _Glossiness * _Glossiness);
				float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
				float4 specular = specularIntensitySmooth * _SpecularColor;				
				
				//반사광 계산
				float rimDot = 1 - dot(viewDir, normal);
				float rimIntensity = rimDot * pow(NdotL, _RimThreshold);
				rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimIntensity);
				float4 rim = rimIntensity * _RimColor;

				float4 sample = tex2D(_MainTex, i.uv);

				return (light + _AmbientColor + specular + rim) * _Color * sample;
			}
			ENDCG
		}

		//그림자 부여
		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
	}
}