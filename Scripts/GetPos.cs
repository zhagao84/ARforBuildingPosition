using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetPos : MonoBehaviour
{
    public TextMeshPro meshPro;
    public Transform tar;
    private void Update()
    {
        meshPro.text="Y"+ "["+tar.transform.localPosition.y.ToString("f4")+"]";
    }
}
