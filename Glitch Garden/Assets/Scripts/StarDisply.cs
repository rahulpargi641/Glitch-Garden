using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisply : MonoBehaviour
{
   [SerializeField] public int stars = 100;
    Text starText;
    // Start is called before the first frame update
    void Start()
    {
       starText= GetComponent<Text>();  
        
    }

    void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStar(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }

    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
