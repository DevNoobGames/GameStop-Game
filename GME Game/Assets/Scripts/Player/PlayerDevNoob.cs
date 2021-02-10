using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDevNoob : MonoBehaviour
{
    public Animation ShootAnim;
    public float Health;

    public bool FireInjured;

    public GameObject[] NewsAnchors;
    public GameObject Vlad;
    public GameObject Bull;
    public GameObject MEnemy;
    public GameObject StagePanel;
    public Text StageText;
    public Animation Elevator2Anim;
    public Animation Elevator3Anim;
    public Animation Elevator5Anim;
    public Animation Elevator6Anim;
    public Animation FinalAnim;

    public GameObject FinalCam;
    public GameObject FPSController;
    public GameObject CrossHairs;
    public ParticleSystem RocketParticle;

    public AudioSource BackgroundAudio;
    public AudioSource ElevatorAudio;
    public AudioSource ElevatorPing;
    public AudioSource HurtAudio;

    public GameObject HurtPanel;

    public bool CanOpenPause;
    public GameObject MenuPause;
    public GameObject LostMenu;
    public GameObject WinMenu;

    public TextMeshProUGUI HintText;
    public Camera playerCam;
    public AudioListener PlayerAudioListener;

    public bool RunTimer;
    public float Timer;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI TimerTextWin;

    private void Start()
    {
        CanOpenPause = true;
        RunTimer = true;
        Timer = 0;
    }

    private void Update()
    {
        if (RunTimer)
        {
            Timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(Timer / 60);
            int seconds = Mathf.RoundToInt(Timer % 60);
            TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && CanOpenPause)
        {
            MenuPause.SetActive(true);
        }
        if (Health <= 0)
        {
            CanOpenPause = false;
            LostMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            if (other.GetComponent<Elevator>().Active == true)
            {
                Debug.Log("active");
                GetComponent<CharacterController>().enabled = false;
                this.transform.position = other.GetComponent<Elevator>().NextElevator.transform.position;
                this.transform.eulerAngles = other.GetComponent<Elevator>().NextRotation;
                GetComponent<CharacterController>().enabled = true;

                BackgroundAudio.Pause();
                ElevatorAudio.Play();

                StartCoroutine(OpenDoor(other.GetComponent<Elevator>().NextElevator));
            }
        }
        if (other.CompareTag("ActivateStage2"))
        {
            Destroy(other.gameObject);
            StagePanel.SetActive(true);
            StageText.text = "Starting Stage 2!";
            GetComponent<CharacterController>().enabled = false;

            Elevator2Anim["OpenElevDoor1"].speed = -1;
            Elevator2Anim["OpenElevDoor1"].time = Elevator2Anim["OpenElevDoor1"].length;
            Elevator2Anim.Play();
            HintText.text = "HINT: Boxes will shoot balls on impact";
            StartCoroutine(StartStage2());
        }
        if (other.CompareTag("ActivateStage3"))
        {
            Destroy(other.gameObject);
            StagePanel.SetActive(true);
            StageText.text = "Starting Stage 3!";
            GetComponent<CharacterController>().enabled = false;

            Elevator3Anim["OpenElevDoor3"].speed = -1;
            Elevator3Anim["OpenElevDoor3"].time = Elevator3Anim["OpenElevDoor3"].length;
            Elevator3Anim.Play();
            HintText.text = "HINT: Destroy Vlad before he impales all paper stonks";
            StartCoroutine(StartStage3());
        }
        if (other.CompareTag("ActivateStage4"))
        {
            Destroy(other.gameObject);
            StagePanel.SetActive(true);
            StageText.text = "Starting Stage 4!";
            GetComponent<CharacterController>().enabled = false;

            Elevator5Anim["OpenElevDoor5"].speed = -1;
            Elevator5Anim["OpenElevDoor5"].time = Elevator5Anim["OpenElevDoor5"].length;
            Elevator5Anim.Play();
            HintText.text = "HINT: Hit the balls of the bull";
            StartCoroutine(StartStage4());
        }
        if (other.CompareTag("ActivateStage5"))
        {
            Destroy(other.gameObject);
            StagePanel.SetActive(true);
            StageText.text = "Starting Stage 5!";
            GetComponent<CharacterController>().enabled = false;

            Elevator6Anim["OpenElevDoor6"].speed = -1;
            Elevator6Anim["OpenElevDoor6"].time = Elevator6Anim["OpenElevDoor6"].length;
            HintText.text = "HINT: Hit the eye";
            Elevator6Anim.Play();
            StartCoroutine(StartStage5());
        }

        if (other.CompareTag("RocketLaunch"))
        {
            RunTimer = false;
            int minutes = Mathf.FloorToInt(Timer / 60);
            int seconds = Mathf.RoundToInt(Timer % 60);
            TimerTextWin.text = "Reached in " + minutes.ToString("00") + ":" + seconds.ToString("00");
            playerCam.enabled = false;
            PlayerAudioListener.enabled = false;
            FinalCam.SetActive(true);
            CrossHairs.SetActive(false);
            FinalAnim.Play("RocketShot");
            RocketParticle.Play();
            CanOpenPause = false;
            StartCoroutine(OpenWinMenu());
        }
    }

    IEnumerator OpenWinMenu()
    {
        yield return new WaitForSeconds(3);
        FPSController.SetActive(false);
        WinMenu.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FireFloor") && !FireInjured)
        {
            FireInjured = true;
            Health -= 1;
            GotHurt();
            StartCoroutine(FireTimer());
        }
        if (other.CompareTag("BullHead"))
        {
            if (Bull.GetComponent<Bull>().Charging && !FireInjured)
            {
                GotHurt();
                FireInjured = true;
                Health -= 10;
                StartCoroutine(FireTimer());
            }
        }
    }

    IEnumerator StartStage2()
    {
        yield return new WaitForSeconds(1);
        GetComponent<CharacterController>().enabled = true;
        StagePanel.SetActive(false);
        foreach (GameObject Markus in NewsAnchors)
        {
            Markus.GetComponent<NewsAnchor>().enabled = true;
        }
    }

    public void GotHurt()
    {
        HurtAudio.Play();
        HurtPanel.SetActive(true);
        StartCoroutine(StopTheHurt());
    }

    IEnumerator StopTheHurt()
    {
        yield return new WaitForSeconds(0.4f);
        HurtPanel.SetActive(false);
    }

    IEnumerator StartStage3()
    {
        yield return new WaitForSeconds(1);
        GetComponent<CharacterController>().enabled = true;
        StagePanel.SetActive(false);
        Vlad.GetComponent<VladTheStockImpaler>().enabled = true;
    }

    IEnumerator StartStage4()
    {
        yield return new WaitForSeconds(1);
        GetComponent<CharacterController>().enabled = true;
        StagePanel.SetActive(false);
        Bull.GetComponent<Bull>().enabled = true;
    }

    IEnumerator StartStage5()
    {
        yield return new WaitForSeconds(1);
        GetComponent<CharacterController>().enabled = true;
        StagePanel.SetActive(false);
        MEnemy.GetComponent<FinalM>().enabled = true;
    }

    IEnumerator FireTimer()
    {
        yield return new WaitForSeconds(0.5f);
        FireInjured = false;
    }

    IEnumerator OpenDoor(GameObject Elevator)
    {
        yield return new WaitForSeconds(4);
        Elevator.GetComponent<Animation>().Play();
        ElevatorAudio.Stop();
        BackgroundAudio.Play();
        ElevatorPing.Play();
    }



}
