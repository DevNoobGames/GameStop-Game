using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsAnchorCounter : MonoBehaviour
{
    public int NewsAnchors;
    public Elevator ElevatorScript;
    public Animation OpenElevatorDoor;
    public GameObject Vlad;

    public TextMeshProUGUI KilledAnchorText;
    public TextMeshProUGUI ObjectiveText;

    public void KilledAnchor()
    {
        NewsAnchors -= 1;
        ObjectiveText.text = "Newsanchors left: " + NewsAnchors;
        if (NewsAnchors <= 0)
        {
            ElevatorScript.Active = true;
            OpenElevatorDoor["OpenElevDoor1"].speed = 1;
            OpenElevatorDoor.Play();
            KilledAnchorText.fontStyle = FontStyles.Strikethrough;
            Vlad.SetActive(true);
            ObjectiveText.text = "Stonks impaled: 0/30";
        }
    }
}
