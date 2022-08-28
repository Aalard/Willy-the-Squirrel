using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField]
    private TimeDeltaTime GMScript;
    [SerializeField]
    public GameObject endmenu;
    [SerializeField]
    public Animator anim;
    [SerializeField]
    private SpawnScript SpawnScript;
    [SerializeField]
    private ObscalatesSpawner obscalatesSpawner;
    [SerializeField]
    private ForegroundSpawn foregroundSpawn;
    [SerializeField]
    public Transform willy;
    [SerializeField]
    public Rigidbody2D willyrb2d;
    public AudioManager amanager;
    public TimeDeltaTime Timer;
    [SerializeField]
    private Score score;
    public GameObject destroyobscalateseffect;
    public GameObject stars;

    private void Start()
    {
        if (GMScript == null)
        {
            GMScript = FindObjectOfType<TimeDeltaTime>();
        }
        if (score == null)
        {
            score = FindObjectOfType<Score>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //other.GetComponent<SelfDestroyScript>().SelfDestroy();
        if (other.tag == "obscalates")
        {
            Instantiate(stars, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Hit");
            if (willy.transform.position.y != -4.164992f)
            {
                willy.transform.position = new Vector2(willy.transform.position.x, -4.164992f);
            }
            willyrb2d.simulated = false;
            if (GMScript != null)
            {
                anim.SetBool("Hit", true);
                amanager.ResetPitch("Theme");
                endmenu.gameObject.SetActive(true);
                GMScript.Stop();
                //GMScript.stop = true;
                // GMScript.speed001 = 0;
                //GMScript.speed002 = 0;
                score.EndGameHightScore();
                //GMScript.speedIncrease = 0;
            }
            else { }
        }
        else if (other.tag == "GlassObsc" || other.tag == "PotObsc" || other.tag == "branch")
        {
            if (!Timer.isDash)
            {
                Instantiate(stars, transform.position, Quaternion.identity);

                if (other.tag == "PotObsc")
                    FindObjectOfType<AudioManager>().Play("PotHit");
                else if (other.tag == "GlassObsc")
                    FindObjectOfType<AudioManager>().Play("PorcelineHit");
                else { FindObjectOfType<AudioManager>().Play("Hit"); }

                if (willy.transform.position.y != -4.164992f)
                {
                    willy.transform.position = new Vector2(willy.transform.position.x, -4.164992f);
                }
                willyrb2d.simulated = false;
                if (GMScript != null)
                {

                    anim.SetBool("Hit", true);
                    amanager.ResetPitch("Theme");
                    endmenu.gameObject.SetActive(true);
                    GMScript.Stop();
                    //GMScript.stop = true;
                    //GMScript.speed001 = 0;
                    //GMScript.speed002 = 0;
                    score.EndGameHightScore();
                    //GMScript.speedIncrease = 0;
                }
                else { }
            }
            else if (Timer.isDash)
            {
                if (other.GetComponent<SelfDestroyScript>() != null)
                {
                    other.GetComponent<SelfDestroyScript>().SelfDestroy();
                }
                else { }
                /* Instantiate(destroyobscalateseffect, new Vector3(other.transform.position.x,transform.position.y,0), Quaternion.identity);
                 if (other.tag == "GlassObsc")
                     FindObjectOfType<AudioManager>().Play("PorcelineCrash");
                else if (other.tag == "PotObsc")
                     FindObjectOfType<AudioManager>().Play("PotHit");
                 else { }
                 Destroy(other.gameObject);
                 score.scoreUp();
                 other.SelfDestroy();*/
            }
            else if (other.tag == null) { }
            else { }
        }
        else if (other.tag == "acron" || other.tag == "GreenAcron" || other.tag == "GoldenAcron")
        {

            if (other.GetComponent<SelfDestroyScript>() != null)
            {
                other.GetComponent<SelfDestroyScript>().SelfDestroy();
            }
            else { }
        }
        else { }
    }
}