using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public GameObject Player;
    public BotCounter BotCounter;
    public int Health;

    public AudioSource DeadAudio;

    void Update()
    {
        transform.LookAt(Player.transform);

        if (Health <= 0)
        {
            BotCounter.KilledBot();
            DeadAudio.Play();
            Destroy(gameObject);
        }
    }

    void Deduct(int DamageAmount)
    {
        Health -= DamageAmount;
    }

   

}
