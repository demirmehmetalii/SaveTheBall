public class GameManager : Singleton<GameManager>
{
    public static bool canStart = false, isRunning = false;

    public static void OnStartGame()
    {
        if (isRunning || !canStart) return;

        canStart = false;

        //TODO SEND ANALYTICS EVENT

        UIManager.Instance.OnGameStarted();
        TouchHandler.Instance.OnGameStarted();
        PlayerController.Instance.OnGameStarted();
        isRunning = true;
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
