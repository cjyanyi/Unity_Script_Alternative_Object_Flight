using UnityEngine;
using System.Collections;

public class contrl_wb : MonoBehaviour {
    public bool flgUp = false;
    public bool flgDown = false;
    public int cnt_change = 2;
    public bool flgChange = false;
    public Vector3 vforward;
    private Vector3 rawBasePos;
    private Vector3 Vx;
    private Vector3 Vy = new Vector3(0, 1, 0);
    private Vector3 Vz;
    //private float[] x = { 1f, -1f, 1f };
    private float[] y = {1,-1,-1 };
    //private bool cnt = true;


    private GameObject[] rock = new GameObject[4];
    private GameObject[] pkmon = new GameObject[4];
    private GameObject[] empty = new GameObject[4];

    // Use this for initialization
    void Start () {
        // init param
        Vector3 vAbsforward = Camera.main.transform.forward;
        vAbsforward.y = 0;
        vforward = vAbsforward;
        Vx = Camera.main.transform.right;
        Vz = vforward;
        rawBasePos = Camera.main.transform.position + vAbsforward * 25f;
        cnt_change = 2;
        // end of init

        LoadObj(rock,"ROCK",true);
        LoadObj(pkmon, "Pokemon");
        LoadObj(empty, "Cube",true);

        for (int i = 0; i < empty.Length; i++)
        {
            //goary[i] = (GameObject)Instantiate(goary[0]);
            //goary[i].transform.position = GetPosBase(5 * (2 * (i % 2) - 1), 5 * y[i - 1], -4 * i);
            empty[i].AddComponent<Move>();
            //goary[i].SetActive(flg);
        };


    }
	
	// Update is called once per frame
	void Update () {
        if (flgUp)
        {
            for (int i = 0; i < rock.Length; i++)
            {
                empty[i].SendMessage("SetflgFly");
                //pkmon[i].SendMessage("SetflgFly");
            }
            flgUp = false;
        }
  
                if (cnt_change == 0)
                {
                    for (int i = 0; i < pkmon.Length; i++)
                    {
                        SetObjPos(pkmon[i], empty[i]);
                        //pkmon[i].SendMessage("SetflgFly");
                        pkmon[i].SetActive(true);
                        rock[i].SetActive(false);
                        //pkmon[i].SendMessage("SetflgFly");
                    }
                }
                else if (cnt_change == 1)
                {

                    for (int i = 0; i < pkmon.Length; i++)
                    { SetObjPos(pkmon[i], empty[i]); }
                    pkmon[2].SetActive(false);
                    pkmon[1].SetActive(false);
                    //pkmon[4].SetActive(true);
        }
                else
                {
                      for (int i = 0; i < rock.Length; i++)
                      {
                            SetObjPos(rock[i], empty[i]);
                            //pkmon[i].SendMessage("SetflgFly");
                            pkmon[i].SetActive(false);
                            rock[i].SetActive(true);
                           //pkmon[i].SendMessage("SetflgFly");
                       }

                }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(80, 80, 50, 20), "up"))
        { flgUp = !flgUp; }
        if (GUI.Button(new Rect(80, 120, 50, 20), "down"))
        { flgDown = !flgDown; }
        if (GUI.Button(new Rect(140, 100, 50, 20), "change"))
        { cnt_change = ((++cnt_change)%3); flgChange = true; }
    }

    void LoadObj(GameObject[] goary, string str, bool flg=false)
    {
        if (str != "")
        {
            goary[0] = GameObject.Find(str);
            goary[0].transform.position = GetPosBase(-4,4,-10);
            //goary[0].AddComponent<Move>();
            //goary[0].SendMessage("SetflgInit");
            goary[0].name = str + 0;
            //goary[0].SetActive(flg);
        }
        else
            return;
        for (int i = 1; i < goary.Length; i++)
        {
            goary[i] = (GameObject)Instantiate(goary[0]);
            goary[i].transform.position = GetPosBase(4*(2*(i%2)-1), 4 * y[i-1], -6*i);
            //goary[i].AddComponent<Move>();
            goary[0].name = str + i;
            //goary[i].SetActive(flg);
        };
    }

    Vector3 GetPosBase(float x, float y, float z)
    {
        return (rawBasePos + Vx * x + Vy * y + Vz * z);
    }

    void SetObjPos(GameObject go1,GameObject gosrc)
    {
        go1.transform.position=gosrc.transform.position;
    }
}



//definition of class 
public class Move : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Vector3 vforward;
    public bool flgFly;
    //public bool flgInit;
    //public bool flgSee;
    //private Vector3 rawCamPos;
    public Vector3 rawObjPos;
    //private Vector3 plnCamPos;

    // Use this for initialization
    void Start()
    {
        Vector3 vAbsforward = Camera.main.transform.forward * -1f;
        vAbsforward.y = 0;
        vforward = vAbsforward;
        //rawCamPos = Camera.main.transform.position;
        rawObjPos = transform.position;
        //Vector3 vtemp = rawCamPos;
       // vtemp.y = rawObjPos.y;
        //plnCamPos = vtemp;
        //
        flgFly = false;
        //flgInit = false;
        //flgSee = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        //if (true)//(flgInit)
        //{
            if (flgFly) StartFly(transform.position);
        //}
    }

    void StartFly(Vector3 currt)
    {
        if (Vector3.Distance(rawObjPos, currt) > 15.0f)
        {
            //renderer.enabled;
            transform.position = rawObjPos;
        }
        else
        {
            transform.position += vforward * moveSpeed * Time.deltaTime;
        }
    }

    void SetflgFly()
    {
        flgFly = !flgFly;
    }

    /*void SetflgInit()
    {
        flgInit = true;
    }*/
}
