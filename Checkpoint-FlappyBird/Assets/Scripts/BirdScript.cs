using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour {
    // public Text scoreText;

    public Button ReplayButton;
    bool isDead = false;

    Rigidbody2D rb2d;
    //Public variables are editable from the inspector
    public float speed = 5f;
    public float delay = 2f;
     float maxYposition = 1f;
    public Text scoreText;
    //Use SerializeField to edit a variable from the inspector even if it's private
    [SerializeField]
    private float flapForce = 20f;

    private int score = 0;

    void Start() {
        //Prevent phone from switching to landscape mode
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
        //We grouped all the death instruction into a Die() function
        Die();
    }
 void Die()
    {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        //Set the ReplayButton to active to show it in the scene.
        ReplayButton.gameObject.SetActive(true);
        //Change the isDead parameter of the Animator to start the Dead animation
        GetComponent<Animator>().SetBool("isDead", isDead);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Score")
        {

            //Increment score
            score++;
            Debug.Log(score);
            //update Text
            scoreText.text = score.ToString();
        }
    }

   

    
    //Function must be public to be called from the button
    public void unFreez()
    {
        // Reset timeScale back to 1 to unfreez Time.
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
