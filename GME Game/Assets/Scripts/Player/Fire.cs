using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Player;
    public GameObject projectile;

    public int StandardDamageAmount; //Standard amount of damage
    public int SpecialDamageAmount; //Headshots f.i.
    public int HeadShotDamage;
    public RaycastHit hit;
    public bool canShoot;
    public Animation ShootAnim;
    public AudioSource ShootAudio;

    private void Start()
    {
        SpecialDamageAmount = StandardDamageAmount;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootAnim.Play("Scene");
            ShootAnim["DiamondThrow"].layer=1;
            ShootAnim.Play("DiamondThrow");
            GameObject DonutShot = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            DonutShot.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
            Destroy(DonutShot, 4f);
            ShootAudio.Play();
        }
    }
}
