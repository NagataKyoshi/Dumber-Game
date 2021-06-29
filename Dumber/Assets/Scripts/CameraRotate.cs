using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotate : MonoBehaviour
{
    public GameObject questionCanvas;
    public GameObject playersCamera;
    private CinemachineVirtualCamera camera;
    public GameObject[] target;

    public GameObject answerA, answerB;
    public int i;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = playersCamera.gameObject.GetComponent<CinemachineVirtualCamera>();
        i = 2;

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
    
    IEnumerator WaitForSeconds()
    {
        answerA.SetActive(false);
        answerB.SetActive(false);
        questionCanvas.SetActive(false);
        
        yield return new WaitForSeconds(3);         //spikerde kamera


        questionCanvas.SetActive(true);
        playersCamera.SetActive(true);
        
        i = 0;
        RotateCam();  // Hareket olmuyor ama kamera kodunu guncelliyor yetissin diye
        
        
        yield return new WaitForSeconds(3);         //AIda
        answerA.SetActive(true);
        answerB.SetActive(true);
        yield return new WaitForSeconds(1);         //AIda
        int random = Random.Range(0,2);
        switch (random)
        {
            case 0:
                //answerA.GetComponent<Image>().material.Lerp();
                break;
            case 1:
               // answerB.GetComponent<Image>().material.color = Color.white;
                break;
        }
        
        yield return new WaitForSeconds(3);         //AIda

        RotateCam();
        
              
    }
}
