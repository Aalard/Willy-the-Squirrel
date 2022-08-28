using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class reloadscript : MonoBehaviour
{

    [SerializeField]
    public Animator anim;
    [SerializeField]
    public Rigidbody2D willy;
    [SerializeField]
    private TimeDeltaTime timer;
    [SerializeField]
    private Score score;
    [SerializeField]
    public SpriteRenderer PlayerRenderer;
    [SerializeField]
    public Text CountDownText;
    public int Count = 2;
    private int CountS;
    public GameObject CountGameObject;
    private void Start()
    {
        CountS = Count;
        if (timer == null)
        {
            timer = FindObjectOfType<TimeDeltaTime>();
        }
        if (score == null)
        {
            score = FindObjectOfType<Score>();
        }

    }

    public void reloadScene()
    {
        anim.SetBool("Hit", false);
        anim.SetBool("jump", false);
        anim.SetBool("start", true);
        anim.Play("WillyStart");
        timer.FirstRun();
        if (willy.transform.position.y != -4.164992f)
        {
            willy.transform.position = new Vector2(willy.transform.position.x, -4.164992f);
        }
        willy.simulated = false;
        score.score = 0;
        score.UpdateScore();
        StartCoroutine(activerigidbody());
        CountDownText.gameObject.SetActive(true);
        StartCoroutine(CountDown());
    }
    public IEnumerator activerigidbody()
    {
        if (timer.stop)
        {
            //timer.FirstRun();
            for (int i = 0; i < CountS * 2; i++)
            {
                PlayerRenderer.color = new Color(1f, 1f, 1f, .5f);
                yield return new WaitForSeconds(.25f);
                PlayerRenderer.color = new Color(1f, 1f, 1f, 1f);
                yield return new WaitForSeconds(.25f);
            }
            timer.stop = false;
            willy.simulated = true;
            //timer.FirstRun();
        }
    }
    public IEnumerator CountDown()
    {
        if (timer.stop)
        {
            for (int i = 0; i < CountS; i++)
            {
                if (Count > 1) { 
                CountDownText.text = Count.ToString();
                }
                else { CountDownText.text = "GO!!"; }
                
                yield return new WaitForSeconds(1);
                Count = Count - 1;
            }
            CountDownText.gameObject.SetActive(false);
            Count = CountS;
        }
        else
        {
            CountDownText.gameObject.SetActive(false);
            Count = CountS;
        }
    }
}
