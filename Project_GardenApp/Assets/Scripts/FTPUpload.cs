﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.UI;

public class FTPUpload : MonoBehaviour
{
    public InputField getName;
    public GameObject[] plantObjects;

    Texture2D[] plantTextures;

    private void OnEnable()
    {
        print("ftp upload script is opened");
    }

    public void GetName()
    {
        string myName = getName.text;
        GetObjectsTexture(myName);
    }

    public void GetObjectsTexture(string name)
    {
        plantTextures = new Texture2D[plantObjects.Length];
        for (int i = 0; i < plantObjects.Length; i++)
        {
            plantTextures[i] = (Texture2D)plantObjects[i].GetComponent<MeshRenderer>().material.mainTexture;
        }
        FTPFileUpload(name, plantTextures);
    }

    public void FTPFileUpload(string name, Texture2D[] textures)
    {
        //파일 업로드
        for (int i = 0; i < textures.Length; i++)
        {
            // 1. 파일 위치, 이름 설정
            string ftpPath = "ftp://bebeamplants.cafe24.com/myform/" + name + "_image" + i + ".png";
            string id = "bebeamplants";
            string pwd = "bebeam2020";

            // 2. 웹서버로 올리기 위한 request생성
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
            request.Method = WebRequestMethods.Ftp.UploadFile;//업로드
            request.Credentials = new NetworkCredential(id, pwd);//아이디,비번입력
            request.UseBinary = true;//바이너리 데이터로 전송
            request.UsePassive = true;//방화벽사용시 자동포트로 연결

            Stream ftpStream = request.GetRequestStream();//시스템 입출력에서 바이트 읽기쓰기 클래스 생성

            byte[] data = new byte[textures[i].EncodeToPNG().Length];
            data = textures[i].EncodeToPNG();
            //하나씩 텍스쳐를 png로 데이터로 저장

            ftpStream.Write(data, 0, data.Length);//생성된 스트림으로 데이터 쓰기
            ftpStream.Close();
        }

        print("Upload Complet");
    }
}

//폴더 생성후 업로드
/*
string ftpPathFolder = "ftp://bebeamplants.cafe24.com/myform/";// + name + "Folder/";
string id = "bebeamplants";
string pwd = "bebeam2020";

FtpWebRequest requestFolder = (FtpWebRequest)WebRequest.Create(ftpPathFolder);//웹서버로 올리기 위한 request생성
requestFolder.UseBinary = true;
requestFolder.UsePassive = true;
requestFolder.Method = WebRequestMethods.Ftp.MakeDirectory;
requestFolder.Credentials = new NetworkCredential(id, pwd);

FtpWebResponse responseFolder = (FtpWebResponse)requestFolder.GetResponse();
responseFolder.Close();
//requestFolder.UsePassive = true;
//requestFolder.UseBinary = true;


//var resp = (FtpWebResponse)requestFolder.GetResponse();
//resp.Close();

//Stream ftpStreamFolder = requestFolder.GetRequestStream();
//ftpStreamFolder.Close();
*/
