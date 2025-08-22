//Manages players lives and no. of mirrors collected
//Updates the UI to reflect these values
// Loads the Game Over scene when lives reach 0
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Tracks how many mirrors the player has collected
    public int mirrorCount = 0;
    //Tracks how many lives the player has
    public int lives = 2;
    //UI elements to display the number of mirrors and lives
    public TextMeshProUGUI mirrorText;
    //UI element to display the number of lives
    public TextMeshProUGUI livesText;

    void Start()
    {
        //Calls the UpdateLives method to display the starting number of lives
        UpdateLives();
    }
    public void LoseLife()
    {
        //Decreases the number of lives by 1 and updates the UI
        lives--;
        UpdateLives();
// If lives reach 0, load the Game Over scene
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    //Updates the lives UI text to reflect the current number of lives
    void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }
    //Increases the mirror count by 1
    //Updates the mirror count UI texth
    public void AddMirror()
    {
        mirrorCount++;
        mirrorText.text = "Mirrors: " + mirrorCount;
    }
}