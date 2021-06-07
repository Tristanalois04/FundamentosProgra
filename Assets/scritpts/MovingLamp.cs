using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLamp : MonoBehaviour
{

    public float rotationTreshold;
    public float speed;
    [SerializeField]
    Quaternion maxLeft;
    [SerializeField]
    Quaternion maxRight;
    Coroutine currentCoroutine;




    // Start is called before the first frame update
    void Start()
    {
        maxLeft.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationTreshold);
        maxRight.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationTreshold * -1);
        currentCoroutine = StartCoroutine(MoveLeft()); 
    }



    

    // Update is called once per frame
    void Update()
    {
        if(transform.localEulerAngles.z > maxLeft.eulerAngles.z)
        transform.rotation = Quaternion.RotateTowards(transform.rotation, maxLeft, Time.deltaTime * speed);




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

        while (transform.localEulerAngles.z > maxRight.eulerAngles.z -0.2f)
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, maxRight, Time.deltaTime * speed);
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(MoveLeft());
    }


}
