using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

// *******************************
// Has knowladge of who is the turn owner
// and show messages giving instructions
// *******************************
public class TurnManager
{
    public int currentTurnOwner;
    private GameObject TurnViewer;
    [ReadOnly] public int playerTurn = 1; 
    [ReadOnly] public int computerTurn = 0; 

    public TurnManager() {
        currentTurnOwner = randomPlayerTurn();
        TurnViewer = GameObject.Find("TurnSection");
    }

    public int randomPlayerTurn() {
       return Random.Range(0, 2); // Random Range never return max number, so need 2 to max
    }

    public void setTurnForComputer() {
        currentTurnOwner = computerTurn;
        TurnViewer.GetComponent<TurnView>().FillComputerTurn();
    }

    public void setTurnForPlayer() {
        currentTurnOwner = playerTurn;
        TurnViewer.GetComponent<TurnView>().FillPlayerTurn();
    }

}
