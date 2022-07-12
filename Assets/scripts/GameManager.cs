using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public Button restartButton;
    public GameObject titleScreen;
    private float spawnRate= 1.0f;
    private int score;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
          while(isGameActive)
          {
              yield return new WaitForSeconds(spawnRate);
              int index=Random.Range(0,targets.Count);
              Instantiate(targets[index]);
          }
    }
    public void UpdateScore(int addToScore)
    {
        score+=addToScore;
        scoreText.text="Score: " +score;
    }
    public void GameOver()
    {
      restartButton.gameObject.SetActive(true);  
      gameOver.gameObject.SetActive(true);
      isGameActive=false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        isGameActive=true;
        score=0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate/=difficulty;
    }
}
