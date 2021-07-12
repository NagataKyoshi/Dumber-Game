using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Tabtale.TTPlugins;
using TMPro;


public class GameManager : MonoBehaviour
{
    public List<Question> questions;
    public Question currentQeustion;
    public ParticleSystem[] confetti;
    public CameraRotate cameraScript;

    [SerializeField]
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answerA;
    public TextMeshProUGUI answerB;
    public TextMeshProUGUI answerC;


    int randomQuestionID; //need for random question but we need to change primary.

    [SerializeField]
    private float timeBetweenQuestions = 20f;

    private void Start()
    {
        SetQuestion();
        isScoreCalculated = false;

    }
    public void SetQuestion()
    {
        randomQuestionID = Random.Range(0, questions.Count); //questions.Count - 1); random yapılmak istenirse
        currentQeustion = questions[randomQuestionID];

        questionText.text = currentQeustion.question;
        answerA.text = currentQeustion.answerA;
        answerB.text = currentQeustion.answerB;
        answerC.text = currentQeustion.answerC;
        //answerD.text = currentQeustion.answerD;
    }

    IEnumerator TransitionToNextQuestion()
    {
        
        yield return new WaitForSeconds(timeBetweenQuestions);

        SetQuestion();
    }

    public void SetAnswer(string correctAnswer)
    {
        questions.RemoveAt(randomQuestionID); /// soruyu siliyor
        if (correctAnswer != currentQeustion.trueAnswer)
        {
            cameraScript.IfTrueAnswer();
            Debug.Log("Congrats");
            //add particle system
            //add audio
            foreach (var particles in confetti)
            {

                particles.Play();
                
            }
            
            
        }
        else
        {
            cameraScript.RotateCam();
            Debug.Log("Wrong");
            //add particle system
            //add audio
        }
        //StartCoroutine(TransitionToNextQuestion());
    }
    
    private bool isScoreCalculated;


    public GameObject StartScreen;
    public GameObject FinishScreen;
    public GameObject GameOverScreen;


    public static GameManager inst;
    
    public enum PlayerState
    {
        Prepare,
        Playing,
        Died,
        Shopping,
        Finish
    }

    public PlayerState playerState;
    
    

    private void Awake()
    {
        TTPCore.Setup();
        

        playerState = PlayerState.Prepare;
        //Application.targetFrameRate = 60;
    }

    
    void Update()
    {
        if (playerState == PlayerState.Prepare)
        {
            StartScreen.SetActive(true);

        }

        if (playerState == PlayerState.Finish)
        {


            FinishScreen.SetActive(true);
            
        }

        if (playerState == PlayerState.Died)
        {
            GameOverScreen.SetActive(true);
        }
    }
    
    
 

   
    
    IEnumerator WaitAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
    }

   
    
    

}
