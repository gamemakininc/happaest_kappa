Shader "Hidden/Custom/Glitch Shader"
{
	HLSLINCLUDE

		#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
		TEXTURE2D_SAMPLER2D(_TrashTex, sampler_TrashTex);

		float _Drift;
		float _Jitter;
		//Texture2D _TrashTex;
		
		float4 Frag(VaryingsDefault i) : SV_Target
		{
			float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

			float4 offset = SAMPLE_TEXTURE2D(_TrashTex, sampler_TrashTex, i.texcoord);

			half4 src1 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, float2(i.texcoord.x - (_Drift / 30) + ((offset.x - 0.5) * _Jitter / 30), i.texcoord.y));
			half4 src2 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, float2(i.texcoord.x + (_Drift / 30) + ((offset.x - 0.5) * _Jitter / 30), i.texcoord.y));

			return half4(src1.r, src2.g, src1.b, 1);
		}
	
	ENDHLSL

    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM
            #pragma vertex VertDefault
            #pragma fragment Frag

			ENDHLSL
        }
    }
}
