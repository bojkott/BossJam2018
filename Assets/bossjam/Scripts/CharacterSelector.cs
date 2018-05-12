using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject arrowSelector;
    private GameObject clonedObject;
    private bool arrowCreated = false;
    private float[] characterPostions;
    private int index = 1;

    // Use this for initialization
    void Start ()
    {
        characterPostions = new float[3] {213.9f, 216.801f, 219.349f };
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(arrowSelector != null && !arrowCreated)
        {
            clonedObject = Instantiate(arrowSelector, new Vector3(characterPostions[0], arrowSelector.transform.position.y, arrowSelector.transform.position.z), 
                                       arrowSelector.transform.rotation);
            arrowCreated = true;
        }

        if(arrowCreated)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (index % 3 == 0)
                    index = 0;

                clonedObject.transform.position = new Vector3(characterPostions[index], clonedObject.transform.position.y, clonedObject.transform.position.z);
                index++;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(index != 0)
                {
                    index--;
                    clonedObject.transform.position = new Vector3(characterPostions[index], clonedObject.transform.position.y, clonedObject.transform.position.z);
                }
            }
            if(Input.GetKeyDown(KeyCode.Return))
            {
                //Character selection goes here...
            }     
        }
    }
}
