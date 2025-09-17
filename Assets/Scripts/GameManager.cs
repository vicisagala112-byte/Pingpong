using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Mode Game")]
    [SerializeField] private bool singlePlayer = true;

    [Header("UI Panels")]
    [SerializeField] private GameObject playerWinPanel;
    [SerializeField] private GameObject playerLosePanel;

    [Header("Score Settings")]
    [SerializeField] private int maxScore = 5;

    private int UserLeftScore = 0;
    private int UserRightScore = 0;

    [Header("UI Score Text")]
    [SerializeField] private Text UserLeftScoreText;
    [SerializeField] private Text UserRightScoreText;

    void Start()
    {
        UserLeftScoreText.text = "0";
        UserRightScoreText.text = "0";

        if (playerWinPanel) playerWinPanel.SetActive(false);
        if (playerLosePanel) playerLosePanel.SetActive(false);
    }

    public void UserLeftScored()
    {
        if (UserLeftScore >= maxScore || UserRightScore >= maxScore) return;

        UserLeftScore++;
        UserLeftScoreText.text = UserLeftScore.ToString();
        Debug.Log("Player 1 score: " + UserLeftScore);

        CheckWinCondition();
    }

    public void UserRightScored()
    {
        if (UserLeftScore >= maxScore || UserRightScore >= maxScore) return;

        UserRightScore++;
        UserRightScoreText.text = UserRightScore.ToString();
        Debug.Log("Player 2 score: " + UserRightScore);

        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (singlePlayer)
        {
            if (UserLeftScore >= maxScore)
            {
                if (playerWinPanel) playerWinPanel.SetActive(true);
                Debug.Log("Player 1 WIN!");
                Time.timeScale = 0;
            }
            else if (UserRightScore >= maxScore)
            {
                if (playerLosePanel) playerLosePanel.SetActive(true);
                Debug.Log("BOT WIN! Player Lose!");
                Time.timeScale = 0;
            }
        }
        else
        {
            if (UserLeftScore >= maxScore)
            {
                if (playerWinPanel) playerWinPanel.SetActive(true);
                Debug.Log("Player 1 WIN!");
                Time.timeScale = 0;
            }
            else if (UserRightScore >= maxScore)
            {
                if (playerLosePanel) playerLosePanel.SetActive(true);
                Debug.Log("Player 2 WIN!");
                Time.timeScale = 0;
            }
        }
    }

    public void pindahScene(string tujuan)
    {
        Debug.Log("Button diklik! Mau pindah ke scene: " + tujuan);

        Time.timeScale = 1;
        SceneManager.LoadScene(tujuan);
    }

}
