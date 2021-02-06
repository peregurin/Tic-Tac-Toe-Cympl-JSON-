using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO;

public class GameController : MonoBehaviour
{
    public TMP_Text[] buttonList;
    private string playerSide;
    private int moveCount;

    private int playerXScore = 0;
    private int[] playerXHighScores;
    private int NumberOfHighScores;
    HighScoreClass highScoreClass;

    private class HighScoreClass
    {
        public int highScore1;
        public int highScore2;
        public int highScore3;
        public int highScore4;
        public int highScore5;
    }

    private void Awake()
    {
        highScoreClass = new HighScoreClass();

        NumberOfHighScores = 5;
        playerXHighScores = new int[NumberOfHighScores];
        for (int i = 0; i < playerXHighScores.Length; i++)
        {
            playerXHighScores[i] = 0;
        }
        GetSavedHighScoreData();
        playerSide = "X";
        moveCount = 0;
        SetGameControllerRefOnButtons();
    }

    private void GetSavedHighScoreData()
    {
        string json = File.ReadAllText(Application.dataPath + "saveFile.json");
        highScoreClass = JsonUtility.FromJson<HighScoreClass>(json);
        playerXHighScores[4] = highScoreClass.highScore1;
        playerXHighScores[3] = highScoreClass.highScore2;
        playerXHighScores[2] = highScoreClass.highScore3;
        playerXHighScores[1] = highScoreClass.highScore4;
        playerXHighScores[0] = highScoreClass.highScore5;
    }

    private void Start()
    {
        UpdateHighScoreClass();
    }

    private void UpdateHighScoreClass()
    {
        highScoreClass.highScore1 = playerXHighScores[4];
        highScoreClass.highScore2 = playerXHighScores[3];
        highScoreClass.highScore3 = playerXHighScores[2];
        highScoreClass.highScore4 = playerXHighScores[1];
        highScoreClass.highScore5 = playerXHighScores[0];
    }

    void SetGameControllerRefOnButtons()
    {
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<EmptyCell>().SetGameControllerRef(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;
        if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        else if (moveCount >= 9)
        {
            GameOver();
        }
        else
        {
            ChangeSides();
        }
    }

    private void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X"; 
    }

    private void GameOver()
    {
        SetBoardInteractable(false);
        if(moveCount >= 9)
        {
            Debug.Log("DRAW");
        }
        else
        {
            Debug.Log("Game Won by: " + playerSide);
            if(playerSide == "X")
            {
                playerXScore++;
            }
            else
            {
                UpdateLeaderBoard();
                playerXScore = 0;
            }
        }

        RestartGame();
    }

    private void UpdateLeaderBoard()
    {
        for(int i = playerXHighScores.Length-1; i>=0; i--)
        {
            if(playerXScore >= playerXHighScores[i])
            {
                //playerXHighScores[i] = playerXScore;
                for(int j = i; j >= 0; j--)
                {
                    int temp = playerXHighScores[j];
                    playerXHighScores[j] = playerXScore;
                    playerXScore = temp;
                }
                break;
            }
        }
        ShowLeaderBoard();
    }

    private void ShowLeaderBoard()
    {
        for (int i = playerXHighScores.Length - 1; i >= 0; i--)
        {
            Debug.Log(playerXHighScores[i]);
        }
        UpdateHighScoreClass();
        UpdateSaveFile();
    }

    private void UpdateSaveFile()
    {
        string json = JsonUtility.ToJson(highScoreClass);
        File.WriteAllText(Application.dataPath + "saveFile.json", json);
    }

    private void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        SetBoardInteractable(true);
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
 
}
