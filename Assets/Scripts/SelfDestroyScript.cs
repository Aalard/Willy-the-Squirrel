using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyScript : MonoBehaviour
{
    public bool isPorceline;
    [SerializeField]
    private Score score;
    public GameObject destroyobscalateseffect;
    [SerializeField]
    private Player player;
    void Awake()
    {
        score = FindObjectOfType<Score>();
        player= FindObjectOfType<Player>();
    }
    public void SelfDestroy()
    {
        if (destroyobscalateseffect != null)
        {
            Instantiate(destroyobscalateseffect, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        else { }
        if (gameObject.tag == "GlassObsc")
        {
            FindObjectOfType<AudioManager>().Play("PorcelineCrash");
            score.scoreUp();
        }
        else if (gameObject.tag == "PotObsc")
        {
            FindObjectOfType<AudioManager>().Play("PotHit");
            score.scoreUp();
        }
        else if (gameObject.tag == "acron")
        {
            //FindObjectOfType<AudioManager>().Play("PotHit");
            score.scoreUp();
        }
        else if (gameObject.tag == "GreenAcron") {
            score.scoreDown();
        }else if (gameObject.tag == "GoldenAcron")
        {
            score.scoreUp();
            score.scoreUp();
        }else if (gameObject.tag == "branch")
        {
            player.dashtimer = player.dashtimer / 2;
        }
        else { }
        //score.scoreUp();
        
            if (transform.parent == null||transform.parent.gameObject.tag == "obscalates")
            {
                Destroy(gameObject);
                //Debug.Log("gggg"); 
            }
            else { Destroy(gameObject.transform.parent.gameObject); }
            //GameObject.Destroy(self);
        
    }
}
