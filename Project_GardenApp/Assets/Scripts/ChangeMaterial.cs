using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ChangeMaterial : MonoBehaviour
{
    public GameObject[] plants;

    public void Change(string name, string url)
    {
        Texture2D changeTex = new Texture2D(250, 250);
        string path = Path.Combine(url, name + ".png");
        if (File.Exists(path))
        {
            byte[] imageData = File.ReadAllBytes(path);
            changeTex.LoadImage(imageData);
        }

        for (int i = 0; i < plants.Length; i++)
        {
            if(plants[i].tag == name)
            {
                plants[i].GetComponent<MeshRenderer>().material.mainTexture = changeTex;
                print("change [" + name + "]'s texture!");
            }
        }
    }
}
