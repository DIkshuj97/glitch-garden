using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baselives = 3;
    [SerializeField] int damage=1;
    float lives;
    Text livesText;
    
    // Start is called before the first frame update
    void Start()
    {
        lives = baselives - PlayerPrefsController.GetDifficulty();
        livesText =GetComponent<Text>();
        updateDisplay(); 
    }

    // Update is called once per frame
    private void updateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void takeLife()
    {
        lives-=damage;
        updateDisplay();

        if(lives<=0)
		{
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
