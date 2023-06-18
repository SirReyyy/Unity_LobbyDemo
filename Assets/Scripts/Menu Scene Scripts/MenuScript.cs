using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    // Reference variable for SingletonManager.Instance
    private SingletonManager singletonManager;


    // UI Variables
    public TMP_InputField playerNameInput;
    public GameObject characterButtons;



    // Variables
    string sPlyrName;
    int sCharIndex = 0;

    void Start()
    {
        // Assign the SingletonManager.Instance to the reference variable
        singletonManager = SingletonManager.Instance;

        // Accessing the variables from the reference variable
        sCharIndex = singletonManager.characterIndex;
        sPlyrName = singletonManager.playerName;

        // Get all the child buttons of the parent GameObject
        ButtonHandler[] childButtons = characterButtons.GetComponentsInChildren<ButtonHandler>();

        // Assign the button indices
        for (int i = 0; i < childButtons.Length; i++) {
            childButtons[i].buttonIndex = i;
        }
    }

    void Update() {
        sPlyrName = playerNameInput.text;
    }

    public void SetSelectedButton(int buttonIndex) {
        sCharIndex = buttonIndex;
    }

    public void SaveData() {
        if(sPlyrName == "") {
            int rndID = Random.Range(0000, 9999);

            sPlyrName = "Player" + rndID;
        }
        
        Debug.Log(sPlyrName);
        Debug.Log(sCharIndex);
    }
}



/*

Made by : Rey M. Oronos, Jr.
Project : 

*/