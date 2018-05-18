using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour {

	public Transform pointPrefab;
	private Transform[] points;
	[Range(10, 100)] public int resolution = 10;
	public GraphFunctionName function;

	static private GraphFunction[] functions = {
		SineFunction, Sine2DFunction, MultiSineFunction, MultiSine2DFunction, RippleFunction
	};

	private void Awake() {
		points = new Transform[resolution * resolution];

		float step = 2f / resolution;
		Vector3 scale = Vector3.one * step;
		Vector3 position = Vector3.zero;
		for (int i=0, z=0; z<resolution ;z++)
		{		
			position.z = (z + 0.5f) * step - 1f;
			for(int x=0; x<resolution; x++, i++)
			{
				Transform point = Instantiate(pointPrefab);
				position.x = (x + 0.5f) * step - 1f;
				position.y = SineFunction(position.x, position.z, Time.time);
				point.localPosition = position;
				point.localScale = scale;
				point.SetParent(transform, false);
				points[i] = point;
			}
			
		}

	}

	const float pi = Mathf.PI;
	static float SineFunction(float x, float z, float t)
	{
		return Mathf.Sin(pi * (x + t));
	}
	static float Sine2DFunction(float x, float z, float t)
	{
		float y = Mathf.Sin(pi * (x + t));
		y += Mathf.Sin(pi * (z + t));
		y *= 0.5f;
		return y;
	}
	static float MultiSineFunction(float x, float z, float t)
	{
		float y = Mathf.Sin(pi * (x + t));
		y += Mathf.Sin(2f* pi * (x + t * 2f)) / 2f;
		y *= 2f / 3f;
		return y;
	}
	static float MultiSine2DFunction (float x, float z, float t) {
		float y = 4f * Mathf.Sin(pi * (x + z + t * 0.5f));
		y += Mathf.Sin(pi * (x + t));
		y += Mathf.Sin(2f * pi * (z + 2f * t)) * 0.5f;
		y *= 1f / 5.5f;
		return y;
	}
	static float RippleFunction (float x, float z, float t) {
		float d = Mathf.Sqrt(x * x + z * z);
		float y = Mathf.Sin(pi * (4f  * d - t));
		y /= 1f + 10f * d;
		return y;
	}
	// Update is called once per frame
	void Update () {
		GraphFunction foo = functions[(int)function];

		float t = Time.time;
		for (int i=0; i<points.Length; i++)
		{
			Transform point = points[i];
			Vector3 position = point.localPosition;
			position.y = foo(position.x, position.z, Time.time);
			point.localPosition = position;
		}
	}
}
