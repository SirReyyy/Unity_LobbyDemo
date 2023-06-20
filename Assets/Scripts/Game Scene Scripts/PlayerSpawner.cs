using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;

    private float min_posX = -5.0f, max_posX = 5.0f;
    private float min_posZ = 0.0f, max_posZ = 10.0f;

    void Start() {
        SpawnPlayer();
    } //-- Start()

    public void SpawnPlayer() {
        Vector3 randomPos = new Vector3(Random.Range(min_posX, max_posX), 0.0f, Random.Range(min_posZ, max_posZ));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
        Debug.Log("Player Spawned");
    } //-- SpawnPlayer()
}


/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/