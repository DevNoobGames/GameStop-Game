using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsAttack : MonoBehaviour
{
    public GameObject Player;
    public GameObject AttackBall;
    public float shootVector;
    public AudioSource LaserAudio;

    private void Start()
    {
        shootVector = 0;
        LaserAudio = GameObject.FindGameObjectWithTag("LaserAudio").GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("FPSController");
        AttackBall = GameObject.FindGameObjectWithTag("AttackBall");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FPSController"))
        {
            collision.gameObject.GetComponent<PlayerDevNoob>().Health -= 5;
            collision.gameObject.GetComponent<PlayerDevNoob>().GotHurt();
            Destroy(gameObject);
        }
        else
        {
            LaserAudio.Play();
            transform.eulerAngles = new Vector3(0, 0, 0);
            CreateBall();
            transform.eulerAngles = new Vector3(0, shootVector, 0);
            CreateBall();
            transform.eulerAngles = new Vector3(0, shootVector, 0);
            CreateBall();
            transform.eulerAngles = new Vector3(0, shootVector, 0);
            CreateBall();
            transform.eulerAngles = new Vector3(0, shootVector, 0);
            CreateBall();
            transform.eulerAngles = new Vector3(0, shootVector, 0);
            CreateBall();

            Destroy(gameObject); 
        }
    }

    public void CreateBall()
    {
        GameObject AttackBalla = Instantiate(AttackBall, transform.position, transform.rotation) as GameObject;
        AttackBalla.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        shootVector += 60;
        Destroy(AttackBalla, 3f);
    }
}
