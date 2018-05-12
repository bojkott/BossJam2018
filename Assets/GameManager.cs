using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject tearyWin;
    public GameObject sweatyWin;
    public GameObject bloodyWin;
    public GameObject tie;
    bool gameOver = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!gameOver)
        {
            Resource sweatyResource = GameObject.FindGameObjectWithTag("Sweaty").GetComponent<Resource>();
            Resource bloodyResource = GameObject.FindGameObjectWithTag("Bloody").GetComponent<Resource>();
            Resource tearyResource = GameObject.FindGameObjectWithTag("Teary").GetComponent<Resource>();
            if (sweatyResource.points == 0 && tearyResource.points == 0 && bloodyResource.points == 0)
            {
                //blood win
                tie.SetActive(true);
                gameOver = true;
            }
            else if (sweatyResource.points == 0 && tearyResource.points == 0)
            {
                //blood win
                bloodyWin.SetActive(true);
                gameOver = true;
            }
            else if (sweatyResource.points == 0 && bloodyResource.points == 0)
            {
                //teary win
                tearyWin.SetActive(true);
                gameOver = true;
            }
            else if (bloodyResource.points == 0 && tearyResource.points == 0)
            {
                //sweaty win
                sweatyWin.SetActive(true);
                gameOver = true;
            }

            if(gameOver)
            {
                Invoke("Exit", 5);
            }
        }else
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);

    }

    void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
