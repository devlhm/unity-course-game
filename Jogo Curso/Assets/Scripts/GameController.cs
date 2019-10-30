using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [HideInInspector]
    public Transform playerTransform;
    private Camera cam;

    public Transform camLimitLeft, camLimitRight, camLimitTop, camLimitBottom;
    public float camSpeed = 0.5f;
    
	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate() {
        float xCamPos = playerTransform.position.x;
        float yCamPos = playerTransform.position.y;

        if(cam.transform.position.x < camLimitLeft.position.x && playerTransform.position.x < camLimitLeft.position.x) {
            xCamPos = camLimitLeft.position.x;
        } else if (cam.transform.position.x > camLimitRight.position.x && playerTransform.position.x > camLimitRight.position.x) {
            xCamPos = camLimitRight.position.x;
        }

        if (cam.transform.position.y < camLimitBottom.position.y && playerTransform.position.y < camLimitBottom.position.y) {
            yCamPos = camLimitBottom.position.y;
        } else if (cam.transform.position.y > camLimitTop.position.y && playerTransform.position.y > camLimitTop.position.y) {
            yCamPos = camLimitTop.position.y;
        }

        Vector3 posCam = new Vector3(xCamPos, yCamPos, cam.transform.position.z);
        cam.transform.position = Vector3.Lerp(cam.transform.position, posCam, camSpeed * Time.deltaTime);
    }
}
