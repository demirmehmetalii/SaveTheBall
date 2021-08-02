using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] Panels pnl;
    [Header("Images")]
    [SerializeField] Images img;
    [Header("Buttons")]
    [SerializeField] Buttons btn;
    [Header("Texts")]
    [SerializeField] Texts txt;

    private CanvasGroup activePanel = null;

    private void Start()
    {
        UpdateTexts();
    }

    public void Initialize(bool isButtonDerived)
    {
        btn.play.gameObject.SetActive(isButtonDerived);
        img.taptoStart.gameObject.SetActive(!isButtonDerived);
        FadeInAndOutPanels(pnl.mainMenu);
    }

    public void StartGame()
    {
        GameManager.OnStartGame();
    }

    public void OnGameStarted()
    {
        FadeInAndOutPanels(pnl.gameIn);
    }

    public void OnFail()
    {
        FadeInAndOutPanels(pnl.fail);
    }

    public void OnSuccess()
    {
        FadeInAndOutPanels(pnl.success);
    }

    public void ReloadScene(bool isSuccess)
    {
        GameManager.ReloadScene(isSuccess);
    }

    void FadeInAndOutPanels(CanvasGroup _in)
    {
        CanvasGroup _out = activePanel;
        activePanel = _in;

        if(_out != null)
        {
            _out.interactable = false;
            _out.blocksRaycasts = false;

            _out.DOFade(0f, Configs.UI.FadeOutTime).OnComplete(() =>
            {
                _in.DOFade(1f, Configs.UI.FadeOutTime).OnComplete(() =>
                {
                    _in.interactable = true;
                    _in.blocksRaycasts = true;
                });
            });
        }
        else
        {
            _in.DOFade(1f, Configs.UI.FadeOutTime).OnComplete(() =>
            {
                _in.interactable = true;
                _in.blocksRaycasts = true;
            });
        }
       
       
    }


    public void UpdateTexts()
    {
        txt.level.text = "LEVEL " + (SaveLoadManager.GetLevel() + 1).ToString();
    }

    [System.Serializable]
    public class Panels
    {
        public CanvasGroup mainMenu, gameIn, success, fail;
    }

    [System.Serializable]
    public class Images
    {
        public Image taptoStart;
    }

    [System.Serializable]
    public class Buttons
    {
        public Button play;
    }

    [System.Serializable]
    public class Texts
    {
        public TextMeshProUGUI level;
    }
}
