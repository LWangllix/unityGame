using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{

    private Rigidbody2D playerBody;
    private SpriteRenderer Clr;
    public PlayerColorChanger[] color;
    void Start()
    {
        color = Resources.FindObjectsOfTypeAll<PlayerColorChanger>();

        playerBody = GameObject.Find("player").GetComponent<Rigidbody2D>();
        Clr = GameObject.Find("player").GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (playerBody.velocity.y <= 0)
        {
            playerBody.AddForce(Vector2.up * 800f);
            PlayerColorChanger c = color[Random.Range(0, color.Length)];
            Clr.color = c.Col;
        }
    }


}
