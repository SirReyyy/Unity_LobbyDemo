using UnityEngine;
using TMPro;
using Photon.Pun;

public class CreateJoinRooms : MonoBehaviourPunCallbacks {

    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    public void CreateRoom() {
        PhotonNetwork.CreateRoom(createInput.text);
    } //-- CreateRoom()

    public void JoinRoom() {
        PhotonNetwork.JoinRoom(joinInput.text);
    } //-- CreateRoom()

    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("Menu");
    } //-- OnJoinedRoom()
}


/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/