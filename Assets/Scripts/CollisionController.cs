using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
	public ScoreController scoreController;

	void BounceFromPaddle(Collision2D collision)
	{
		Vector3 ballPosition = this.transform.position;
		Vector3 paddlePosition = collision.gameObject.transform.position;

		float paddleHeight = collision.collider.bounds.size.y;
		float x;

		if (collision.gameObject.name == "PaddlePlayerOne")
		{
			x = 1;
		}
		else
		{
			x = -1;
		}

		float y = (ballPosition.y - paddlePosition.y) / paddleHeight;

		this.ballMovement.IncreaseHitCounter();
		this.ballMovement.MoveBall(new Vector2(x, y));
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "PaddlePLayerOne" || collision.gameObject.name == "PaddlePLayerTwo")
		{
			this.BounceFromPaddle(collision);
		}
		else if (collision.gameObject.name == "WallLeft")
		{
			Debug.Log("Collision with WallLeft");
			this.scoreController.GoalPlayerTwo();
			StartCoroutine(this.ballMovement.StartBall(true));
		}
		else if (collision.gameObject.name == "WallRight")
		{
			Debug.Log("Collision with WallRight");
			this.scoreController.GoalPlayerOne();
			StartCoroutine(this.ballMovement.StartBall(false));
		}
	}
}
