using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePlayerOne : MonoBehaviour
{
    public float movementSpeed;

	private void FixedUpdate()
	{
		float velocity = Input.GetAxisRaw("Vertical");

		GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocity) * movementSpeed;
	}
}
