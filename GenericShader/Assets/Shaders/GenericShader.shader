Shader "Custom/GenericShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
		Tags
		{
			"Queue" = "Transparent"
		}
        Pass
        {
			Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

			float4 red()
			{
				return float4(1.0, 0.0, 0.0, 1.0);
			}

			float4 red_flash()
			{
				return float4(abs(sin(_Time.a)), 0.0, 0.0, 1.0);
			}

			float4 coord(float2 st)
			{
				return float4(st.x, st.y, 0.0, 1.0);
			}

			float plot(float2 st, float pct)
			{
				return smoothstep(pct - 0.02, pct, st.y) - smoothstep(pct, pct+0.02, st.y);
			}

			float4 shape(float2 st)
			{
				float y = st.x; // straight line
				//float y = pow(st, 5.0); // curved line
				//float y = step(0.5, st.x); // step
				//float y = smoothstep(0.1, 0.9, st.x);

				float pct = plot(st, y);
				float4 color = float4(y, y, y, 1.0);
				color = (1.0 - pct) * color + pct * float4(0.0, 1.0, 0.0, 1.0);
				return color;
			}

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
				float4 color = float4(1.0, 1.0, 1.0, 1.0);
				//color = red();
				//color = red_flash();
				//color = coord(i.uv);
				//color = shape(i.uv);
                //color = tex2D(_MainTex, i.uv); // sample the texture
                return color;
				
            }
            ENDCG
        }
    }
}
