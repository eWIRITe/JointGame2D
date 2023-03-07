using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    public float JumpForce;

    public Rigidbody2D PlayerRB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "JumpPlatf")
        {
            PlayerRB.velocity = new Vector2(0, 0);

            PlayerRB.AddForce(new Vector2(0, JumpForce));
        }
    }
}
