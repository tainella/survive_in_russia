using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

	int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
    	switch (health) {
    		case 0:
    		{
				heart1.gameObject.SetActive(false);
				heart2.gameObject.SetActive(false);
				heart3.gameObject.SetActive(false);
    			break;
    		}
    		case 1:
    		{
				heart1.gameObject.SetActive(true);
				heart2.gameObject.SetActive(false);
				heart3.gameObject.SetActive(false);
    			break;
    		}
    		case 2:
    		{
				heart1.gameObject.SetActive(true);
				heart2.gameObject.SetActive(true);
				heart3.gameObject.SetActive(false);
    			break;
    		}
    		case 3:
    		{
				heart1.gameObject.SetActive(true);
				heart2.gameObject.SetActive(true);
				heart3.gameObject.SetActive(true);
    			break;
    		}
    	}
        
    }
}
