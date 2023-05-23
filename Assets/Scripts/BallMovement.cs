using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
	public float extraSpeedPerHit;
	public float maxExtraSpeed;

	int hitCounter = 0;


    void Start()
    {
        StartCoroutine(this.StartBall());
    }

	public IEnumerator StartBall(bool isStartingPlayerOne = true)
	{
		this.hitCounter = 0;
		yield return new WaitForSeconds(2);

		if (isStartingPlayerOne)
		{
			this.MoveBall(new Vector2(-1, 0));
		}
		else
		{
			this.MoveBall(new Vector2(1, 0));
		}
	}

	public void MoveBall(Vector2 direction)
	{
		direction = direction.normalized;

		float speed = this.movementSpeed + this.hitCounter + this.extraSpeedPerHit;

		Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
		rigidbody2D.velocity = direction * speed;
	}

	public void IncreaseHitCounter()
	{
		if (this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
			this.hitCounter++;
	}
}
