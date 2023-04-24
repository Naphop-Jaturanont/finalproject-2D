using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GoalType { Goal1, Goal2 }

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Football;
    [SerializeField] private TMP_Text scoreGoal1;
    [SerializeField] private TMP_Text scoreGoal2;
    [SerializeField] private GameObject gameOverObject;
    public GoalType goalType;
    public GameObject player1;
    public GameObject player2;
    public Transform respawnPointPlayer1;
    public Transform respawnPointPlayer2;
    public Transform respawnPoint; // Assign the respawn location in the inspector
    private int goalscore1 = 5;
    private int goalscore2 = 5;

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        if (goalscore1 == 0 || goalscore2 == 0)
        {
            Gameover();
            StartCoroutine(DisableFootball());
            Football.GetComponent<Collider2D>().isTrigger = true;
        }

    }

    private IEnumerator DisableFootball()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        Football.gameObject.SetActive(false); // Disable the football game object
    }


    public int Goalscore1
    {
        get { return goalscore1; }
        set { goalscore1 = value; }
    }

    public int Goalscore2
    {
        get { return goalscore2; }
        set { goalscore2 = value; }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            if (goalType == GoalType.Goal1)
            {
                Debug.Log("Goal1!!!");
                Goal1score();
                UpdateScoreText();

            }
            else if (goalType == GoalType.Goal2)
            {
                Debug.Log("Goal2!!!");
                Goal2score();
                UpdateScoreText();
            }

            other.gameObject.SetActive(false); // Disable the ball game object
            other.gameObject.transform.position = respawnPoint.position; // Move the ball to the respawn location
            other.gameObject.SetActive(true); // Enable the ball game object
            player1.gameObject.transform.position = respawnPointPlayer1.position; // Move player 1 to its respawn location
            player2.gameObject.transform.position = respawnPointPlayer2.position; // Move player 2 to its respawn location
        }
    }

    void Goal1score()
    {
        Goalscore1 -= 1;
    }

    void Goal2score()
    {
        Goalscore2 -= 1;
    }

    private void UpdateScoreText()
    {
        scoreGoal1.text = "Score: " + goalscore1;
        scoreGoal2.text = "Score: " + goalscore2; // update with new score
    }

    private void Gameover()
    {
        gameOverObject.SetActive(true); // show the game over object
    }
}
