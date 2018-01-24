using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int score;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    private bool restart;


    void Start()
    {
       StartCoroutine(spawnWaves());
        score = 0;
        SetCountText();
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.buildIndex);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {

            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "R for Restart, Esc for Quit";
                    restart = true;
                break;
            }
        }

    }
    public void AddNewScore(int newScore)
    {
        score += newScore;
        SetCountText();
    }
    void SetCountText()
    {
        scoreText.text = "Score:" + score.ToString();
    }
    public void GameOver()
    {
        gameOverText.text = "GAME OVER!";
        gameOver = true;
    }

}
