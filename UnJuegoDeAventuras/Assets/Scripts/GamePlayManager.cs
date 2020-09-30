using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    // *** UI *****
    public Text InsultText;
    public Text ResponseText;
    public Transform selectionParentTransform;
    public GameObject InsultOptionPrefab;
    public Text PlayerPointsText;
    public Text ComputerPointsText;
    
    // *** Insult and response selected on each turn *****
    private Insult currentSelectedInsult;
    private Insult currentSelectedResponse;

    
    // *** Game instances dependencies *****

    private Insults InsultsInstance;
    private PointsCounter PointsManager;
    private Machine Computer;
    private TurnManager Turn;

    void Awake() {
        // Load Data
        string resource = LoadResource.GetData();
        InsultsInstance = JsonUtility.FromJson<Insults>(resource);
        
        // Load Instances
        PointsManager = new PointsCounter(PlayerPointsText, ComputerPointsText);
        Computer = new Machine(InsultsInstance);
        Turn = new TurnManager();
    }

    void Start()
    { 
        // Start game randomly
        if(Turn.currentTurnOwner == Turn.playerTurn) {
            StartPlayerTurn();
        } else {
            StartMachineTurn();
        }
    }

    //**
    //** Start turn **************************
    
    private void StartPlayerTurn() {
        Turn.setTurnForPlayer(); // 0.Player turn
        FillWithInsults(); // 1 Fill insults options and player select one and resolve Machine
    }

    private void StartMachineTurn() {
        Turn.setTurnForComputer(); // 0.Computer turn
        currentSelectedInsult = Computer.chooseRandomInsult(); // 1. Computer select question
        FillSelectedInsultText(); // 2. Fill insult selected on screen
        FillWithResponses(); // 4. Show response selection and player resolve
    }

    //****************************************

    //**
    //** Resolve turn ************************

    private void resolvePlayerTurn(bool isResponseCorrect) {
        if(isResponseCorrect){ // player wins turn
            PointsManager.addPlayerPoint(); // Add point to player
            StartCoroutine(doPlayerWinsTurn()); // Wait time before next state
        } else {
            PointsManager.addMachinePoint(); // Add point to machine
            StartCoroutine(doMachineWinsTurn()); // Wait time before next state
        }
    }

    private void resolveComputerTurn(bool isResponseCorrect) {
        if(isResponseCorrect){ // computer wins turn
            PointsManager.addMachinePoint(); // Add point to machine
            StartCoroutine(doMachineWinsTurn()); // Wait time before next state
        } else {
            PointsManager.addPlayerPoint(); // Add point to player
            StartCoroutine(doPlayerWinsTurn()); // Wait time before next state
        }
    }

    IEnumerator doPlayerWinsTurn() {
        yield return new WaitForSecondsRealtime(3);
        // Finish if winner or start turn again (player)
        if(PointsManager.hasWinner == true) {
            CrossData.Winner = "player";
            GoToFinalView(); 
        } else {
            // clean all before start again
            cleanInsultsResponses();
            StartPlayerTurn();
        }
    }

    IEnumerator doMachineWinsTurn() {
        yield return new WaitForSecondsRealtime(3);
        // Finish if winner or start turn again (computer)
        if(PointsManager.hasWinner == true) {
            CrossData.Winner = "computer";
            GoToFinalView();
        } else {
            cleanInsultsResponses();
            StartMachineTurn(); // Finish if winner or start turn again
        }
    }

    private void GoToFinalView() {
        SceneManager.LoadScene("FinalView"); 
    }

    //**************************************

    //** Click Listeners *******************
    private void InsultListener(Button button, Insult insultInstance) {
        button.onClick.AddListener(() => { InsultSelected(insultInstance); });
    }

    private void ResponseListener(Button button, Insult insultInstance) {
        button.onClick.AddListener(() => { ResponseSelected(insultInstance); });
    }

    // Insult selection listener
    // Only player can call a listener
    private void InsultSelected(Insult insultInstance) {
        currentSelectedInsult = insultInstance;
        FillSelectedInsultText();
        // Computer response to Player
        currentSelectedResponse = Computer.chooseRandomInsult();
        FillSelectedResponseText();

        //resolve computer response
        var isResponseCorrect = currentSelectedInsult.isAValidResponse(currentSelectedResponse.id);
        resolveComputerTurn(isResponseCorrect);
    }

    // Response selection listener
    // Only player can call a listener
    private void ResponseSelected(Insult insultInstance) {
        currentSelectedResponse = insultInstance;
        FillSelectedResponseText();

        //resolve player response
        var isResponseCorrect = currentSelectedResponse.isAValidResponse(currentSelectedInsult.id);
        resolvePlayerTurn(isResponseCorrect);
    }
    //**************************************

    //** UI ********************************
    private void FillWithInsults() {
        var x = 22f;
        var y = 230f;

        DestroyChildren(selectionParentTransform);

        foreach (var insultInstance in InsultsInstance.insults) {
            var insultOptionCopy = Instantiate(InsultOptionPrefab, selectionParentTransform, true);
            Button insultOptionComp = insultOptionCopy.GetComponent<Button>();
            RectTransform insultOptionTransform = insultOptionCopy.GetComponent<RectTransform>();

            insultOptionTransform.sizeDelta = new Vector2(699.8383f, 31.83621f);
            insultOptionTransform.localPosition = new Vector3(x, y, 0);
            insultOptionComp.GetComponentInChildren<Text>().text = insultInstance.insult;

            y += insultOptionTransform.rect.y * 1.8f;

            InsultListener(insultOptionComp, insultInstance);
        } 
    }

    private void FillWithResponses() {
        var x = 22f;
        var y = 230f;

        DestroyChildren(selectionParentTransform);

        foreach (var insultInstance in InsultsInstance.insults) {
            var insultOptionCopy = Instantiate(InsultOptionPrefab, selectionParentTransform, true);
            Button insultOptionComp = insultOptionCopy.GetComponent<Button>();
            RectTransform insultOptionTransform = insultOptionCopy.GetComponent<RectTransform>();

            insultOptionTransform.sizeDelta = new Vector2(699.8383f, 31.83621f);
            insultOptionTransform.localPosition = new Vector3(x, y, 0);
            insultOptionComp.GetComponentInChildren<Text>().text = insultInstance.response;

            y += insultOptionTransform.rect.y * 1.8f;

            ResponseListener(insultOptionComp, insultInstance);
        } 
    }

    private void DestroyChildren(Transform parentTransform) {
        foreach (Transform child in parentTransform.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Show insult selected on screen
    private void FillSelectedInsultText() {
        InsultText.GetComponent<Text>().text = currentSelectedInsult.insult;
    }

    // Show response selected on screen
    private void FillSelectedResponseText() {
        ResponseText.GetComponent<Text>().text = currentSelectedResponse.response;
    }

    private void cleanInsultsResponses() {
        InsultText.GetComponent<Text>().text = "";
        ResponseText.GetComponent<Text>().text = "";
    }
    //**************************************
}
