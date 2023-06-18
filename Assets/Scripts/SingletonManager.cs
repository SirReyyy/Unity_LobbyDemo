using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    private static SingletonManager instance;

    public int characterIndex;
    public string playerName;

    // Public property to access the instance
    public static SingletonManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); // Destroy duplicate instances
        }
        else
        {
            instance = this; // Assign the instance
            DontDestroyOnLoad(this.gameObject); // Optional: Keep the singleton across scenes
        }
    }
}



/*

Made by : Rey M. Oronos, Jr.
Project : Unity Multiplayer Demo

*/