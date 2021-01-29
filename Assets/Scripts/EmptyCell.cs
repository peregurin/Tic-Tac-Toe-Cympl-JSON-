using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmptyCell : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;

    private GameController gameController;

    public void SetGameControllerRef(GameController gameController)
    {
        this.gameController = gameController;
    }

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }
}
