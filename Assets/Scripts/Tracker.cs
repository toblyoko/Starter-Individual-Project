using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tracker : MonoBehaviour
{
	public Text trackText;

	void Start()
	{
		
	}

	void Update()
	{
		trackText.text = "Pos: " + transform.position.ToString();
	}
}
