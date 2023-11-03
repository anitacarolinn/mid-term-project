using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadCheck : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D footRb;

    public SoundEffectPlayer soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<StompCheck>())
        {
            footRb.velocity = new Vector2(footRb.velocity.x, 0f);
            footRb.AddForce(Vector2.up * 300f);
            soundEffect.hurtEnemySE();
        }

        
    }
}
