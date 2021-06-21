using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Question> questions;
    public Question currentQeustion;

    [SerializeField]
    public Text questionText;
    public Text answerA;
    public Text answerB;

    int randomQuestionID; //need for random question but we need to change primary.

    [SerializeField]
    private float timeBetweenQuestions = 4f;

    private void Start()
    {
        SetQuestion();
    }
    public void SetQuestion()
    {
        randomQuestionID = Random.Range(0, 1); //questions.Count - 1); random yapılmak istenirse
        currentQeustion = questions[randomQuestionID];

        questionText.text = currentQeustion.question;
        answerA.text = currentQeustion.answerA;
        answerB.text = currentQeustion.answerB;

    }

    //sorular arası bekleme yapmayı denedim ancak yemedi bir bakılır buraya
    //IEnumerator TransitionToNextQuestion()
    //{
    //    SetQuestion();
    //    yield return new WaitForSeconds(timeBetweenQuestions);
    //    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    public void SetAnswer(string correctAnswer)
    {
        questions.RemoveAt(randomQuestionID);
        if (correctAnswer == currentQeustion.trueAnswer)
        {
            Debug.Log("Congrats");
            //add particle system
            //add audio
            SetQuestion();
        }
        else
        {
            Debug.Log("Wrong");
            //add particle system
            //add audio
            SetQuestion();
        }
        //StartCoroutine(TransitionToNextQuestion());

    }
}
