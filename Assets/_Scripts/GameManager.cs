using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public AudioSource audio;
	public bool isGameover = false;
	public Text scoreText;
	public GameObject gameoverUI1;
    public GameObject gameoverUI2;

    private int score = 0;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			audio = GetComponent<AudioSource>();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Update()
	{	
		if (!isGameover && score > 15)
		{
			GameFinished();
		}
		if (isGameover)
		{
			audio.Stop();
			if (Input.GetMouseButtonDown(0))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
		}
	}

	public void GameFinished()
	{
		score = 0;
		isGameover = true;
		gameoverUI2.SetActive(true);
	}

	public void AddScore(int newScore)
	{
		if (!isGameover)
		{
			score += newScore;
			scoreText.text = "KILL :  " + score;
		}
	}

	public void OnPlayerDead()
	{
		isGameover = true;
		gameoverUI1.SetActive(true);
	}
}