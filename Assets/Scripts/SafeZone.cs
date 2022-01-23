using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Bomb")
		{
			other.gameObject.GetComponent<Bomb>().inSafeZone();
		}
	}
}
