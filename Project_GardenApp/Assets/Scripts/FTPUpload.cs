using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;

public class FTPUpload : MonoBehaviour
{
    public Texture2D image;
    public Texture2D[] plantTextures;
    public GameObject[] plantObjects;

    private void OnEnable()
    {
        print("ftp upload script is opened");
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GetObjectsTexture()
    {
        plantTextures = new Texture2D[plantObjects.Length];
        for (int i = 0; i < plantObjects.Length; i++)
        {
            //plantTextures[i] = plantObjects[i].GetComponent<>
        }
    }

    public void FTPFileUpload()
    {
        string ftpPath = "ftp://bebeamplants.cafe24.com/myform/myimage.png";
        //개인별로 구분되는 이름필요, 폴더생성 필요
        string id = "bebeamplants";
        string pwd = "bebeam2020";

        //FileInfo myInfo = null;

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);//웹서버로 올리기 위한 request생성
        request.Method = WebRequestMethods.Ftp.UploadFile;//
        request.Credentials = new NetworkCredential(id, pwd);
        request.UseBinary = true;

        Stream ftpStream = request.GetRequestStream();//시스템 입출력에서 바이트 읽기쓰기 클래스 생성

        byte[] data = new byte[image.EncodeToPNG().Length];
        data = image.EncodeToPNG();

        ftpStream.Write(data, 0, data.Length);//생성된 스트림으로 데이터 쓰기
        ftpStream.Close();

    }
}
