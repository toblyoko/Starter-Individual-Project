using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
	public float destroyDelay = 2f;
	float timer;

	void Start()
	{
		timer = destroyDelay;
	}

	void Update()
	{
		if (timer > 0.0f)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			MainSystem.instance.StartGame();
			Destroy(gameObject);
		}
	}
}
