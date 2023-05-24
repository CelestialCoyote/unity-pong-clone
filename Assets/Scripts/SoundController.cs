using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource paddleSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "PaddlePlayerOne" || collision.gameObject.name == "PaddlePlayerTwo"){
            this.paddleSound.Play();
        }else{
            this.wallSound.Play();
        }
    }
}
