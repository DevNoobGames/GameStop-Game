using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsAnchor : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerFeet;
    GameObject ebullet;
    public bool reloaded;
    public int Health;
    public NewsAnchorCounter Counter;

    public AudioSource DeadAudio;


    private void Start()
    {
        ebullet = Resources.Load("Cube") as GameObject;
        reloaded = false;
        StartCoroutine(Reload());
    }

    private void Update()
    {
        transform.LookAt(Player.transform);

        if (Health <= 0)
        {
            Counter.KilledAnchor();
            DeadAudio.Play();
            Destroy(gameObject);
        }

        if (reloaded)
        {
            reloaded = false;
            GameObject bullets = Instantiate(ebullet, this.transform.position, transform.rotation) as GameObject;
            bullets.transform.LookAt(Player.transform);
            Rigidbody rb = bullets.GetComponent<Rigidbody>();
            rb.velocity = (PlayerFeet.transform.position - this.transform.position).normalized * 40;
            Destroy(bullets, 4f);
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        int randVal = Random.Range(2, 5);
        yield return new WaitForSeconds(randVal);
        reloaded = true;
    }

    void Deduct(int DamageAmount)
    {
        Health -= DamageAmount;
    }
}
