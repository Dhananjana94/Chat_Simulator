using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{

    public bool isCorrect = false;
    public quizManager QuizManager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct answer");
            QuizManager.correct();
        }

        else
        {
            Debug.Log("Wrong Answer");
            QuizManager.wrong();
        }
    }
}
