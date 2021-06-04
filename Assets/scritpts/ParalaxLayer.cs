using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParalaxLayer : MonoBehaviour
{
    public float parallaxFactorX;
    public float parallaxFactorY;

    public void Movex(float deltaX)
    {
        Vector3 newPosition = transform.position;
        newPosition.x -= deltaX * parallaxFactorX;
        transform.position = newPosition;
    }

    public void Movey(float deltaY)
    {
        Vector3 newPosition = transform.position;
        newPosition.y -= deltaY * parallaxFactorY;
        transform.position = newPosition;
    }
}
