using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSystem : MonoBehaviour
{
	public static MainSystem instance { get; private set; }

	public int winScore;
	public float gameTimeSeconds = 10f;
	public Vector2 screenRadius;

	public Text scoreUI;
	public Text timerUI;
	public GameObject winText;
	public GameObject loseText;
	public AudioSource music;
	public AudioSource fuseSFX;
	public AudioSource winSFX;
	public AudioClip winSound;
	public AudioClip loseSound;

	private float timer;
	private int score;

	public static bool isPlaying { get; private set; } = false;
	public static bool gameEnded { get; private set; } = false;

	void Awake() {
		instance = this;
	}

	void Start()
	{
		isPlaying = false;
		gameEnded = false;

		score = 0;
		timer = gameTimeSeconds;
		scoreUI.text = "Score: " + score.ToString();
		timerUI.text = "Time: " + timer.ToString("F2");
		winText.SetActive(false);
		loseText.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		if (isPlaying)
		{
			if (timer > 0.0f)
			{
				timer -= Time.deltaTime;
			}
			else
			{
				timer = 0.0f;
				EndGame();
			}
			timerUI.text = "Time: " + timer.ToString("F2");
		}
		else if (gameEnded)
		{
			if (timer > 0.0f)
			{
				timer -= Time.deltaTime;
			}
			else
			{
				Application.Quit();
				Debug.Log("Game Ended");
			}

		}
	}

	public void StartGame()
	{
		isPlaying = true;
		music.Play();
		fuseSFX.Play();
	}

	public void ScorePoint()
	{
		score += 1;
		scoreUI.text = "Score: " + score.ToString();
		if (score >= winScore)
		{
			EndGame();
		}
	}

	public void EndGame()
	{
		isPlaying = false;
		gameEnded = true;
		if (score < winScore)
		{
			loseText.SetActive(true);
			winSFX.clip = loseSound;
		}
		else
		{
			winText.SetActive(true);
			winSFX.clip = winSound;
		}
		music.Stop();
		fuseSFX.Stop();
		winSFX.Play();

		timer = 5.0f;
	}
}
