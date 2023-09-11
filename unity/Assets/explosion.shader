Shader "Custom/explosion"{
	Properties{
		_Alpha("不透明度",Range(0.0,1.0))=1
	}
	SubShader{
		Tags{"Queue"="Transparent" "RenderType"="Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			struct appdata{
				float4 vertex:POSITION;
				float2 uv:TEXCOORD0;
			};
			struct v2f{
				float2 uv:TEXCOORD0;
				float4 vertex:SV_POSITION;
			};
			v2f vert(appdata v){
				v2f o;
				o.vertex=UnityObjectToClipPos(v.vertex);
				o.uv=v.uv;
				return o;
			}
			float _Alpha;
			fixed4 frag(v2f i):SV_Target{
				return fixed4(1-1.5*length(i.uv-0.5),1-2*length(i.uv-0.5),1-3*length(i.uv-0.5),_Alpha);
			}
			ENDCG
		}
	}
}