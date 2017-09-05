//using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class construction : MonoBehaviour {
    //public var Scripttype;

	// Use this for initialization
	void Start () {
        //var fs = new FileStream(@"D:\TestLib1.dll", FileMode.Open);
        //var b = new byte[fs.Length];
        //fs.Read(b, 0, b.Length);
        //fs.Close();
        //var assembly = System.Reflection.Assembly.Load(b);

        //var assembly = System.Reflection.Assembly.LoadFile(@"D:\color.dll");
        var assembly = System.Reflection.Assembly.Load("Color");
        var type = assembly.GetType("Color");
       // Scripttype = assembly.GetType("Input");
        GameObject tGO = new GameObject("tGo");
        tGO.AddComponent(type);
    }
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.position += new Vector3(0, 0, 1) * 1f * Time.deltaTime; //模拟camera向前移动
        //Camera.main.transform.position += Camera.main.transform.forward * 2.0f * Time.deltaTime;
    }
}
