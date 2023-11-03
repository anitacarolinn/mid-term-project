using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip jumpSound, hurtSound, happySound, stageClearSound, failedSound, landingSound, hurtEnemySound;

    public void JumpSE()
    {
        src.clip = jumpSound;
        src.Play();
    }

    public void hurtSE()
    {
        src.clip = hurtSound;
        src.Play();
    }

    public void happySE()
    {
        src.clip= happySound;
        src.Play();
    }

    public void failedSE()
    {
        src.clip = failedSound;
        src.Play();
    }

    public void stageClearSE()
    {
        src.clip = stageClearSound;
        src.Play();
    }

    public void landingSE()
    {
        src.clip = landingSound;
        src.Play();
    }

    public void hurtEnemySE()
    {
        src.clip = hurtEnemySound;
        src.Play();
    }
}
