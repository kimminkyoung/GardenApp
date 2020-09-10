using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

public class FTPDownload : MonoBehaviour
{
    MakeGardenerList ins_GardenerList;
    //1. get list
    //2. _를 기준으로 분류
    //3. 선택한 네임을 받아와서 리스트분류셑과 비교
    //4. 해당되는 파일 다운로드 

    public List<string> FTPGetList()
    {
        string ftpPath = "ftp://bebeamplants.cafe24.com/myform/";
        string id = "bebeamplants";
        string pwd = "bebeam2020";

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
        request.Credentials = new NetworkCredential(id, pwd);
        request.Method = WebRequestMethods.Ftp.ListDirectory;
        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());

        List<string> nameList = new List<string>();
        string line = reader.ReadLine();

        while (!string.IsNullOrEmpty(line))
        {
            nameList.Add(line);
            line = reader.ReadLine();

            print("added line is " + line);
        }

        reader.Close();
        response.Close();

        return SeparateName(nameList);
    }

    public List<string> SeparateName(List<string> nameList)
    {
        List<string> name = new List<string>(); //대표 이름 리스트 저장
        for (int i = 0; i < nameList.Count; i++)
        {
            if (Regex.IsMatch(nameList[i], "_") && Regex.IsMatch(nameList[i], "0"))
            {
                var voca = Regex.Split(nameList[i], "_");
                name.Add(voca[0]);

                print("splited is " + voca[0]);
            }
        }

        return name;
    }

    public void MakeGaredener()
    {
        ins_GardenerList = gameObject.GetComponent<MakeGardenerList>();
        ins_GardenerList.MakeGardener(FTPGetList());
    }

    public void LoadGardener(string gardenName)
    {
        
    }

    public void FTPFileDownload(string gardenerName)
    {
        for (int i = 0; i < 3; i++)//저장되는 오브젝트 갯수 다른 방법 생각하기
        {
            string downPath = Application.dataPath + "/DownPhoto";
            string ftpPath = "ftp://bebeamplants.cafe24.com/myform/" + gardenerName + "_image" + i + ".png"; ;
            string id = "bebeamplants";
            string pwd = "bebeam2020";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
            request.Credentials = new NetworkCredential(id, pwd);
            request.UseBinary = true;
            request.UsePassive = true;
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream ftpStream = response.GetResponseStream();//시스템 입출력에서 바이트 읽기쓰기 클래스 생성
            FileStream fileStream = new FileStream(downPath, FileMode.Create);

            byte[] what = new byte[100];
            int readLength = ftpStream.Read(what, 0, 100);
            fileStream.Write(what, 0, readLength);

            response.Close();
            ftpStream.Close();
            fileStream.Close();
        }
        print("저장완료");
    }
}
