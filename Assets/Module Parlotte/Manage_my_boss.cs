using System;
using System.Collections;
using UnityEngine;

public class Manage_my_boss : MonoBehaviour {
    #region "Variables"

    private int T_Angry;
    public SpriteRenderer Boss;
    public int Temps_min;
    public int Temps_max;
    public int Mutiplicateur;
    private float uni_timer;
    private AudioClip Rage;
    System.Random random = new System.Random();
    System.Random R_Angry = new System.Random();

    #endregion

    private int RandomNumber(int min, int max)
    {
        return random.Next(min, max);
    }
    // Use this for initialization
    void Start()
    {
        T_Angry = RandomNumber(Temps_min, Temps_max);
        Boss = GetComponentInChildren<SpriteRenderer>();
        Rage = GetComponentInChildren<AudioClip>();
        setRespawnTimer();
    }

    private void setRespawnTimer()
    {
        uni_timer = random.Next(6, 11);
    }

    private void Respawn (System.Object source, System.Timers.ElapsedEventArgs e, int T_Respawn)
    {
        /*
        int tmp;
           if (Boss.enabled == true)
        {
            tmp = Mutiplicateur * T_Respawn;
            Timer_Respawn(T_Respawn, tmp);
        }
           else if (Boss.enabled == false)
        {
            tmp = Mutiplicateur * T_Respawn;
            Timer_Respawn(T_Respawn, tmp);
        }
           */
    }

    private void Timer_Respawn(int min, int max)
    {
        /*
         * int T_Respawn = RandomNumber(min, max);
        T_Timer = new System.Timers.Timer();
        uni_timer = Time.time;
        T_Timer.Interval = 1000 * T_Respawn;
        T_Timer.Elapsed += Respawn;
        T_Timer.Enabled = true;
        */
    }
    
    IEnumerator waitBossDeath(int min, int max)
    {
        int i = 0;
        float tmp;
        Vector3 position = new Vector3(0, 0, 0);

        tmp = (Mutiplicateur * (float)0.10 ) * T_Angry;
        while (Boss.enabled)
        {
            yield return new WaitForSeconds(1);
            i++;
            if (i == tmp)
            {
                AudioSource.PlayClipAtPoint(Rage, position);
            }
        }
        i = 0;
        setRespawnTimer();
    }

    void spawnBoss()
    {
        Boss.enabled = true;
        StartCoroutine(waitBossDeath(Temps_min, Temps_max));
    }

    void bossAlive()
    {

    }

    // Update is called once per frame
    void Update () {
        if (uni_timer <= 0 && !Boss.enabled)
            spawnBoss();
        else if (Boss.enabled)
            bossAlive();
        else
            uni_timer -= Time.deltaTime;

	}
}
