using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    private Singleton singletonManager;


    // UI Game Objects
    public TMP_InputField playerNameInput;
    public GameObject characterButtons;
    public GameObject menuPanel;
    public GameObject characterPanel;


    // Variable Declaration
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

        // Default panel to be active
        menuPanel.SetActive(true);
        characterPanel.SetActive(false);
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

        // Load new scene
        SceneManager.LoadScene("Game");
    } //-- PlayGame()

    public void ShowMenuPanel() {
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

        menuPanel.SetActive(true);
        characterPanel.SetActive(false);
    } //-- ShowMenuPanel()

    public void ShowCharacterPanel() {
        menuPanel.SetActive(false);
        characterPanel.SetActive(true);
    } //-- ShowCharacterPanel()
}



/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/