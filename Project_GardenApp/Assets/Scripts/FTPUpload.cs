using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;

public class FTPUpload : MonoBehaviour
{
    public Texture2D image;
    // Start is called before the first frame update
    void Start()
    {
        FTPFileUpload();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FTPFileUpload()
    {
        string ftpPath = "ftp://bebeamplants.cafe24.com/myform/myimage.png";
        string id = "bebeamplants";
        string pwd = "bebeam2020";

        FileInfo myInfo = null;

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential(id, pwd);
        request.UseBinary = true;
        Stream ftpStream = request.GetRequestStream();

        byte[] data = new byte[image.EncodeToPNG().Length];
        data = image.EncodeToPNG();

        ftpStream.Write(data, 0, data.Length);
        ftpStream.Close();

       // int writeLength = FileStream.re

    }
}
