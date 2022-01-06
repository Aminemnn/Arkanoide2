using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balll : MonoBehaviour
{
    [HideInInspector]
    public float speed = 150f;
    [SerializeField]
    private GameObject gameover;
    public Text Scoretext;
    public  Text scorefinal;
    private Animator animationBall;
     int score =0;
  
    void Start()
    {
         GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
         gameover.SetActive(false);
         scorefinal.enabled=false;
         

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    float HitFactor(Vector2 BallPos,Vector2 RacketPos,float RacketHeight)
    {
        return (BallPos.x - RacketPos.x) / RacketHeight;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "racket")
        {

            float x = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            
        }

        // Hit the right Racket?
        if(col.gameObject.tag=="Blocked" )
        {
            Destroy(col.gameObject);
            score++;
            Scoretext.text=score.ToString();
            
        }
        if(col.gameObject.tag=="dor"){
            //
            gameover.SetActive(true);
            scorefinal.text=score.ToString();
            scorefinal.enabled=true;
            Scoretext.enabled=false;
            animationBall.Play("gameOverAnim01");
            //wait for a timelaps for the animation to end

            //Time.timeScale=0;
        } 
    }
}
