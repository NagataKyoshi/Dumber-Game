using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject playersCamera;
    public float rotateX;
    private CinemachineVirtualCamera camera;
    public GameObject[] target;
    public int i;
    public bool rotateSpiker;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = playersCamera.gameObject.GetComponent<CinemachineVirtualCamera>();
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
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        playersCamera.SetActive(true);
        i = 0;
        RotateCam();        
    }
}
