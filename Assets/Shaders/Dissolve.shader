Shader "Custom/Dissolve" {
	Properties {
		_MainTex ("Main Texture", 2D) = "white" {}
		_DissolveGuide ("Dissolve Guide", 2D) = "white" {}
		_DissolveAmount ("Dissolve Amount", Range(0, 1)) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		Cull Back
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _DissolveGuide;
		float _DissolveAmount;

		struct Input {
			float2 uv_MainTex;
			float2 uv_DissolveGuide;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			clip(tex2D(_DissolveGuide, IN.uv_DissolveGuide).rgb - _DissolveAmount);
			fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = tex.rgb;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
