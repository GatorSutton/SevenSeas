Shader "Custom/CircleOnTerrain" {
    Properties {
	
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _AreaColor ("Area Color", Color) = (1, 1, 1)
		_Color ("Color", Color) = (1, 1, 1)
        _Center ("Center", Vector) = (0,0,0,0)
        _Radius ("Radius", Range(0, 500)) = 20
        _Border ("Border", Range(0, 100)) = 5

    }
    SubShader {
        Tags { "RenderType"="Opaque" }
       
        CGPROGRAM
        #pragma surface surf Lambert
 
		float4 _Array[2];
		float _Distance[2];
		fixed4 _Color;
        sampler2D _MainTex;
        fixed3 _AreaColor;
        float3 _Center;
		float3 _Center2;
        float _Border;
        float _Radius;
		float _Check;
 
        struct Input {
            float2 uv_MainTex;
            float3 worldPos;
        };
 
        void surf (Input IN, inout SurfaceOutput o) {
            half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
		  

		 for(int i = 0; i < 2; i++)
		 {
			_Distance[i] = distance(_Array[i], IN.worldPos);
		 }
			
		  

			_Check = 0;
			for(int i = 0; i < 2; i++)
			{
				if(_Distance[i] > _Radius && _Distance[i] < (_Radius + _Border))
					_Check = 1;
			}

			if(_Check == 1)
			{
				o.Albedo = _AreaColor;
			}
			else{
				o.Albedo = c.rgb;
			}

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}