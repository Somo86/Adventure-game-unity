using UnityEngine;
using UnityEngine.UI;

// *********************************
// Manage game points 
// *********************************
public class PointsCounter
{
    public bool hasWinner = false;
    private int MachinePoints = 0;
    private int PlayerPoints = 0;

    private Text PlayerPointsText;
    private Text ComputerPointsText;

    public PointsCounter(Text PlayerPointsText, Text ComputerPointsText) {
        this.PlayerPointsText = PlayerPointsText;
        this.ComputerPointsText = ComputerPointsText;
    }
    // Add points and show it on screen
    public void addMachinePoint() {
        MachinePoints = MachinePoints + 1;
        ComputerPointsText.GetComponent<Text>().text = MachinePoints.ToString();
        if(MachinePoints >= 3) { hasWinner = true; }
    }

    public void addPlayerPoint() {
        PlayerPoints = PlayerPoints + 1;
        PlayerPointsText.GetComponent<Text>().text = PlayerPoints.ToString();
        if(PlayerPoints >= 3) { hasWinner = true; }
    }

    public int getMachinePoints() {
        return MachinePoints;
    }

    public int getPlayerPoints() {
        return PlayerPoints;
    }
}
