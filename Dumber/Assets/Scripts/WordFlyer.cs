using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordFlyer : MonoBehaviour
{
    
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            m_Rigidbody.AddForce(transform.up * m_Thrust);

        }
    }
}
