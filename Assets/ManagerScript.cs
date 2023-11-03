using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public int PlayerStore;
    public Text ScoreText;
    public GameObject GameOverScript;

    public void AddScore(int score)
     {
        PlayerStore+= score;
        ScoreText.text = PlayerStore.ToString();
    }

    public void RestartGame()
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerStore = 0;
    }

    public void GameOver()
    {
        GameOverScript.SetActive(true);
    }
}
