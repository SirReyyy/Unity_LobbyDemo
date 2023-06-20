using UnityEngine;
using Photon.Pun;
using Cinemachine;
using TMPro;

public class PlayerScript : MonoBehaviour {

    private Singleton singletonManager;
    public TMP_Text playerName;
    public GameObject characterMesh;
    private SkinnedMeshRenderer[] skinnedMeshes;
    
    public GameObject PCFollowPrefab;
    CinemachineVirtualCamera vcam;

    PhotonView photonView;


    void Start() {
        singletonManager = Singleton.Instance;
        photonView = photonView = GetComponent<PhotonView>();

        if(photonView.IsMine) {
            int sCharIndex = singletonManager.characterIndex;
            string sPlyrName = singletonManager.playerName;

            skinnedMeshes = characterMesh.GetComponentsInChildren<SkinnedMeshRenderer>();

            playerName.text = sPlyrName;
            LoadSkinnedMesh(sCharIndex);
            SpawnCameraFollow();
        }
    } //-- Start()

    private void LoadSkinnedMesh(int index) {
        if(index >= 0 && index < skinnedMeshes.Length) {
            foreach(SkinnedMeshRenderer smr in skinnedMeshes) {
                smr.enabled = false;
            }

            skinnedMeshes[index].enabled = true;
        }
    } //-- LoadSkinnedMesh()

    private void SpawnCameraFollow() {
        vcam = PCFollowPrefab.GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = gameObject.transform.GetChild(0).gameObject.transform;

        Instantiate(PCFollowPrefab);
    } //-- SpawnCameraFollow()
}


/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/