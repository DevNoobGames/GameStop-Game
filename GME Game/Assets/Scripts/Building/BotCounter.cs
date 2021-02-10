using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotCounter : MonoBehaviour
{
    public int Bots;
    public Elevator ElevatorScript;
    public Animation OpenElevatorDoor1;
    public GameObject NewsAnchor;

    public TextMeshProUGUI BotsKilled;
    public TextMeshProUGUI ObjectiveText;

    public void KilledBot()
    {
        Bots -= 1;
        ObjectiveText.text = "Bots left: " + Bots;
        if (Bots <= 0)
        {
            ElevatorScript.Active = true;
            OpenElevatorDoor1.Play();
            NewsAnchor.SetActive(true);
            BotsKilled.fontStyle = FontStyles.Strikethrough;
            ObjectiveText.text = "Newsanchors left: 3";
        }
    }
}
