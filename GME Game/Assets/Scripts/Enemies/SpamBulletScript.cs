using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamBulletScript : MonoBehaviour
{
    public bool canAtack;

    private void Start()
    {
        canAtack = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FPSController") && canAtack)
        {
            canAtack = false;
            collision.gameObject.GetComponent<PlayerDevNoob>().Health -= 10;
            collision.gameObject.GetComponent<PlayerDevNoob>().GotHurt();
            Destroy(gameObject);
        }
        else
        {
            canAtack = false;
        }
    }

}
