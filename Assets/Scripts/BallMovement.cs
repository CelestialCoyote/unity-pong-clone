using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeed;

    int hitCounter = 0;


	void Start ()
	{
        StartCoroutine(this.StartBall());
	}

    void PositionBall(bool isStartingPlayerOne)
	{
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

        if(isStartingPlayerOne)
		{
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
		else
		{
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayerOne = true)
	{
        this.PositionBall(isStartingPlayerOne);
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);

        if (isStartingPlayerOne)
            this.MoveBall(new Vector2(-1, 0));
        else
            this.MoveBall(new Vector2(1, 0));
    }

    public void MoveBall(Vector2 dir)
	{
        dir = dir.normalized;
        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;
        Rigidbody2D rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = dir * speed;
    }


    public void IncreaseHitCounter()
	{
        if(this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
		{
            this.hitCounter++;
        }
    }
}
