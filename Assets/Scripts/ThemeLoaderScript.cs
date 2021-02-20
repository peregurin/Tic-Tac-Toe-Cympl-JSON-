using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Theme
{
    public string name;
    public Color32[] themeColors = new Color32[3]; 
}

public class ThemeLoaderScript : MonoBehaviour
{
    [SerializeField]
    private List<Theme> themes;

    [SerializeField]
    private string currentTheme;

    [SerializeField]
    private Image backGround;
    [SerializeField]
    private Image board;
    [SerializeField]
    private GameObject gridLines;

    public void SetTheme()
    {
        if(currentTheme == themes[0].name)
        {
            Debug.Log("set theme 1");
            backGround.color = themes[0].themeColors[0];
            board.color = themes[0].themeColors[1];
            for (int i = 0; i < 4; i++)
            {
                gridLines.transform.GetChild(i).gameObject.GetComponent<Image>().color = themes[0].themeColors[2];
            }
        }
        else if(currentTheme == themes[1].name)
        {
            Debug.Log("set theme 2");
            backGround.color = themes[1].themeColors[0];
            board.color = themes[1].themeColors[1];
            for (int i = 0; i < 4; i++)
            {
                gridLines.transform.GetChild(i).gameObject.GetComponent<Image>().color = themes[1].themeColors[2];
            }
        }
        Reload(false);
        Reload(true);
    }

    private void Reload(bool toggle)
    {
        backGround.gameObject.SetActive(toggle);
        board.gameObject.SetActive(toggle);
        for (int i = 0; i < 4; i++)
        {
            gridLines.transform.GetChild(i).gameObject.SetActive(toggle);
        }
    }
}
