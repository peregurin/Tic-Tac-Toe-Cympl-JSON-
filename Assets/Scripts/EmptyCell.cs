using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmptyCell : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;


    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        buttonText.text = "X";
        button.interactable = false;
    }
}
