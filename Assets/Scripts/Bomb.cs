using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public GameObject explosionFX;

	private Vector3 mOffset;
	private Vector2 screenRadius;
	private bool isHeld = false;

	void Start() {
		screenRadius = MainSystem.instance.screenRadius;
		isHeld = false;
	}

	void Update() {
		if (MainSystem.gameEnded)
		{
			Explode();
		}
	}

	void OnMouseDown()
	{
		isHeld = true;
		mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
	}

	void OnMouseUp() {
		isHeld = false;
	}

	public void Explode()
	{
		GameObject explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	public void inSafeZone()
	{
		if (!isHeld)
		{
			MainSystem.instance.ScorePoint();
			Explode();
		}
	}

	private Vector3 GetMouseAsWorldPoint()
	{
		Vector3 mousePoint = Input.mousePosition;

		mousePoint.z = 0;

		return Camera.main.ScreenToWorldPoint(mousePoint);
	}


	void OnMouseDrag()
	{
		Vector3 mousePos = GetMouseAsWorldPoint();

		if (MainSystem.isPlaying && -screenRadius.x < mousePos.x && mousePos.x < screenRadius.x && -screenRadius.y < mousePos.y && mousePos.y < screenRadius.y)
		{
			transform.position = mousePos + mOffset;
		}
	}
}
