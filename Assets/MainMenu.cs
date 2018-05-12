using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    bool p1 = false;
    bool p2 = false;
    bool p3 = false;
    public Transform p1Pos;
    public Transform p2Pos;
    public Transform p3Pos;
    public GameObject checkbox;

    public GameObject countdown1;
    public GameObject countdown2;
    public GameObject countdown3;
    bool starting = false;
    // Use this for initialization
    void Start () {
		
	}

    IEnumerator Countdown()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        countdown1.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        countdown2.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        countdown3.SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);
        SceneManager.LoadScene(1);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Start_1"))
        {
            p1 = true;
            Instantiate(checkbox, p1Pos.position + new Vector3(0, 10, 0), Quaternion.identity);
        }
            

        if (Input.GetButtonDown("Start_2"))
        {
            p2 = true;
            Instantiate(checkbox, p2Pos.position + new Vector3(0, 10, 0), Quaternion.identity);
        }
           

        if (Input.GetButtonDown("Start_3"))
        {
            p3 = true;
            Instantiate(checkbox, p3Pos.position + new Vector3(0, 10, 0), Quaternion.identity);
        }
        if (starting)
            return;

        if (p1 && p2 && p3)
        {
            starting = true;
            StartCoroutine(Countdown());
        }
            

        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	}
}
