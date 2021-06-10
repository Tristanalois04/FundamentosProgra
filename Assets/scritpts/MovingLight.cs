﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MovingLight : MonoBehaviour
{
    
    public float rotationTreshold;
    public float speed;
    [SerializeField]
    Quaternion maxLeft;
    [SerializeField]
    Quaternion maxRight;
    Coroutine currentCoroutine;
    private Light2D colorluz;

    // Start is called before the first frame update
    void Start()
    {
        colorluz = gameObject.GetComponent<Light2D>();


        maxLeft.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationTreshold);
        maxRight.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationTreshold* -1);
        currentCoroutine = StartCoroutine(MoveLeft());

    }


    // Update is called once per frame
    void Update()
    {
     

        colorluz.color = Color.Lerp(colorluz.color, Color.red, Mathf.PingPong(Time.time,20f));

    }

    IEnumerator MoveLeft()
    {
        while(transform.localEulerAngles.z > maxLeft.eulerAngles.z + 0.2f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, maxLeft, Time.deltaTime * speed);
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(MoveRight());
    }
    IEnumerator MoveRight()
    {
        while (transform.localEulerAngles.z < maxRight.eulerAngles.z - 0.2f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, maxRight, Time.deltaTime * speed);
            yield return null;

        }

        yield return new WaitForSeconds(0.2f);
        StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(MoveLeft());
    }

    

}
