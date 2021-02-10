using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalM : MonoBehaviour
{
    public GameObject Player;
    public GameObject ShotPos1;
    public GameObject ShotPos2;
    public Vector3 ShotPos;
    public string ActiveShootPos;

    public Animation Shooter;

    public GameObject Bullet;
    public bool Shooting;
    public bool Loaded;

    public float Health;
    public GameObject FireCircle;

    public GameObject FinalAnimobj;

    public AudioSource DeadAudio;
    public AudioSource NormalBackgroundAudio;
    public AudioSource VictoryAudio;

    public TextMeshProUGUI BeatMText;
    public TextMeshProUGUI ObjectiveText;
    public TextMeshProUGUI HintText;

    private void Start()
    {
        Loaded = true;
        ActiveShootPos = "ShotPos1";
        StartCoroutine(StartShooting());
    }

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(FireCircle);
            DeadAudio.Play();
            NormalBackgroundAudio.Stop();
            VictoryAudio.Play();
            FinalAnimobj.GetComponent<FinalAnim>().PlayFinal();
            BeatMText.fontStyle = FontStyles.Strikethrough;
            ObjectiveText.text = "TO THE MOON!";
            HintText.text = "Wow...";
            Destroy(gameObject);
        }

        Vector3 targetPostition = new Vector3(Player.transform.position.x,
                                        this.transform.position.y,
                                        Player.transform.position.z);
        this.transform.LookAt(targetPostition);

        if (Shooting && Loaded)
        {
            Loaded = false;
            if (ActiveShootPos == "ShotPos1")
            {
                ShotPos = ShotPos1.transform.position;
                ActiveShootPos = "ShotPos2";
            }
            else if (ActiveShootPos == "ShotPos2")
            {
                ShotPos = ShotPos2.transform.position;
                ActiveShootPos = "ShotPos1";
            }

            GameObject eBullet = Instantiate(Bullet, ShotPos, Quaternion.identity);
            eBullet.GetComponent<Rigidbody>().AddForce((Player.transform.position - eBullet.transform.position).normalized * 2000);
            Destroy(eBullet, 4f);
            StartCoroutine(Reload()); 
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.2f);
        Loaded = true;
    }

    IEnumerator StartShooting()
    {
        Shooter["ShootingM"].speed = 1;
        Shooter.Play();
        yield return new WaitForSeconds(1.7f);
        Shooting = true;
        yield return new WaitForSeconds(5);
        Shooting = false;
        Shooter["ShootingM"].speed = -1;
        Shooter["ShootingM"].time = Shooter["ShootingM"].length;
        Shooter.Play();
        yield return new WaitForSeconds(4);
        StartCoroutine(StartShooting());
    }

    public void Deduct(int DamageAmount)
    {
        Health -= DamageAmount;
        ObjectiveText.text = "M Health: " + Health + "/100";
    }

}
