using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] private Image[] heartsImage;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
             instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay(int health, int maxHealth)
    {
        for (int i = 0; i < heartsImage.Length; i++)
        {
            heartsImage[i].enabled = true;

            if(health <= i)
            {
                heartsImage[i].enabled = false;

            }

        }
    }

}
