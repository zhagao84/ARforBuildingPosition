using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
public class CloseGoup : MonoBehaviour
{
    public Interactable[] games;
    public void CloseIndex(int n)
    {
        for (int i=0;i<games.Length;i++)
        {
            if (n != i)
                games[i].IsToggled = false;
            else
                games[i].IsTargeted = true;
        }
    }
}
