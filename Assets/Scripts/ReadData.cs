using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReadData : MonoBehaviour
{
    public Button readDataButtonObj;//��ť����
    public string filePath;//txt�ļ�·��
    public List<DataPoint> dataPoints = new List<DataPoint>();

    // Start is called before the first frame update
    void Start()
    {
        readDataButtonObj.onClick.AddListener(ReadDataFromTxt);
    }

    void ReadDataFromTxt()
    {
        //����ļ��Ƿ����
        if (!File.Exists(filePath))
        {
            Debug.LogError("�ļ���" + filePath + "�ϲ�����");
            return;
        }

        //��ȡtxt�ļ�
        string[] lines = File.ReadAllLines(filePath);

        //����ÿһ��
        foreach (string line in lines)
        {
            DataPoint dataPoint = new DataPoint();

            //��ÿһ�е����ݷָ�Ϊ����
            string[] values = line.Split(' ');

            //��ȡx,y,z����
            dataPoint.X = double.Parse(values[0]);
            dataPoint.Y = double.Parse(values[1]);
            dataPoint.Z = double.Parse(values[2]);

            //��ȡ����
            dataPoint.A = double.Parse(values[3]);
            dataPoint.B = double.Parse(values[4]);
            dataPoint.C = double.Parse(values[5]);

            //��ȡ�¶�
            dataPoint.T = double.Parse(values[6]);

            dataPoints.Add(dataPoint);

            Debug.Log("�ļ���ȡ���");
        }
    }
}
