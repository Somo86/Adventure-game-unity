using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnView : MonoBehaviour
{
    public Text TurnText;

    public void FillPlayerTurn() {
        TurnText.GetComponent<Text>().text = "Escoge un insulto!";
        TurnText.GetComponent<Text>().color = Color.blue;
    }

    public void FillComputerTurn() {
        TurnText.GetComponent<Text>().text = "Qué ha dicho?! Respóndele!.";
        TurnText.GetComponent<Text>().color = Color.red;
    }
}
