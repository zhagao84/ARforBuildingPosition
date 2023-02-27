using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
public class SetUP : MonoBehaviour
{
    public PinchSlider pinchSlider;
    bool open;
    float lastvalue;
    public float multiple=0.001f;
    public Transform bt;
    public TextMeshPro text;
    public float movePrecision=0.02f;
    private void OnEnable()
    {
        text.text = transform.parent.childCount.ToString();
    }
    public void Run()
    {
        if (lastvalue < pinchSlider.SliderValue)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - pinchSlider.SliderValue *multiple, transform.position.z);
            lastvalue = pinchSlider.SliderValue;
        }

        else if (lastvalue>pinchSlider.SliderValue) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + pinchSlider.SliderValue * multiple, transform.position.z);
            lastvalue=pinchSlider.SliderValue;
        }
          
    }

    public void RunPoint(bool up)
    {
        if(up)
        transform.position += new Vector3(0, movePrecision, 0);
        else
        transform.position -= new Vector3(0, movePrecision, 0);
    }
}
