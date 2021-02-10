using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public GameObject player;

    public float RotationSpeed = 1;
    private Quaternion targetRotation;


    void Update()
    {
        /*targetRotation = player.transform.rotation;
        this.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);*/

        var q = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, RotationSpeed * Time.deltaTime);
    }
}
