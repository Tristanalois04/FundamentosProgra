using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ChangeColor: MonoBehaviour
{
    // Interpolate light color between two colors back and forth
    float duration = 10.0f;
    Color color0 = Color.red;
    Color color1 = Color.blue;
    Light2D lt;

    void Start()
    {
        lt = gameObject.GetComponent<Light2D>();
    }

    void Update()
    {
        // set light color
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }





}