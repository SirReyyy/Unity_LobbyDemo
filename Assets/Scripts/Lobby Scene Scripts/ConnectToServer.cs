using UnityEngine;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks {

    public LobbyScript _lobbyScript;

    void Start() {
        PhotonNetwork.ConnectUsingSettings();
        //_lobbyScript = GetComponent<LobbyScript>();
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        _lobbyScript.ShowStartButton();
    }
}


/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/