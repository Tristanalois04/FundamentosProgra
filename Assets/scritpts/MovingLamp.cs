using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLamp : MonoBehaviour
{

    public float rotationTreshold;
    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float current = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation,new Quaternion (transform.rotation.x,transform.rotation.y, transform.rotation.z + rotationTreshold, transform.rotation.w),Time.deltaTime * speed);



    }
}
