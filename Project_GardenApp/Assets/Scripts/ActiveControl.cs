using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveControl : MonoBehaviour
{
    public GameObject[] activeOBJ;
    public GameObject[] deactiveOBJ;

    public void Activate()
    {
        for (int i = 0; i < activeOBJ.Length; i++)
        {
            activeOBJ[i].SetActive(true);
        }
    }

    public void Disactivate()
    {
        for (int i = 0; i < deactiveOBJ.Length; i++)
        {
            deactiveOBJ[i].SetActive(false);
        }
    }
}
