using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private int maxRounds;
    [SerializeField] private Transform leftBallSpawner;
    [SerializeField] private Transform rightBallSpawner;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject leftPaddle;
    [SerializeField] private GameObject rightPaddle;
    [SerializeField] private TextMeshProUGUI p1ScoreDisplay;
    [SerializeField] private TextMeshProUGUI p2ScoreDisplay;
    [SerializeField] private GameObject centralLine;
    [SerializeField] private GameObject gameOverMessage;
    [SerializeField] private GameObject playAgainButton;
    [SerializeField] private GameObject startButton;
    private int roundsToWin;
    private int p1Score;
    private int p2Score;

    void Start()
    {
        Application.targetFrameRate = 150;
        roundsToWin = maxRounds/2 + 1;
    }

    public void P1Scores()
    {
        p1Score++;
        UpdateScoresDisplay();

        if (p1Score == roundsToWin)
        {
            GameOver("1");
        }
        else
        {
            ResetPaddlesPositions();
            SpawnBallOnLeft();
        }
    }
    public void P2Scores()
    {
        p2Score++;
        UpdateScoresDisplay();

        if (p2Score == roundsToWin)
        {
            GameOver("2");
        }
        else
        {
            ResetPaddlesPositions();
            SpawnBallOnRight();
        }
    }

    private void ResetPaddlesPositions()
    {
        leftPaddle.transform.position = new Vector3(leftPaddle.transform.position.x, 0, 0);
        leftPaddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        rightPaddle.transform.position = new Vector3(rightPaddle.transform.position.x, 0, 0);
        rightPaddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void UpdateScoresDisplay()
    {
        p1ScoreDisplay.text = p1Score.ToString();
        p2ScoreDisplay.text = p2Score.ToString();
    }

    private void SpawnBallOnLeft()
    {
        ball.transform.position = leftBallSpawner.position;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    private void SpawnBallOnRight()
    {
        ball.transform.position = rightBallSpawner.position;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void GameOver(string winner)
    {
        gameOverMessage.GetComponent<TextMeshProUGUI>().text = "Player " + winner + " wins!!!";
        gameOverMessage.SetActive(true);
        playAgainButton.SetActive(true);
        DisableGameObjectsForGameOver();
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        SpawnBallOnLeft();
        EnableGameObjectsForStart();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void EnableGameObjectsForStart()
    {
        centralLine.SetActive(true);
        leftPaddle.SetActive(true);
        rightPaddle.SetActive(true);
        ball.SetActive(true);
        leftPaddle.GetComponent<PaddleScript>().EnableJumping();
        rightPaddle.GetComponent<PaddleScript>().EnableJumping();
    }
    private void DisableGameObjectsForGameOver()
    {
        ball.SetActive(false);
        centralLine.SetActive(false);
        leftPaddle.GetComponent<PaddleScript>().DisableJumping();
        rightPaddle.GetComponent<PaddleScript>().DisableJumping();
    }
}
