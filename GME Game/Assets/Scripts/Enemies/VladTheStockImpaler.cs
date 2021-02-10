using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VladTheStockImpaler : MonoBehaviour
{
    public GameObject Player;
    public float Health;

    public int StocksImpaled;
    public int AmountOfStocks;
    public TextMeshProUGUI ObjectiveText;

    public GameObject Shield;
    public Elevator ElevatorScript;
    public Animation OpenElevatorDoor;
    public GameObject Bull;

    public AudioSource DeadAudio;
    public AudioSource ImpaleAudio;

    public TextMeshProUGUI KilledVladText;

    public GameObject loseMenu;

    private void Start()
    {
        StartCoroutine(ImpaleStock());
    }

    void Update()
    {
        transform.LookAt(Player.transform);

        if (Health <= 0)
        {
            Destroy(Shield);
            DeadAudio.Play();
            ElevatorScript.Active = true;
            OpenElevatorDoor["OpenElevDoor4"].speed = 1;
            OpenElevatorDoor.Play();
            Bull.SetActive(true);
            KilledVladText.fontStyle = FontStyles.Strikethrough;
            ObjectiveText.text = "Bull health: 100/100";
            Destroy(gameObject);
        }

        if (StocksImpaled >= AmountOfStocks)
        {
            Player.transform.parent.GetComponent<PlayerDevNoob>().CanOpenPause = false;
            loseMenu.SetActive(true);
        }
    }

    void Deduct(int DamageAmount)
    {
        Health -= DamageAmount;
    }

    IEnumerator ImpaleStock()
    {
        yield return new WaitForSeconds(0.6f);
        StocksImpaled += 1;
        ImpaleAudio.Play();
        ObjectiveText.text = "Stonks impaled: " + StocksImpaled + "/" + AmountOfStocks;
        yield return new WaitForSeconds(2.4f);
        StartCoroutine(ImpaleStock());
    }
}
