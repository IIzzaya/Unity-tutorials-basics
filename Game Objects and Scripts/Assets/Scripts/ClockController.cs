using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour {


	public Transform hoursIndicator;
	public Transform minutesIndicator;
	public Transform secondsIndicator;
	// Use this for initialization
	public bool isContinuous = true;

	const float degreesPerHour = 30f;
	const float degreesPerMinute = 6f;
	const float degreesPerSecond = 6f;

	void UpdateContinuous () {
		TimeSpan time = DateTime.Now.TimeOfDay;
		hoursIndicator.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
		minutesIndicator.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
		secondsIndicator.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
	}

	void UpdateDiscrete () {
		DateTime time = DateTime.Now;
		hoursIndicator.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
		minutesIndicator.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
		secondsIndicator.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
	}
	void Awake() {
		hoursIndicator.localRotation =
			Quaternion.Euler(0f, DateTime.Now.Hour * degreesPerHour, 0f);
		minutesIndicator.localRotation =
			Quaternion.Euler(0f, DateTime.Now.Minute * degreesPerMinute, 0f);
		secondsIndicator.localRotation =
			Quaternion.Euler(0f, DateTime.Now.Second * degreesPerSecond, 0f);
	}

	
	// Update is called once per frame
	void Update () {
		if(isContinuous)
			UpdateContinuous();
		else
			UpdateDiscrete();
		
	}
}
