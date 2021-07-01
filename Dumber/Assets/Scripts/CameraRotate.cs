using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

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
 
    private Button buttonA, buttonB, buttonC, buttonD;

    public GameObject answerA, answerB, answerC, answerD;
    public int i;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = playersCamera.gameObject.GetComponent<CinemachineVirtualCamera>();
        buttonA = answerA.GetComponent<Button>();
        buttonB = answerB.GetComponent<Button>();

        aBackup = buttonA.colors;
        bBackup = buttonB.colors;
        
    }

    public void StartGameForCamera()
    {
        i = 2;
        howard.SetBool("isTurn",true);

        RotateCam();
    }

    // Update is called once per frame
    void Update()
    {
        
        //  rotateX += 0.1f;
        // transform.eulerAngles = new Vector3(0,rotateX,0);
    }

    public void RotateCam()
    {
        if (i == 2)
        {
                playersCamera.SetActive(false);
                StartCoroutine(WaitForSeconds());
        }else{     
            camera.LookAt = target[i].transform;
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

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(4);
        foreach (var part in gameMng.confetti)
        {
            part.Stop();
        }
        RotateCam();
    }
    
    
    IEnumerator WaitForSeconds()
    {
        answerA.SetActive(false);
        answerB.SetActive(false);
        answerC.SetActive(false);
        answerD.SetActive(false);

        buttonA.interactable = false;
        buttonB.interactable = false;
        answerC.GetComponent<Button>().interactable = false;
        answerD.GetComponent<Button>().interactable = false;
        beetleJuice.SetBool("isTurn",false);

        
        questionCanvas.SetActive(false);
        
        yield return new WaitForSeconds(3);         //spikerde kamera

        howard.SetBool("isTurn",false);

        questionCanvas.SetActive(true);
        playersCamera.SetActive(true);
        
        i = 0;
        RotateCam();  // Hareket olmuyor ama kamera kodunu guncelliyor yetissin diye
        garyTheRetard.SetBool("isTurn",true);

        
        yield return new WaitForSeconds(3);         //AIda
        answerA.SetActive(true);
        answerB.SetActive(true);
        answerC.SetActive(true);
        answerD.SetActive(true);


        yield return new WaitForSeconds(1);         //AIda
        
        
        
        int random = Random.Range(0,2);
        switch (random)
        {
            case 0:
                //answerA.GetComponent<Image>().material.Lerp();
                //buttonA.colors.normalColor = Color.red;

                 aBackup = buttonA.colors;
                
                ColorBlock cb = buttonA.colors;
                cb.disabledColor = Color.red;
                buttonA.colors = cb;

                break;
            case 1:
               // answerB.GetComponent<Image>().material.color = Color.white;

                bBackup = buttonB.colors;
                ColorBlock cba = buttonA.colors;
                cba.disabledColor = Color.red;
                buttonA.colors = cba;
               
                break;
        }

        foreach (var text in text)
        {
            text.gameObject.SetActive(true);
        }
        
        yield return new WaitForSeconds(3); //AIda
        
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
        answerD.GetComponent<Button>().interactable = true;
        howard.SetBool("isTurn",true);

        RotateCam();
        
        
              
    }
}
