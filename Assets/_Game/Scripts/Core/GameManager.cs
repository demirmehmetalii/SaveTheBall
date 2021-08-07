using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static bool canStart = false, isRunning = false, aiController = false;
    public List<BallMove> ballMoves = new List<BallMove>();
    public List<CharacterController> ai = new List<CharacterController>();
    public Transform ballPosition;

    public static void OnStartGame()
    {
        if (isRunning || !canStart) return;
        canStart = false;
        UIManager.Instance.OnGameStarted();
        TouchHandler.Instance.OnGameStarted();
        PlayerController.Instance.OnGameStarted();
        isRunning = true;
    }

    public void Ball()
    {
        Level level = LevelHandler.Instance.GetLevel();
        var last = level.ballMoves.First();
        last.transform.DOMove(level.ball.position, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            var aiFirst = level.ai.First();
            aiFirst.move = true;
            level.ballMoves.Remove(last);
        });
    }

    public static void OnLevelCompleted()
    {
        isRunning = false;
        canStart = false;
        UIManager.Instance.OnSuccess();
    }

    public static void OnLevelFailed()
    {
        isRunning = false;
        canStart = false;
        UIManager.Instance.OnFail();
    }

    public static void ReloadScene(bool isSuccess)
    {
        //TODO SEND ANALYTICS EVENT

        if (isSuccess)
        {
            SaveLoadManager.IncreaseLevel();
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}