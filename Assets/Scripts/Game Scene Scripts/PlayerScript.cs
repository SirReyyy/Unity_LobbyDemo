using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour {

    private Singleton singletonManager;
    public TMP_Text playerName;
    public GameObject characterMesh;
    private SkinnedMeshRenderer[] skinnedMeshes;


    void Start() {
        singletonManager = Singleton.Instance;

        int sCharIndex = singletonManager.characterIndex;
        string sPlyrName = singletonManager.playerName;

        skinnedMeshes = characterMesh.GetComponentsInChildren<SkinnedMeshRenderer>();

        playerName.text = sPlyrName;
        LoadSkinnedMesh(sCharIndex);

        Cursor.visible = false;
    } //-- Start()

    private void LoadSkinnedMesh(int index) {
        if(index >= 0 && index < skinnedMeshes.Length) {
            foreach(SkinnedMeshRenderer smr in skinnedMeshes) {
                smr.enabled = false;
            }

            skinnedMeshes[index].enabled = true;
        }
    } //-- LoadSkinnedMesh()
}


/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/