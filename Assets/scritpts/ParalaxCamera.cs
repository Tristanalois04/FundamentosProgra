using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float delamovement);

    public ParallaxCameraDelegate onCameraTranslateX;
    public ParallaxCameraDelegate onCameraTranslateY;
    
    private float oldpositionX;
    private float oldpositionY;


    private void Start()
    {
        oldpositionX = transform.position.x;
        oldpositionY = transform.position.y;
    }

    private void LateUpdate()
    {
        if(transform.position.x != oldpositionX)
        { 
          if(onCameraTranslateX != null)
          {
                float deltaX = oldpositionX - transform.position.x;
                onCameraTranslateX(deltaX);
          }
            oldpositionX = transform.position.x;
        }

        if (transform.position.y != oldpositionY)
        {
            if (onCameraTranslateY != null)
            {
                float deltaY = oldpositionY - transform.position.y;
                onCameraTranslateX(deltaY);
            }
            oldpositionY = transform.position.y;
        }
    }


}
