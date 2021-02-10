using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictedRotateTowards : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3(Player.transform.position.x,
                                        this.transform.position.y,
                                        Player.transform.position.z);
        this.transform.LookAt(targetPostition);
    }
}
