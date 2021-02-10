using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamShot : MonoBehaviour
{
    public GameObject Player;
    GameObject ebullet;
    public bool reloaded;
    public Animation ThrowAnim;

    private void Start()
    {
        ebullet = Resources.Load("SpamBullet") as GameObject;
    }

    private void Update()
    {
        if (reloaded)
        {
            reloaded = false;
            GameObject bullets = Instantiate(ebullet, this.transform.position, transform.rotation) as GameObject;
            ThrowAnim.Play();
            bullets.transform.LookAt(Player.transform);
            Rigidbody rb = bullets.GetComponent<Rigidbody>();
            //rb.velocity = (Player.transform.position - this.transform.position).normalized * 30;
            rb.AddForce((Player.transform.position - this.transform.position).normalized * 800);
            Destroy(bullets, 4f);
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        int randVal = Random.Range(1, 3);
        yield return new WaitForSeconds(randVal);
        reloaded = true;
    }
}
