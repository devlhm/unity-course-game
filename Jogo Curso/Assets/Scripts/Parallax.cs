using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public Transform background;
    public float speed;


    private Transform camTransform;
    private Vector3 previewCamPos;

	// Use this for initialization
	void Start () {
        camTransform = Camera.main.transform;
        previewCamPos = camTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float parallaxX = previewCamPos.x - camTransform.position.x;
        float bgTargetX = background.position.x + parallaxX;

        Vector3 bgPos = new Vector3(bgTargetX, background.position.y, background.position.z);
        background.position = Vector3.Lerp(background.position, bgPos, speed * Time.deltaTime);

        previewCamPos = camTransform.position;
	}
}
