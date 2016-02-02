using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager Instance = null;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }

        else if (Instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        InitGame();
    }

    private void InitGame() {
        
    }


}
