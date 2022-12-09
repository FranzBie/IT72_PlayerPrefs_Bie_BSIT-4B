using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    int score;
    int highscore;

    public Text scoreText;
    public Text scoreText1;
    public Text highscoreText;
    public Text highscoreText1;
    public GameObject gameStartUI;
    public GameObject playButton;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void highscorefun()
    {

    }

    public void play()
    {

    }

    public void gameStart()
    {
        highscoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();

        gameStartUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
        scoreText1.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(true);
        highscoreText1.gameObject.SetActive(true);

        
    }

    public void restart()
    {
        SceneManager.LoadScene("Game");
    }



    public void scoreUp()
    {
        score++;

        scoreText.text = score.ToString();
 

        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
            highscoreText.text = score.ToString();
        }
    }


}
