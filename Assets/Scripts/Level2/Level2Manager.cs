using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    private GameManager gameManager;
    public Transform playerStartPosition;
    public Transform puckStartPosition;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        StartLevel();
    }

    async void StartLevel()
    {
        await Task.Delay(1000);
        GameObject player = Instantiate(gameManager.player, playerStartPosition);
        GameObject puck = Instantiate(gameManager.puck, puckStartPosition);

        await gameManager.upperHandle.SwitchTo(player, 75.0f);
        await gameManager.upperHandle.SwitchTo(puck, 75.0f);

        await Task.Delay(2000);

        await gameManager.RenderObstacle();

        await Task.Delay(1000);

        gameManager.upperHandle.Free();
    }

    //level task system
    void OnEnable()
    {
        PuckTrigger.OnPuckHit += HandlePuckHit;
    }

    void OnDisable()
    {
        PuckTrigger.OnPuckHit -= HandlePuckHit;
    }

    void HandlePuckHit(GameObject target)
    {
        CheckTask();
    }

    async Task CheckTask()
    {
        await Task.Delay(2000);
        gameManager.LoadNextScene();
    }
}
