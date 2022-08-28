using System.Collections;
using UnityEngine;
public class TimeDeltaTime : MonoBehaviour
{
    //public float speedup;
    //[HideInInspector]
    //public float speedIncrease = 0.0f;
    [HideInInspector]
    public float speed001;
    [HideInInspector]
    public float speed002;
    [Range(1, 5)]
    public float StartSpeed = 3;
    [HideInInspector]
    public bool stop = true;
    [Range(5, 30)]
    public float SpeedUpTime = 5;
    public float dash = 2;
    //private float dashspeed01;
    //private float dashspeed02;
    public float dashTime = 1;
    public AudioManager amanager;
    public bool isDash = false;
    public Score score_script;
    public int level = 0;
    public GameObject[] AcronSpawnPoint;
    private Player player;

    public void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    public void FirstRun()
    {
        speed001 = StartSpeed;
        speed002 = StartSpeed + 2;
        level = 0;
        for (int i = 0; i < AcronSpawnPoint.Length; i++)
        {
            AcronSpawnPoint[i].SetActive(false);
        }
        AcronSpawnPoint[level].SetActive(true);
        //StartCoroutine(Run());
    }
    /* IEnumerator Run()
     {
         if (!stop)
         {
             if (speed001 <= 10f)
             {
                 yield return new WaitForSeconds(SpeedUpTime);
                 while (isDash==true) { yield return new WaitForSeconds(0.5f); }
                 speed001 += speedIncrease;
                 speed002 += speedIncrease;
                 speedIncrease += speedup;
                 yield return StartCoroutine(Run());
             }
         }
         else { yield return null; }
     }*/
    /*public void Runner()
    {
        if (!stop)
        {
            if (!isDash)
            {
                {
                    if (score_script.score >= 10 && score_script.score <= 30)
                    {
                        speed001 = StartSpeed+2;
                        speed002 = StartSpeed + 4;
                       //level++;
                        //Debug.Log(speed001);
                    }
                    else if (score_script.score >= 30 && score_script.score <= 50)
                    {
                        speed001 = StartSpeed+4;
                        speed002 = StartSpeed + 6;
                       //level++;
                       //Debug.Log(speed001);
                   }
                    else if (score_script.score >= 50 && score_script.score <= 80)
                    {
                        speed001 = StartSpeed+6;
                        speed002 = StartSpeed + 8;
                       //level++;
                       //Debug.Log(speed001);
                   }
                    else if (score_script.score >= 80 && score_script.score <= 100)
                    {
                        speed001 = StartSpeed + 8;
                        speed002 = StartSpeed + 10;
                       //level++;
                       //Debug.Log(speed001);
                   }
                    else if (score_script.score >= 100)
                    {
                        speed001 = StartSpeed + 10;
                        speed002 = StartSpeed + 12;
                       //level++;
                       //Debug.Log(speed001);
                   }
                    else
                   {
                       speed001 = StartSpeed;
                       speed002 = StartSpeed + 2;
                   }
                }
            }
            else { }
        }
        else
        {
           // speed001 = 1;
           // speed002 =1;
        }
    }*/
    public void Stop()
    {
        stop = true;
        //StopAllCoroutines();
        speed001 = 0;
        speed002 = 0;
        //speedIncrease = 0;
        isDash = false;

    }
    public void changeStop()
    {
        stop = !stop;
    }

    public IEnumerator Dash()
    {
        //dashspeed01 = speed001;
        //dashspeed02 = speed002;
        isDash = true;
        speed001 = speed001 * dash;
        speed002 = speed002 * dash;
        yield return new WaitForSeconds(dashTime);
        if (!stop)
        {
            isDash = false;
            //speed001 = dashspeed01;
            //speed002 = dashspeed02;
            levelUp();
        }
        isDash = false;
        yield return null;
    }
    /* IEnumerator SpeedUp()
     {
         speed001 = speed001 + 3;
         speed002 = speed001 + 2;
         yield return null;
     }*/
    public void levelUp()
    {
        if (!stop)
        {
            if (!isDash)
            {
                if (level == 0)
                {
                    speed001 = StartSpeed;
                    speed002 = StartSpeed + 2;

                    AcronSpawnPoint[0].SetActive(true);
                }
                else if (level == 1)
                {
                    speed001 = StartSpeed + 2;
                    speed002 = StartSpeed + 4;

                    AcronSpawnPoint[1].SetActive(true);
                    //level++;
                    //Debug.Log(speed001);
                }
                else if (level == 2)
                {
                    speed001 = StartSpeed + 4;
                    speed002 = StartSpeed + 6;

                    AcronSpawnPoint[2].SetActive(true);
                    //level++;
                    //Debug.Log(speed001);
                }
                else if (level == 3)
                {
                    speed001 = StartSpeed + 6;
                    speed002 = StartSpeed + 8;

                    AcronSpawnPoint[3].SetActive(true);
                    //level++;
                    //Debug.Log(speed001);
                }
                else if (level == 4)
                {
                    speed001 = StartSpeed + 8;
                    speed002 = StartSpeed + 10;

                    AcronSpawnPoint[4].SetActive(true);
                    //level++;
                    //Debug.Log(speed001);
                }
                else if (level == 5)
                {
                    speed001 = StartSpeed + 10;
                    speed002 = StartSpeed + 12;
                    AcronSpawnPoint[5].SetActive(true);
                    //level++;
                    //Debug.Log(speed001);
                }



                for (int i = 0; i < AcronSpawnPoint.Length; i++)
                {
                    AcronSpawnPoint[i].SetActive(false);
                }
                AcronSpawnPoint[level].SetActive(true);
            }
            else { }
        }
        else { }

    }
    IEnumerator Pause()
    {
        yield return new WaitWhile(() => player.dashtimer > 0);
    }
}

