using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
      public int mirrorCount = 0;
    public int lives = 2;

    public TextMeshProUGUI mirrorText;
    public TextMeshProUGUI livesText;

    void Start()
    {
        UpdateLives();
    }
    public void LoseLife()
{
    lives--;
    UpdateLives();

    if (lives <= 0)
    {
        SceneManager.LoadScene("GameOver");  
    }
}

    void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }
    public void AddMirror()
    {
        mirrorCount++;
        mirrorText.text = "Mirrors: " + mirrorCount;
    }
}
