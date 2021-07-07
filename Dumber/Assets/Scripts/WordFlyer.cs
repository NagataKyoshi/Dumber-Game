using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFlyer : MonoBehaviour
{
    
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;
    private Vector3 startPos;
    public bool once;
    public bool canFly;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        startPos = transform.position;


    }
    
    IEnumerator StartCo()
    {

        //starcam
            

        yield return new WaitForSeconds(5f);
        
        canFly = true;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && !canFly)
        {
            m_Rigidbody.AddForce(transform.up * m_Thrust);
            
            if (!once)
            {
                StartCoroutine(StartCo());
                once = true;
            }

        }

        if (gameObject.activeSelf && canFly)
        {
            gameObject.SetActive(false);
            transform.position = startPos;
            canFly = false;
            once = false;
            m_Rigidbody.velocity = Vector3.zero;
            
        }
    }
    
    
}
