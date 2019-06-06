using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOverText;
    public bool gameOver;
    public float scrollSpeed = -1.5f;

    private int score;
    public Text ScoreText;

    private void Awake()
    {
        if (GameController.instance == null)
        {
            GameController.instance = this;
        }
        else if (GameController.instance = this)
        {
            Destroy(gameObject);
            Debug.LogWarning("GameController ha sido instanciado por segunda vez. Esto no deberia pasar. ");
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DogScored()
    {
        if (!gameOver)
        {
            score++;
            ScoreText.text = "score= " + score++;
           
            if (score == 25)
            {
                SceneManager.LoadScene("nivel2", LoadSceneMode.Single);
            }
          
        }
    }

    public void OnTriggerEnter(Collider titulo)
    {
        Destroy(titulo.gameObject);
        score = score + 5;
    }


    // Update is called once per frame

    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }  
    }

    public void DogDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void OnDestroy()
    {
        if (GameController.instance == this)
        {
            GameController.instance = null;

        }
    }
}
