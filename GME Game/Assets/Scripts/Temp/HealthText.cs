using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public PlayerDevNoob playerScript;

    private void Update()
    {
        text.text = playerScript.Health.ToString();
    }
}
