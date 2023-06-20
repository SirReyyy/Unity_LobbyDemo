using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyScript : MonoBehaviour {
    private Singleton singletonManager;
    public GameObject homePanel;
    public GameObject lobbyPanel;

    // Singleton Variable
    bool sOnPlay = false;

    void Start() {
        singletonManager = Singleton.Instance;
        sOnPlay = singletonManager.onPlay;

        if(sOnPlay) {
            // Default panel states
            homePanel.SetActive(false);
            lobbyPanel.SetActive(true);
        } else {
            // Default panel states
            homePanel.SetActive(true);
            lobbyPanel.SetActive(false);
        }

        Cursor.visible = true;
    } //-- Start()

    public void ShowStartButton() {
        homePanel.transform.Find("Start_Btn").gameObject.SetActive(true);
        homePanel.transform.Find("Connection_Txt").gameObject.SetActive(false);
    } //-- ShowStartButton()

    public void LoadMenuScene() {
        SceneManager.LoadScene("Menu");
    } //-- LoadMenuScene()
}


/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/