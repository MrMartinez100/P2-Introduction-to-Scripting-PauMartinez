using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LifeManagment : MonoBehaviour
{
    public static LifeManagment instance;

    public GameObject[] heartsUI;
    public float disappearDelay = 2f;
    public string titleSceneName = "TitleScreen";

    private int lives;
    private bool gameEnding = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lives = heartsUI.Length;
    }

    public void LoseLife()
    {
        if (gameEnding) return;
        if (lives <= 0) return;

        lives--;

        GameObject heart = heartsUI[lives];

        Move moveScript = heart.GetComponent<Move>();
        if (moveScript == null)
        {
            moveScript = heart.AddComponent<Move>();
        }

        moveScript.movementSpeed = new Vector3(0, 5, 0);
        moveScript.space = Space.World;

        StartCoroutine(HideHeartAfterDelay(heart));

        if (lives <= 0)
        {
            StartCoroutine(GameOverAfterDelay(2f));
        }
    }

    private IEnumerator HideHeartAfterDelay(GameObject heart)
    {
        yield return new WaitForSeconds(disappearDelay);
        heart.SetActive(false);
    }

    private IEnumerator GameOverAfterDelay(float delay)
    {
        gameEnding = true;
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(titleSceneName);
    }
}