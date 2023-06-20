using UnityEngine;
using UnityEngine.UI;

public class LobbyScript : MonoBehaviour {
    
    public GameObject homePanel;
    public GameObject lobbyPanel;

    void Start() {
        // Default panel states
        homePanel.SetActive(true);
        lobbyPanel.SetActive(false);
    } //-- Start()

    public void ShowStartButton() {
        homePanel.transform.Find("Start_Btn").gameObject.SetActive(true);
        homePanel.transform.Find("Connection_Txt").gameObject.SetActive(false);
    } //-- ShowStartButton()

    public void ShowLobbyPanel() {
        homePanel.SetActive(false);
        lobbyPanel.SetActive(true);
    } //-- ShowLobbyPanel()
}


/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/