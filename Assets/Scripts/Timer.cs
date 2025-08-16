//why da heck is all this so hard gawd dayum it keeps breaking 
using UnityEngine;
using UnityEngine.SceneManagement;   // Scene loading (CwC Unit 5 – Game Over)
using TMPro;                         // TextMeshPro UI (CwC Unit 5 – Keeping Score)

/// LevelTimer
/// Counts down from a scene-specific time limit, updates a TMP text as MM:SS,
/// warns once at low time (optional beep + flash idk yet ill decide), and loads a Game Over scene at 0.
/// This stitches together patterns taught in Create with Code: deltaTime timing (Unit1), UI text updates(Unit 5.2), coroutines/WaitForSeconds(Unit 4.3), and SceneManager scene loads(Unit 5.3).
public class LevelTimer : MonoBehaviour
{
    //serialised fields so i can inspect and change them in Unity
    [Header("Timer Settings")]
    // total seconds for this level(Unit 6)
    [SerializeField] float timeLimit = 30f;      
     // when to start low-time warning
    [SerializeField] float warningThreshold = 10f;

    [Header("UI")]
     // dragged a TMP Text object from the Canvas to attach the two and display the object
    [SerializeField] TextMeshProUGUI timerText; 

    [Header("Scene Names")]
    // Name of the scene to load when time runs out.
    [SerializeField] string gameOverScene = "GameOver"; 

    float timeLeft;   // How much time remains (counts down).
    bool warned;      // ensures we only warn once

    void Start()
    {
        // Initialize time lft to the starting value
        // Updates the timer UI immediately.
        timeLeft = Mathf.Max(0, timeLimit);
        UpdateTimerUI();
    }

    void Update()
    {
        // countdown using Time.deltaTime
        // (CwC uses deltaTime everywhere for time-based motion/timing!!)
        timeLeft -= Time.deltaTime;

      //If the timer drops below the warning threshold (and hasn’t warned yet), starts the flashing coroutine.
        if (!warned && timeLeft <= warningThreshold && timeLeft > 0f)
        {
            warned = true;

            // Start a coroutine to flash the timer text while time is low.
            StartCoroutine(FlashTimer());
        }

        // If time ran out, clamp to 0, update the UI one last time, then load Game Over.
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            UpdateTimerUI();

            // Load the designated Game Over scene (same API used in CwC restart examples).
            SceneManager.LoadScene(gameOverScene);
            return; // stop running the rest of Update this frame
        }

        // Normal per-frame UI refresh.
        UpdateTimerUI();
    }

    // Reformat seconds as MM:SS and write to the TextMeshPro label.
    void UpdateTimerUI()
    {
        int seconds = Mathf.CeilToInt(timeLeft); // ceil so 5.1s shows as 00:06
        int mins = seconds / 60;
        int secs = seconds % 60;

        if (timerText)
            timerText.text = $"{mins:00}:{secs:00}";
    }

    // I used the Unit 4.3 coroutine + WaitForSeconds pattern to run a loop,
    //  and the Unit 4.3 on/off indicator idea to toggle my UI.
    //  The label itself is a TMP text from Unit 5.2. I’m just applying those 
    // to make the timer flash as the brief suggests for a low-time warning.
    // Uses WaitForSeconds just like CwC’s countdown/powerup routines.
    System.Collections.IEnumerator FlashTimer()
    {
        while (timeLeft > 0f)
        {
            if (timerText) timerText.enabled = !timerText.enabled;
            yield return new WaitForSeconds(0.25f);
        }
        // Ensure the label is visible again when the loop ends.
        if (timerText) timerText.enabled = true;
    }
}


