Shader "Custom/BumpWave" {
	Properties {
		_Color ("Color", Color) = (1, 1, 1, 1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Inside ("Inside", Range(0, 0.5)) = 0
		_Rim ("Rim", Range(0, 1.5)) = 1.5
		_Speed ("Speed", Range(0,5)) = 0
		_Tile ("Tile", Range(1, 10)) = 5
		_Strength ("Strength", Range(0, 5)) = 1
	}
	SubShader {
		Tags { "Queue"="Transparent" 
			   "RenderType"="Transparent" }
		Cull Off
		ZWrite Off
		ZTest LEqual
		
		CGPROGRAM
		#pragma surface surf BlinnPhong alpha
		
		fixed4 _Color;
		sampler2D _MainTex;
		fixed _Inside;
		fixed _Rim;
		fixed _Speed;
		fixed _Tile;
		fixed _Strength;

		struct Input {
			float4 screenPos;
			float3 viewDir;
			float2 uv_MainTex;
		};
		
		inline fixed Fresnel(float3 viewDir) {
			float3 up = float3(0.0f, 0.0f, 1.0f);
			float theta = dot(normalize(viewDir), up);
			return fixed(1.0f - theta);
		}

		void surf (Input IN, inout SurfaceOutput o) {
			// get fresnel
			fixed fresnel = Fresnel(IN.viewDir);
			
			// fresnel effects
			fixed stepFresnel = step(fresnel, fixed(1.0f));
			fixed insideContrib = clamp(stepFresnel, _Inside, fixed(1.0f));
			fixed rimContrib = pow(fresnel, _Rim);
			
			// calc text coords
			half timeOffset = half(_Time.x) * _Speed;
			half2 texCoords1 = float2(IN.uv_MainTex.x, IN.uv_MainTex.y + timeOffset);
			half2 texCoords2 = float2(IN.uv_MainTex.x + timeOffset, IN.uv_MainTex.y);
			texCoords1 *= _Tile.xx;
			texCoords2 *= _Tile.xx;
			
			fixed texContrib = tex2D(_MainTex, texCoords1).x;
			texContrib += tex2D(_MainTex, texCoords2).x;
			texContrib *= _Strength;
			
			o.Alpha = texContrib * rimContrib * insideContrib * _Color.a;
			
			o.Albedo = 0.0;
			o.Emission = _Color.rgb;
			o.Normal = fixed3(0.0, 0.0, 1.0);
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
