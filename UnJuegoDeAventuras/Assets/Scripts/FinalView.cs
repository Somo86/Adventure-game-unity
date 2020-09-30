using UnityEngine;
using UnityEngine.UI;

public class FinalView : MonoBehaviour
{
    public Image background;
    public Text GameResultText;

    void Start()
    {
        // **************************
        // Defines background and message for final view depending on winner
        // **************************
        
        if(CrossData.Winner == "player") {
            background.sprite = Resources.Load<Sprite>("winBackground");
            GameResultText.GetComponent<Text>().text = "Has ganado!!! Le has roto el corazón, guerrero!";
        } else {
            background.sprite = Resources.Load<Sprite>("loseBackground");
            GameResultText.GetComponent<Text>().text = "Has perdido!!! Te ha humillado...";
        }
    }
}
