using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour {
    public Text scoreText;

    bool isDead = false;

    Rigidbody2D rb2d;
    //Public variables are editable from the inspector
    public float speed = 5f;
    public float delay = 2f;
    public float maxYposition = 1f;
    //Use SerializeField to edit a variable from the inspector even if it's private
    [SerializeField]
    private float flapForce = 20f;

    private int score = 0;

    void Start() {
        Screen.orientation = ScreenOrientation.Portrait;
        //Freeze time to wait for the player to press Play
        Time.timeScale = 0;
        //Get a reference to the RigidBody2D component
        rb2d = GetComponent<Rigidbody2D>();

        //Set the initial velocity of our Bird
        rb2d.velocity = Vector2.right * speed * Time.deltaTime;
    }
	void Update () {
        
        //Wait for jump Input only if the bird is not Dead
        if (Input.GetMouseButtonDown(0) && !isDead && transform.position.y < maxYposition)
        {
            // Reset Velocity 
            rb2d.velocity = Vector2.right * speed * Time.deltaTime;

            //Add UP force to the bird
            rb2d.AddForce(Vector2.up * flapForce);
        } 
	}


    void OnCollisionEnter2D(Collision2D col)
    { 
        Die();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "score")
        {

            //Increment score
            score++;
            //update Text
            scoreText.text = score.ToString();
        }
    }

    void Die()
    {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        
        //Change the isDead parameter of the Animator to start the Dead animation
        GetComponent<Animator>().SetBool("isDead", isDead);
        
        //Use a coroutine to wait an amount of seconds before restarting the level.
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(delay);
        //Use SceneManager to Restart the Level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Function must be public to be called from the button
    public void unFreez()
    {
        // Reset timeScale back to 1 to unfreez Time.
        Time.timeScale = 1;
    }
}
