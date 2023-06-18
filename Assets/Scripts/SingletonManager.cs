using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    private static SingletonManager instance;

    // User created variables
    public int characterIndex = 0;  // For Character Buttons and Mesh Selection
    public string playerName;   // For Player Name


    // Public property to access the instance
    public static SingletonManager Instance
    {
        get { return instance; }
    }


    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);   // Destroy duplicate instances
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Keep the singleton across scenes
        }
    } //-- Awake()
}



/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/