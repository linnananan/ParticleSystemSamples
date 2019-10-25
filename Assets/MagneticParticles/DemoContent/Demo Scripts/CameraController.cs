using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
    private int currentIndex = 0;
    public Transform[] targets;
    private Vector3 vel;
    public float smoothTime, MaxSpeed, RotationSpeed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (targets == null)
	        return;
	    if (targets.Length == 0)
	        return;
	    if (Input.GetKeyDown(KeyCode.LeftArrow))
	    {
	        currentIndex += 1;
	        if (currentIndex > targets.Length - 1)
	            currentIndex = 0;
	    }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex -= 1;
            if (currentIndex < 0)
                currentIndex = targets.Length-1;
        }

	    transform.position = Vector3.SmoothDamp(transform.position, targets[currentIndex].position, ref vel, smoothTime, MaxSpeed);
	    transform.rotation = Quaternion.RotateTowards(transform.rotation, targets[currentIndex].rotation, Time.deltaTime * RotationSpeed);
	}
}
