using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using Photon.Pun;
using TMPro;

public class MenuScript : MonoBehaviour {
    private Singleton singletonManager;


    // UI Game Objects
    public TMP_InputField playerNameInput;
    public GameObject characterButtons;


    // Singleton Variables
    string sPlyrName;
    int sCharIndex = 0;


    void Start() {
        singletonManager = Singleton.Instance;

        sCharIndex = singletonManager.characterIndex;
        sPlyrName = singletonManager.playerName;

        // Get all the child buttons of the Button_Array game object
        ButtonHandler[] childButtons = characterButtons.GetComponentsInChildren<ButtonHandler>();

        // Assign the child button indices
        for (int i = 0; i < childButtons.Length; i++)
        {
            childButtons[i].buttonIndex = i;
        }
    } //-- Start()

    void Update() {
        sPlyrName = playerNameInput.text;   // Update player name on SingletonManager
    } //-- Update()

    public void SetSelectedButton(int buttonIndex) {
        sCharIndex = buttonIndex;   // Update character index on SingletonManager
    } //-- SetSelectedButton()

    public void PlayGame() {
        if (sPlyrName == "") {
            int rndID = Random.Range(0000, 9999);
            sPlyrName = "Player" + rndID;
        }

        // Check Singleton variables
        Debug.Log("Player: " + sPlyrName + " | Index: " + sCharIndex);

        singletonManager.characterIndex = sCharIndex;
        singletonManager.playerName = sPlyrName;
        singletonManager.onPlay = true;

        // Load game scene
        SceneManager.LoadScene("Lobby");
    } //-- PlayGame()

    public void ReloadLobby() {
        // Reset character button states
        ButtonHandler[] childButtons = characterButtons.GetComponentsInChildren<ButtonHandler>();

        foreach (ButtonHandler button in childButtons)
        {
            button.EnableButton();
        }

        // Reset values to default
        playerNameInput.text = "Player";

        sPlyrName = playerNameInput.text;
        sCharIndex = 0;

        singletonManager.onPlay = false;
        
        // Reload Lobby Scene
        SceneManager.LoadScene("Lobby");
        // PhotonNetwork.LeaveRoom();
    } //-- ReloadLobby()
}



/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/