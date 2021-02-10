using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    public AudioSource HitAudio;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HitAudio.Play();
            collision.transform.SendMessage("Deduct", 10, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Vlad"))
        {
            HitAudio.Play();
            collision.transform.SendMessage("Deduct", 5, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BullBalls"))
        {
            Debug.Log("Balls!!");
            HitAudio.Play();
            collision.transform.parent.SendMessage("Deduct", 10, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("MEye"))
        {
            Debug.Log("TheEye");
            HitAudio.Play();
            collision.transform.parent.SendMessage("Deduct", 10, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
