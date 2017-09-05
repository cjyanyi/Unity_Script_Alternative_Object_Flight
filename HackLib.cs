using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****codes in the up-layer************
var assembly = System.Reflection.Assembly.LoadFile(@"D:\Color.dll");
var type = assembly.GetType("Color");
GameObject tGO = new GameObject("Color");
tGO.AddComponent(type);
*************************************/

public class Color : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string text = "bonus";
        if (GameObject.Find(text) == null)
        {
            string path = "D:\\bonus";
            AssetBundle assetBundle = AssetBundle.LoadFromFile(path);
            Object original = assetBundle.LoadAsset(text);
            GameObject gameObject = Object.Instantiate(original) as GameObject;
            gameObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5.0f;
    
            gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
            gameObject.name = text;

            //添加绑定脚本 
            gameObject.AddComponent<MYActivity>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class MYActivity : MonoBehaviour
{
    public const float CLOSE_ENOUGH = 1.0f;
    private Vector3 rawCamPos;
    private Vector3 rawObjPos;
    float rawDist;
    private Texture2D myTexture;
    //private Texture tvTexture;
    private Material tvMat;
    private bool flg;

    void Start()
    {
        //初始化 
        rawCamPos = Camera.main.transform.position;
        rawObjPos = transform.position;
        rawDist = Vector3.Distance(rawCamPos, rawObjPos);
        tvMat = GameObject.Find("front1").GetComponent<Renderer>().materials[0];
        flg = false;

        //加载纹理
        //myTexture = (Texture2D)Resources.Load("Cong");//使用Resources.Load动态加载当前图像
        myTexture = LoadImageFrom("D:\\Cong.png");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsClose())
        {
            if (flg) return;
            tvMat.mainTexture = myTexture;//将当前模型纹理进行修改;
            flg = true;
        }
        //Camera.main.transform.position += new Vector3(0, 0, 1) * 2.0f * Time.deltaTime; //模拟camera向前移动
    }

    bool IsClose()
    {
        if (rawDist-Vector3.Distance(rawObjPos, Camera.main.transform.position) > CLOSE_ENOUGH)
        {
            return true;
        }
        else
            return false;
    }

    Texture2D LoadImageFrom(string path, int width=400, int height=400 )
    {
        //创建文件读取流
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        //创建Texture
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);
        return texture;
    }
}
