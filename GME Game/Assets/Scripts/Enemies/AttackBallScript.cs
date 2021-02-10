using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBallScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FPSController"))
        {
            collision.gameObject.GetComponent<PlayerDevNoob>().Health -= 10;
            collision.gameObject.GetComponent<PlayerDevNoob>().GotHurt();
            Destroy(gameObject);
        }
    }
}
