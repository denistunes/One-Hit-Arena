using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [Header("HUD")]
    public Text timerText;
    float startTime;
    public GameObject deadUI;

    [Header("Parameters")]
    bool gameEnded = false;
    public bool timerActive = true;
    //bool LevelFinished = false;

    [Header("Components")]
    public EnemySpawn EnemySpawn;
    public CameraFollow cameraFollow;

    void Start() {
        startTime = 0;
        timerText.text = startTime.ToString("F2");
    }

    void Update() {
        Timer();
    }

    void Timer()
    {
        if (timerActive)
        {
            startTime += Time.deltaTime;
            timerText.text = startTime.ToString("F2");
        }
    }

    public void RestartGame()
    {
        FindObjectOfType<AudioManager>().Play("UI_Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        if (gameEnded == false)
        {
            timerActive = false;
            gameEnded = true;

            cameraFollow.enabled = false;
            EnemySpawn.isSpawning = false;

            deadUI.SetActive(true);
        }
    }
}
