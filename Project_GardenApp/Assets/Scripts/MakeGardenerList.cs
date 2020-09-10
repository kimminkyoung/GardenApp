using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeGardenerList : MonoBehaviour
{
    public GameObject gardenerPref;
    public GameObject parentObj;
    public void MakeGardener(List<string> nameList)
    {
        GameObject[] gardenerClone = new GameObject[nameList.Count];
        for (int i = 0; i < nameList.Count; i++)
        {
            gardenerClone[i] = Instantiate(gardenerPref, parentObj.transform);
            gardenerClone[i].GetComponentInChildren<Text>().text = nameList[i];
        }
    }
}
