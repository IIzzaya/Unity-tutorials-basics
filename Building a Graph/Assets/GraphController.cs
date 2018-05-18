using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour {

	public Transform pointPrefab;
	private Transform[] points;
	[Range(10, 100)] public int resolution = 10;

	private void Awake() {
		points = new Transform[resolution];

		float step = 2f / resolution;
		Vector3 scale = Vector3.one * step;
		Vector3 posistion = Vector3.zero;
		for (int i=0; i<resolution ;i++)
		{
			Transform point = Instantiate(pointPrefab);
			posistion.x = (i + 0.5f) * step - 1f;
			posistion.y = Foo(posistion.x);
			point.localPosition = posistion;
			point.localScale = scale;
			point.SetParent(transform, false);
			points[i] = point;
		}

	}

	float Foo(float x)
	{
		return Mathf.Sin(Mathf.PI * (x + Time.time));
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i<points.Length; i++)
		{
			Transform point = points[i];
			Vector3 position = point.localPosition;
			position.y = Foo(position.x);
			point.localPosition = position;
		}
	}
}
