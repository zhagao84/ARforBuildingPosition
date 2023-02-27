using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;
public class SetMark : MonoBehaviour
{
  //  public InputField field;
  //  public GameObject toggle;
    [HideInInspector]
    public string id;//Ãû³Æ
    int idc;
    [HideInInspector]
    [Range(0,1)]
    public int state;//Ìî»òÕßÍÚ
    public TextMeshProUGUI hint;
    [HideInInspector]
    public TextMeshPro TextMeshPro;
    public PinchSlider pinchSlider;
    public List<Transform> txts=new List<Transform>();
    public GameObject openTxt;
    public Interactable[] nogo;
    int nogoin;
    Csv csv;
    SetUP[] setUPs;
    public Transform[] tars;
    private void Awake()
    {
        csv = GameObject.FindObjectOfType<Csv>();
        setUPs =new SetUP[transform.parent.childCount - 2];
        for (int i=0;i<setUPs.Length;i++)
        {
            setUPs[i] = transform.parent.GetChild(i).GetComponent<SetUP>();
            setUPs[i].bt.transform.parent = tars[i];
            setUPs[i].bt.transform.localPosition = Vector3.zero;
            setUPs[i].bt.transform.localRotation = Quaternion.identity;
        }
    }
    public void Set()
    {
         
            id = GameObject.FindObjectsOfType<CancellatedStructure>().Length.ToString();
     //   idc = GameObject.FindObjectsOfType<CancellatedStructure>();
            hint.text = id;
            if (nogo[0].IsToggled)
            {
                state = 1;
                TextMeshPro.text = "[" + "ID:" + id + "]" + "[" + "digging" + "]";
            }
           else if (nogo[1].IsToggled)
           {
                TextMeshPro.text = "[" + "ID:" + id + "]" + "[" + "dumping" + "]";
                state = 0;
           }
          else if (nogo[2].IsToggled)
          {
                 TextMeshPro.text = "[" + "ID:" + id + "]" + "[" + "nogo" + "]";
                 state = 2;
          }



        for (int i=0;i<txts.Count;i++)
        {
            float x = txts[i].gameObject.transform.localPosition.x;
            float y = txts[i].gameObject.transform.localPosition.y;
            float z = txts[i].gameObject.transform.localPosition.z;
            csv.Save(x, y, z, int.Parse(id), state);
        }
       
    }

    private void Update()
    {
       
        for (int i=0;i< txts.Count;i++)
        {
            txts[i].GetChild(1).gameObject.SetActive(openTxt.activeSelf);
            txts[i].GetChild(1).GetComponent<TextMeshPro>().transform.localScale =new Vector3(Mathf.Clamp(pinchSlider.SliderValue, 0.005f, pinchSlider.SliderValue*0.02f), Mathf.Clamp(pinchSlider.SliderValue, 0.005f, pinchSlider.SliderValue* 0.02f), Mathf.Clamp(pinchSlider.SliderValue, 0.005f, pinchSlider.SliderValue * 0.02f))  ;
        }
    }

}
