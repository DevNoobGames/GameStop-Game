using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMode : MonoBehaviour
{
    public PlayerDevNoob PlayerScript;
    public VladTheStockImpaler VladScript;
    public GameObject StartMenu;
    public GameObject CreditMenu;

    private void Start()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void Credits()
    {
        CreditMenu.SetActive(true);
    }

    public void NormalMode()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartMenu.SetActive(false);
    }

    public void GodMode()
    {
        PlayerScript.Health = 9999;
        VladScript.AmountOfStocks = 3000;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartMenu.SetActive(false);
    }
}
