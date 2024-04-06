using UnityEngine;
using System.Collections.Generic;
 
public class LevelManager : MonoBehaviour {
 
    public Transform player;
 
    private Dictionary<int, Vector3> startingPosition = new Dictionary<int, Vector3>();
 
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
 
    void LoadNewLevel(int level) {
        startingPosition[Application.loadedLevel] = player.position;
        Application.LoadLevel(level);
    }
 
    void OnLevelWasLoaded(int level) {
        if (startingPosition.ContainsKey(level)) player.position = startingPosition[level];
    }
}
