using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    public float moveSpeed = 2.0f;
    public Vector3 vforward;
    public bool flgFly;
    public bool flgInit;
    //public bool flgSee;
    private Vector3 rawCamPos;
    public Vector3 rawObjPos;

    // Use this for initialization
    void Start () {
        Vector3 vAbsforward = Camera.main.transform.forward * -1f;
        vAbsforward.y = 0;
        vforward = vAbsforward;
        rawCamPos = Camera.main.transform.position;
        //
        flgFly = false;
        flgInit = false;
        //flgSee = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(flgInit)
        {
            if(flgFly)StartFly(transform.position);
        }
	
	}

    void StartFly(Vector3 currt)
    {
        if (Vector3.Distance(rawCamPos, currt) < 2.0f)
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
