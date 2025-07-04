using DualPantoToolkit;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject[] walls = new GameObject[8];
    private bool[] tasks = { false, false, false, false, false, false, false, false };
    public Transform playerStartPosition;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        StartLevel();
    }

    async void StartLevel()
    {
        await Task.Delay(1000);
        GameObject player = Instantiate(gameManager.player, playerStartPosition);

        await gameManager.upperHandle.SwitchTo(player, 75.0f);

        await Task.Delay(2000);

        await gameManager.RenderObstacle();

        await Task.Delay(1000);

        gameManager.upperHandle.Free();
    }

    //level task system
    void OnEnable()
    {
        WallTrigger.OnWallHit += HandleWallHit;
    }

    void OnDisable()
    {
        WallTrigger.OnWallHit -= HandleWallHit;
    }

    void HandleWallHit(GameObject target)
    {
        for(int i = 0; i < 8; i++)
        {
            if (walls[i] != target)
                continue;
            tasks[i] = true;
            CheckTasks();
            return;
        }
    }

    async Task CheckTasks()
    {
        bool checkSum = true;
        foreach(bool task in tasks)
        {
            checkSum &= task;
        }
        if (checkSum)
        {
            await Task.Delay(2000);
            gameManager.LoadNextScene();
        }
    }
}
