Shader "Unlit/SnakeTest"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

		

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
			

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				uint   id : SV_VertexID;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			half4 _Color;

			uniform float4 _Positions[127];

			uniform int _SubSegments;
			uniform int _PointsPerSegment;
			
			uniform int _NumOfVertices;
			

			float4 RotateAroundYInDegrees(float4 vertex, float degrees)
			{
				float alpha = degrees * UNITY_PI * 2;
				float sina, cosa;
				sincos(alpha, sina, cosa);
				float2x2 m = float2x2(cosa, -sina, sina, cosa);
				return float4(mul(m, vertex.xy), vertex.zw).xyzw;
			}

            v2f vert (appdata v)
            {
                v2f o;
				float alpha = frac((v.id / 8) / (float)5);
				int indexRef = (v.id)/ (8 * 5);
				float3 vertexOffset = _Positions[indexRef];

				float4 newPos = v.vertex + alpha * float4(0, 1.0, 0, 0);
				newPos -= float4(0, 0.5, 0, 0);
				newPos = RotateAroundYInDegrees(newPos, lerp(0, _Positions[indexRef].w, alpha));
				newPos = RotateAroundYInDegrees(newPos, _Positions[indexRef].z);
				newPos += half4(_Positions[indexRef].xy, 0, 0);
				
				o.vertex = UnityObjectToClipPos( newPos );

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _Color;
				return col;
            }
            ENDCG
        }
    }
}
