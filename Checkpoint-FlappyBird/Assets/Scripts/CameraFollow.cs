using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform playerTransform;
    Vector3 range;
    // Use this for initialization
	void Awake () {
        range = transform.position - playerTransform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Only follow on the X axis
        transform.position = new Vector3(range.x + playerTransform.position.x, transform.position.y, range.z + playerTransform.position.z);
    }
}
