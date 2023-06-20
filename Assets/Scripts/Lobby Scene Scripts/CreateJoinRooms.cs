using UnityEngine;
using Photon.Pun;
using TMPro;

public class CreateJoinRooms : MonoBehaviourPunCallbacks {

    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public TMP_Text statusTxt;

    public void CreateRoom() {
        if(createInput.text != "") {
            statusTxt.text = "- Creating room. Please Wait -";
            PhotonNetwork.CreateRoom(createInput.text);
        } else {
            statusTxt.text = "- Room name cannot be empty. -";
        }
    } //-- CreateRoom()

    public void JoinRoom() {
        if(joinInput.text != "") {
            statusTxt.text = "- Joining room. Please Wait -";
            PhotonNetwork.JoinRoom(joinInput.text);
        } else {
            statusTxt.text = "- Room name cannot be empty. -";
        }
    } //-- CreateRoom()

    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("Game");
    } //-- OnJoinedRoom()
}


/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/