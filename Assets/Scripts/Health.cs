using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class Health : MonoBehaviour
{
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

    private GameObject[] healthItems;

    void Awake()
    {
        InitializeHealth();
    }

    public void Set_health(int health)
    {
        if (health < 1)
        {
            SceneManager.LoadScene("Fail");
            return;
        }

        for (int i = 0; i < healthItems.Length; i++)
        {
            healthItems[i].SetActive(i + 1 <= health);
        }
    }

    private void InitializeHealth()
    {
        healthItems = new[] { heart1, heart2, heart3 };
        foreach (var item in healthItems)
        {
            item.SetActive(true);
        }
    }
}
