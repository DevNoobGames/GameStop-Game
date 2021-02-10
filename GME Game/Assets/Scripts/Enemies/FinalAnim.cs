using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAnim : MonoBehaviour
{
    public GameObject FinalCam;
    public GameObject FPSController;
    public Animation FinalAnimation;
    public GameObject CrossHairs;

    public void PlayFinal()
    {
        Runner();
    }

    public void Runner()
    {
        FPSController.GetComponent<PlayerDevNoob>().FireInjured = false;
        FPSController.GetComponent<PlayerDevNoob>().HurtPanel.SetActive(false);
        FPSController.transform.position = new Vector3(10, 139, -21);
        FPSController.SetActive(false);
        FinalCam.SetActive(true);
        CrossHairs.SetActive(false);
        FinalAnimation.Play();
        StartCoroutine(ContinueGame());
    }

    IEnumerator ContinueGame()
    {
        yield return new WaitForSeconds(4);
        FinalCam.SetActive(false);
        FPSController.SetActive(true);
        CrossHairs.SetActive(true);
    }
}
