using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    // User created variables
    [HideInInspector]
    public int characterIndex = 0;  // For Character Buttons and Mesh Selection
    [HideInInspector]
    public string playerName;   // For Player Name
    [HideInInspector]
    public bool onPlay = false;


    // Public property to access the instance
    public static Singleton Instance
    {
        get { return instance; }
    }


    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);   // Destroy duplicate instances
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Keep the singleton across scenes
        }
    } //-- Awake()
}



/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/