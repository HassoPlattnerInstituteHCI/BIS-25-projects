using DualPantoToolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Task = System.Threading.Tasks.Task;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject puck;
    public GameObject player;
    public GameObject enemy;

    [HideInInspector] public UpperHandle upperHandle;
    [HideInInspector] public LowerHandle lowerHandle;

    PantoCollider[] pantoColliders;

    private int currentLevelIndex = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        upperHandle = GetComponent<UpperHandle>();
        lowerHandle = GetComponent<LowerHandle>();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(++currentLevelIndex);
    }

    public async Task RenderObstacle()
    {
        pantoColliders = GameObject.FindObjectsOfType<PantoCollider>();
        foreach (PantoCollider collider in pantoColliders)
        {
            collider.CreateObstacle();
            collider.Enable();
        }
    }














    /*
    async void Introduction()
    {
        Level level = GetComponent<Level>();
        await level.PlayIntroduction(0.2f, 3000);
        await Task.Delay(1000);

        // TODO 2:
        await StartGame();
    }

    async Task StartGame()
    {
        await Task.Delay(1000);

        // TODO 4: activate PlayerWall game object at Unity editor, and remove this comment-out
        await RenderObstacle();

        await Task.Delay(1000);

        Instantiate(player, playerSpawn);
        Instantiate(enemy, new Vector3(0.35f, 0.0f, -5.64f), Quaternion.identity);
        GameObject sb = Instantiate(ball, ballSpawn);

        // TODO 3:
        await lowerHandle.SwitchTo(sb, 50.0f);
        upperHandle.Free();
    }

    
    */
}
