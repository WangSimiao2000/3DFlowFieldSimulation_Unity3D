using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReadData : MonoBehaviour
{
    public Button readDataButtonObj;//按钮对象
    public string filePath;//txt文件路径
    public List<DataPoint> dataPoints = new List<DataPoint>();

    // Start is called before the first frame update
    void Start()
    {
        readDataButtonObj.onClick.AddListener(ReadDataFromTxt);
    }

    void ReadDataFromTxt()
    {
        //检查文件是否存在
        if (!File.Exists(filePath))
        {
            Debug.LogError("文件在" + filePath + "上不存在");
            return;
        }

        //读取txt文件
        string[] lines = File.ReadAllLines(filePath);

        //遍历每一行
        foreach (string line in lines)
        {
            DataPoint dataPoint = new DataPoint();

            //将每一行的数据分割为数组
            string[] values = line.Split(' ');

            //读取x,y,z坐标
            dataPoint.X = double.Parse(values[0]);
            dataPoint.Y = double.Parse(values[1]);
            dataPoint.Z = double.Parse(values[2]);

            //读取流速
            dataPoint.A = double.Parse(values[3]);
            dataPoint.B = double.Parse(values[4]);
            dataPoint.C = double.Parse(values[5]);

            //读取温度
            dataPoint.T = double.Parse(values[6]);

            dataPoints.Add(dataPoint);

            Debug.Log("文件读取完毕");
        }
    }
}
