using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_PointSystem : MonoBehaviour
{
    public SoundEffectPlayer soundEffect;

    private Rigidbody2D starBody;
    static public int ScoreNum;

    private void Awake()
    {
        starBody= GetComponent<Rigidbody2D>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //will be destroyed whenever collide with Player
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ScoreNum+= 1;
            soundEffect.happySE();
        }
    }
}
