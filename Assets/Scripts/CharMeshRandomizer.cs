using UnityEngine;

public class CharMeshRandomizer : MonoBehaviour {
    
    public SkinnedMeshRenderer[] charMeshes;
    

    void Start() {
        DeactivateAllMeshes();
        ActiveRandomMesh();
    } //-- Start()


    private void DeactivateAllMeshes() {
        // Deactivate all skinned mesh on first load
        foreach (SkinnedMeshRenderer charMesh in charMeshes)
        {
            charMesh.gameObject.SetActive(false);
        }
    } //-- DeactivateAllMeshes()


    private void ActiveRandomMesh() {
        // Get random index from the skinned mesh array
        int randomIndex = Random.Range(0, charMeshes.Length);
        charMeshes[randomIndex].gameObject.SetActive(true);
    } //-- ActiveRandomMesh()
}


/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/