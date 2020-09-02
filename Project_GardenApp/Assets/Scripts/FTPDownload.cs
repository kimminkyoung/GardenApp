using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

public class FTPDownload : MonoBehaviour
{
    //1. get list
    //2. _를 기준으로 분류
    //3. 선택한 네임을 받아와서 리스트분류셑과 비교
    //4. 해당되는 파일 다운로드 

    public void FTPGetList()
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

        SeparateName(nameList);
    }

    public void SeparateName(List<string> nameList)
    {
        List<string> name = new List<string>();
        for (int i = 0; i < nameList.Count; i++)
        {
            if (Regex.IsMatch(nameList[i], "_") && Regex.IsMatch(nameList[i], "0"))
            {
                var voca = Regex.Split(nameList[i], "_");
                name.Add(voca[0]);

                print("splited is " + voca[0]);
            }
        }
    }

    public void FTPFileDownload()
    {
        
    }
}
