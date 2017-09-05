using System.IO;
using UnityEngine;
using System.Collections;

public class test2 : MonoBehaviour
{
    public const float CLOSE_ENOUGH = 3.0f;
    private Vector3 rawCamPos;
    private Texture2D myTexture;
    //private Texture tvTexture;
    private Material tvMat;
    //private bool flg;

    void Start()
    {
        //初始化 
        rawCamPos = Camera.main.transform.position;
        //myTexture = (Texture2D)Resources.Load("Cong");//使用Resources.Load动态加载当前图像 
        //tvTexture = GetComponent<Renderer>().materials[0].mainTexture;
        myTexture = LoadImageFrom("D:\\Cong.png");
        //tvMat = GetComponent<Renderer>().materials[0];
        tvMat = GameObject.Find("front1").GetComponent<Renderer>().materials[0];
        //flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsClose()) tvMat.mainTexture = myTexture;//将当前模型纹理进行修改;
        //Camera.main.transform.position += new Vector3(0, 0, 1) * 2.0f * Time.deltaTime;
        Camera.main.transform.position += Camera.main.transform.forward * 2.0f * Time.deltaTime;
    }

    bool IsClose()
    {
        if (Vector3.Distance(rawCamPos, Camera.main.transform.position) > CLOSE_ENOUGH)
        {
            return true;
        }
        else
            return false;
    }

    Texture2D LoadImageFrom(string path, int width = 400, int height = 400)
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