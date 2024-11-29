using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("----- Game -----")]
    private readonly string[] maps = { "Whispering Woods", "Ruins of Eldoria", "Everfrost Peaks", "Abyss of Fate", "Desolation Plants" };
    public int mapIndex;
    public int winner;

    [Header("----- Player 1 -----")]
    public GameObject[] p1Prefabs;
    public int p1CharacterIndex; 
    private GameObject p1;
    public Transform[] p1SpawnPoints;

    [Header("----- Player 2 -----")]
    public GameObject[] p2Prefabs;
    public int p2CharacterIndex;
    private GameObject p2;
    public Transform[] p2SpawnPoints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Winner(int player)
    {
        winner = player;
        LoadScene("GameOver");
    }

    public void StartGame()
    {
        if (mapIndex == 5) mapIndex = Random.Range(0, 4);
        LoadScene(maps[mapIndex]);
        p1 = Instantiate (p1Prefabs[mapIndex], p1SpawnPoints[mapIndex].position, Quaternion.identity);
        p2 = Instantiate(p1Prefabs[mapIndex], p1SpawnPoints[mapIndex].position, Quaternion.identity);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
