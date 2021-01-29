using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    private int direction; //1 = Right, 2 = Left
    [SerializeField]
    private CinemachineBrain cm;

    // Use this for initialization
    void Start()
    {
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PlatformMovement();
    }
    
    void PlatformMovement()
    {
        Vector3 currentPosition = transform.position;
        
        if (direction == 1)
        {
            currentPosition.x += speed * Time.deltaTime;
        }
        if (direction == 2)
        {
            currentPosition.x -= speed * Time.deltaTime;
        }
        
        transform.position = currentPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(direction == 1)
            {
                direction = 2;
            } else
            {
                direction = 1;
            }
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
            cm.m_UpdateMethod = CinemachineBrain.UpdateMethod.LateUpdate;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
            cm.m_UpdateMethod = CinemachineBrain.UpdateMethod.FixedUpdate;
        }
    }
}
