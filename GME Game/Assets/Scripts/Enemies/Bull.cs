using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bull : MonoBehaviour
{
    public GameObject Player;
    public Vector3 target;
    public bool Charging;
    public bool reloading;
    public bool CanLook;
    public float speed;
    public float rotationspeed;
    public Animation RunAnim;

    public float Health;

    public Elevator ElevatorScript;
    public Animation OpenElevatorDoor;
    public GameObject FinalM;
    public Collider HeadColl;

    public AudioSource DeadAudio;
    public AudioSource ChargeAudio;

    public TextMeshProUGUI KilledBullText;
    public TextMeshProUGUI ObjectiveText;

    private void Start()
    {
        Vector3 targetPostition = new Vector3(Player.transform.position.x,
            this.transform.position.y,
            Player.transform.position.z);
        this.transform.LookAt(targetPostition);
    }

    void Update()
    {
        ObjectiveText.text = "Bull health: " + Health + "/100";

        if (Health <= 0)
        {
            DeadAudio.Play();
            ElevatorScript.Active = true;
            OpenElevatorDoor["OpenElevDoor5"].speed = 1;
            OpenElevatorDoor.Play();
            FinalM.SetActive(true);
            KilledBullText.fontStyle = FontStyles.Strikethrough;
            ObjectiveText.text = "M health: 100/100";
            Destroy(gameObject);
        }

        if (CanLook)
        {
            var q = Quaternion.LookRotation(Player.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotationspeed * Time.deltaTime);

            Vector3 eulerAngles = transform.rotation.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.z = 0;
            transform.rotation = Quaternion.Euler(eulerAngles);
        }

        if (!Charging)
        {
            
            Charging = true;
            HeadColl.enabled = true;
            CanLook = false;
            ChargeAudio.Play();
            target = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
            RunAnim.enabled = true;
        }
        if (Charging)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            if (Vector3.Distance(transform.position, target) < 0.5f && !reloading)
            {
                HeadColl.enabled = false;
                reloading = true;
                StartCoroutine(ReloadingCo());
            }
        }
    }

    void Deduct(int DamageAmount)
    {
        Health -= DamageAmount;
    }

    IEnumerator ReloadingCo()
    {
        RunAnim.enabled = false;
        yield return new WaitForSeconds(1f);
        CanLook = true;
        yield return new WaitForSeconds(1);
        reloading = false;
        Charging = false;
    }
}
