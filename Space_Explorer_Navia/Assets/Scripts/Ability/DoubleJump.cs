using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DoubleJumpCheck jumpCheck = collision.gameObject.GetComponent<DoubleJumpCheck>();
            jumpCheck.HasDoubleJump = true;
            Destroy(gameObject);
        }
    }
}
