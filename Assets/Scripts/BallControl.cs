using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public AudioSource WasitSounds;
    public AudioSource GoalSounds;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //mengambil rigidbody component dari sebuah bole
        Invoke("GoBall", 2); //memanggil function GoBall dlm 2 detik
    }
    void GoBall()
    {
        float rand = Random.Range(0, 2); //akan random nilai diantara 0-1
        if (rand < 1)
        {
            Debug.Log("Super");
            rb2d.AddForce(new Vector2(20, 15)); //add force memberikan tenaga
                                                 //liat doc add force disini https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html

        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15)); // knan
        }
    }

    void ResetBall() //ini kita buat nilai transform jadi 0
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        /*Invoke("GoBall", 2);*/
    }

    void RestartGame()
    {
        Debug.Log("Restart!");
        ResetBall();
        Invoke("GoBall", 4);
        WasitSounds.enabled = true;
        WasitSounds.Play();

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player")) //jika terkena player
        {

            // StartCoroutine(FireTriggger());
            Debug.Log("Player");
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3); //mengambil nilai velocity player
            rb2d.velocity = vel;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gawang")) //jika terkena Gawang
        {
            Debug.Log("Goalll!");
            // StartCoroutine(FireTriggger());
            Vector2 vel;
            vel.x = 0;
            vel.y = 0;
            rb2d.velocity = vel;
            GoalSounds.enabled = true;
            GoalSounds.Play();


        }
    }
    

}

