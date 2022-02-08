using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DayNight : MonoBehaviour
{
	public Text _gameTime;
	public Transform directionalLight;
	public float fullDay = 120f;
	[Range(0, 1)] public float currentTime;

	//public GameObject skybox;
	[Range(0, 1)] public float blend;

	private float h, m;
	private string hour, min;

	void Start()
	{
		_gameTime.text = "00:00";
	}

	void Update()
	{
		TimeCount();
		currentTime += Time.deltaTime / fullDay;
		if (currentTime >= 1) currentTime = 0; else if (currentTime < 0) currentTime = 0;
		directionalLight.localRotation = Quaternion.Euler((currentTime * 360f) - 90, 170, 0);

		//skybox.material.SetFloat("_Blend", blend);
	}

	void TimeCount()
	{
		h = 24 * currentTime;
		m = 60 * (h - Mathf.Floor(h));

		if (m < 10) min = "0" + (int)m; else min = ((int)m).ToString();
		if (h < 10) hour = "0" + (int)h; else hour = ((int)h).ToString();

		_gameTime.text = hour + ":" + min;
	}
}
