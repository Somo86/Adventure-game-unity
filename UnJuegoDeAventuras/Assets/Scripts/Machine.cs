using System.Collections.Generic;
using UnityEngine;

// *****************
// Computer: Respond and select inputs randomly
// *****************
public class Machine
{
    private Insults insultsInstance;
    public Machine(Insults insultsInstance) {
        this.insultsInstance = insultsInstance;
    }
    public Insult chooseRandomInsult() {
        var randomIndex = Random.Range(0, insultsInstance.insults.Length);
        return insultsInstance.insults[randomIndex];
    }
}
