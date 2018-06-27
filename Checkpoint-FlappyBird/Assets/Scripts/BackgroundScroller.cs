using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    void OnTriggerExit2D(Collider2D collisionInfo)
    {
        if (collisionInfo.tag == "Player")
            transform.position += Vector3.right * GetComponent<SpriteRenderer>().bounds.size.x * 2;
    }

}
