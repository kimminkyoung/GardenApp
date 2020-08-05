using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FakeServer : MonoBehaviour
{
    public Texture2D sendImage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NetworkWWW());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NetworkWWW()
    {
        string filename = "image.png";
        string url = "http://127.0.0.1:1024/" + filename;//php주소생성후 수정
        byte[] textureData = sendImage.EncodeToPNG();
        WWWForm form = new WWWForm();
        //form.AddField("field1", "내용");
        //form.AddBinaryData("field12", new byte[10]);
        UnityWebRequest wwwRequest = UnityWebRequest.Post(url, form);// 이미지 송신 가능한걸로 수정
        yield return wwwRequest.SendWebRequest();
        string result = wwwRequest.downloadHandler.text;
    }
}
