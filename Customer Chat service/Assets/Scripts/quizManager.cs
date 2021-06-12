using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class quizManager : MonoBehaviour
{
    public List<QandA> QnA;
    public GameObject[] Options;
    public int currentQuestion;
    public Text questionText;

    public GameObject quizPanel;
    public GameObject GameOverPanel;
    public Text scoreText;

    int TotalQuestion = 0;
    public int score;


    private void Start()
    {
        TotalQuestion = QnA.Count;
        GameOverPanel.SetActive(false);
        genarateQuestion();
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion); 
        genarateQuestion();
    }

    public void wrong()
    {
        // when give wrong answer
        QnA.RemoveAt(currentQuestion);
        genarateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        quizPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        scoreText.text = score + "/" + TotalQuestion;
    }





    void SetAnswer()
    {
        for(int i = 0; i < Options.Length; i++)
        {
            Options[i].GetComponent<Answers>().isCorrect = false;
            Options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                Options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }
   public void genarateQuestion()
    {

        if(QnA.Count > 0)
        {
           
         //  currentQuestion =Random.Range(0, QnA.Count);

         // questionText.text = QnA[currentQuestion].questions;
            SetAnswer();
        }

        else
        {
            Debug.Log("Question is over");
            GameOver();
        }

          
 
        

    }
}
