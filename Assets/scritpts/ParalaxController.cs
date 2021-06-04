using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    [SerializeField]
    List<ParalaxLayer> parallaxLayerslist =  new List <ParalaxLayer>();
    public ParalaxCamera parallaxCamera;



    // Start is called before the first frame update
    void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParalaxCamera>();

        if (parallaxCamera != null)
        {
            parallaxCamera.onCameraTranslateX += MoveX;
            parallaxCamera.onCameraTranslateY += Movey;
        }

        GetLayers();
    }

    private void MoveX(float delta)
    {
        foreach (ParalaxLayer layer in parallaxLayerslist)
        {
            if(layer !=null)
            {
                layer.Movex(delta);
            }
        }
    }

    private void Movey(float delta)
    {
        foreach (ParalaxLayer layer in parallaxLayerslist)
        {
            if (layer != null)
            {
                layer.Movey(delta);
            }
        }
    }

    private void GetLayers()
    {
        parallaxLayerslist.Clear();
        for(int i =0; i<transform.childCount; i++)
        {
            ParalaxLayer layer = transform.GetChild(i).GetComponent<ParalaxLayer>();
            if (layer != null)
                parallaxLayerslist.Add(layer);  
        }
    }






}
