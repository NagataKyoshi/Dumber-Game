using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class CameraRotate : MonoBehaviour
{
    public Animator beetleJuice,garyTheRetard,howard;
    public GameObject questionCanvas;
    public GameObject playersCamera;
    private CinemachineVirtualCamera camera;
    public GameObject[] target;
    public GameManager gameMng;
    public ColorBlock aBackup, bBackup;
    public GameObject[] text;
    public TextMeshProUGUI yourTurnText,yourTurnText2;
    public TextMeshProUGUI questionText;
    public bool isEnded;
    public CinemachineVirtualCamera garyCam, beetleCam, howardCam,startCam;


    public Slider slider;
 
    private Button buttonA, buttonB, buttonC;

    public GameObject answerA, answerB, answerC;
    public int i;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = playersCamera.gameObject.GetComponent<CinemachineVirtualCamera>();
        buttonA = answerA.GetComponent<Button>();
        buttonB = answerB.GetComponent<Button>();
        DOTweenTMPAnimator doTweenAnimator = new DOTweenTMPAnimator(yourTurnText);
        howard.SetBool("isTurn",true);

        aBackup = buttonA.colors;
        bBackup = buttonB.colors;
        
    }

    public void StartGameForCamera()
    {
        i = 2;

        StartCoroutine(StartCo());

    }

    // Update is called once per frame
    void Update()
    {
         if (slider.value > slider.maxValue - 0.2f)
         {
             Debug.Log("seo ");
             gameMng.playerState = GameManager.PlayerState.Finish;
             isEnded = true;
             beetleJuice.SetBool("isHappy",true);
             StartCoroutine(DelayEnd());
             
             
         }
        
    }

    public void RotateCam()
    {
        // if (i == 2)
        // {
        //     beetleCam.enabled = false;
        //         StartCoroutine(WaitForSeconds());
        // }else{     
        //     camera.LookAt = target[i].transform;
        // }

        switch (i)
        {
            case 0:
                garyCam.enabled = true;
                howardCam.enabled = false; 
                beetleCam.enabled = false;
                break;
            case 1:
                
                beetleCam.enabled = true;
                howardCam.enabled = false;
                garyCam.enabled = false;

                break;
            case 2:
                howardCam.enabled = true;
                beetleCam.enabled = false;
                garyCam.enabled = false;
                StartCoroutine(WaitForSeconds());

                break;
                
        }
        
        //camera.LookAt = target[i].transform;
        //transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles,new Vector3(0,180,0),0.5f);
        i++;

        if (i == 3)
        {
            i = 0;
        }
    }

    public void IfTrueAnswer()
    {
        
        StartCoroutine(Delay());
        StartCoroutine(DelaySlider());

    }
    
    
    IEnumerator StartCo()
    {

        //starcam

        startCam.enabled = false;
        RotateCam();

        yield return new WaitForSeconds(0f);
       
    }
    
    IEnumerator DelaySlider()
    {

        for (int j = 0; j < 50; j++)
        {

            slider.value += 0.02f;
            yield return new WaitForSeconds(0.01f);

        }
        
       
    }

    IEnumerator Delay()
    {
        if (!isEnded)
        {
            yield return new WaitForSeconds(2);// sevınme kısımı
            Debug.Log("gırdı");
            foreach (var part in gameMng.confetti)
            {
                part.Stop();
            }
            RotateCam();
        }
        else
        {
           
        }
        //yield return new WaitForSeconds(2);
        //slider.value = Mathf.Lerp(slider.value, slider.value + 1f, 0.5f);
        
    }
    
    
    IEnumerator DelayEnd()
    {
        //yield return new WaitForSeconds(2);
        //slider.value = Mathf.Lerp(slider.value, slider.value + 1f, 0.5f);
        yield return new WaitForSeconds(15);// sevınme kısımı

        foreach (var part in gameMng.confetti)
        {
            part.Stop();
        }
        //RotateCam();
    }
    
    IEnumerator WaitForSeconds()
    {
        //zquestionCanvas.SetActive(false);
        questionCanvas.transform.DOScale(0, 1);

        yourTurnText.DOScale(0, 1);
        yourTurnText2.DOScale(0, 1);
        answerA.transform.DOScale(0, 1);
        answerB.transform.DOScale(0, 1);
        answerC.transform.DOScale(0, 1);

        yield return new WaitForSeconds(1);         //spikerde kamera

        answerA.SetActive(false);
        answerB.SetActive(false);
        answerC.SetActive(false);
       // answerD.SetActive(false);

        buttonA.interactable = false;
        buttonB.interactable = false;
        answerC.GetComponent<Button>().interactable = false;
        //answerD.GetComponent<Button>().interactable = false;
        beetleJuice.SetBool("isTurn",false);
        gameMng.SetQuestion();

        yield return new WaitForSeconds(1);         //spikerde kamera

        questionCanvas.SetActive(true);
        questionCanvas.transform.DOScale(1, 1);

        questionText.DOText(gameMng.currentQeustion.question, 1, true,ScrambleMode.Lowercase);
        
        yield return new WaitForSeconds(2);         //spikerde kamera

        //howard.SetBool("isTurn",false);

        //questionCanvas.SetActive(true);
        playersCamera.SetActive(true);
        
        i = 0;
        RotateCam();  // Hareket olmuyor ama kamera kodunu guncelliyor yetissin diye
        garyTheRetard.SetBool("isTurn",true);

        
        yield return new WaitForSeconds(3);         //AIda
        
        answerA.SetActive(true);
        answerB.SetActive(true);
        answerC.SetActive(true);
        
        answerA.transform.DOScale(1, 2);
        answerB.transform.DOScale(1, 2);
        answerC.transform.DOScale(1, 2);

        
        //answerD.SetActive(true);


        yield return new WaitForSeconds(2.5f);         //AIda

        //transform.DOScale(yourTurnText.gameObject.transform.localScale, Vector3.one, 2f);
        int random = 0;//Random.Range(0,2);
        switch (random)
        {
            case 0:
                //answerA.GetComponent<Image>().material.Lerp();
                //buttonA.colors.normalColor = Color.red;

                 aBackup = buttonA.colors;
                
                ColorBlock cb = buttonA.colors;
                cb.disabledColor = Color.red;
                buttonA.colors = cb;
                
                foreach (var text in text)
                {
                    //text.GetComponent<TextMeshProUGUI>().text = answerA.GetComponentInChildren<Text>().text;
                }

                break;
            /*case 1:
               // answerB.GetComponent<Image>().material.color = Color.white;

                bBackup = buttonB.colors;
                ColorBlock cba = buttonB.colors;
                cba.disabledColor = Color.red;
                buttonB.colors = cba;
               
               foreach (var text in text)
               {
                   //text.GetComponent<TextMeshProUGUI>().text = answerB.GetComponentInChildren<Text>().text;
               }
               
                break;
            case 2:
                // answerB.GetComponent<Image>().material.color = Color.white;

                bBackup = buttonC.colors;
                ColorBlock ccc = buttonC.colors;
                ccc.disabledColor = Color.red;
                buttonC.colors = ccc;
               
                foreach (var text in text)
                {
                    //text.GetComponent<TextMeshProUGUI>().text = answerB.GetComponentInChildren<Text>().text;
                }
               
                break;*/
        }

        foreach (var text in text)
        {
            text.gameObject.SetActive(true);
        }
        

        
        yield return new WaitForSeconds(3); //AIda
        

        yourTurnText.DOScale(1, 1);
        yourTurnText2.DOScale(1, 1);

        
        garyTheRetard.SetBool("isTurn",false);
        
        beetleJuice.SetBool("isTurn",true);


        
        switch (random)
        {
            case 0:
                //answerA.GetComponent<Image>().material.Lerp();
                //buttonA.colors.normalColor = Color.red;

                buttonA.colors = aBackup;

                break;
            case 1:
                // answerB.GetComponent<Image>().material.color = Color.white;
                buttonB.colors = bBackup;

                break;
        }
        
        answerA.GetComponent<Button>().interactable = true;
        answerB.GetComponent<Button>().interactable = true;
        answerC.GetComponent<Button>().interactable = true;
        //answerD.GetComponent<Button>().interactable = true;
        howard.SetBool("isTurn",true);

        RotateCam();
        
        
              
    }
}
