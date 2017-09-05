using UnityEngine;
using System.Collections;

public class rock : MonoBehaviour {
    public float moveSpeed = 2.0f;
    private Vector3 vforward;
    private bool flg;
    private Vector3 rawCamPos;
    private Vector3 rawObjPos;

    // Use this for initialization
    void Start () {
        vforward = Camera.main.transform.forward * -1f;
        rawObjPos = Camera.main.transform.position + Camera.main.transform.forward * 10.0f;
        transform.position = rawObjPos;
        flg = false;
        rawCamPos = Camera.main.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(flg)StartFly(rawCamPos, transform.position);
    }

   /* void OnGUI()
    {
        if (GUI.Button(new Rect(80, 80, 50, 20), "up"))
        {flg=true; }
        if (GUI.Button(new Rect(80, 120, 50, 20), "down"))
        {flg=false; }
        if (GUI.Button(new Rect(140, 100, 50, 20), "change"))
        {; }
    }*/

    void StartFly(Vector3 raw, Vector3 currt)
    {
        if (Vector3.Distance(raw, currt) < 2.0f)
        {
            //renderer.enabled;
            transform.position = rawObjPos;
        }
        else
        {
            transform.position += vforward * moveSpeed * Time.deltaTime;
        }
    }
}
