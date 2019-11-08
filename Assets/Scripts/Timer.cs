using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float time;
    private characterControl player;
    public Text countdown;
    
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<characterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        countdown.text = ("" + (int)time);

        if ( time <= 0 && player.alive) {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
