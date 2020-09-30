[System.Serializable]
public class Insult
{
    public int id;
    public string insult;
    public string response;

    public bool isAValidResponse(int responseId) {
        return responseId == this.id;
    }
}
