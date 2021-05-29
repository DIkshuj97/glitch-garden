using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in second")]
    [SerializeField] float leveltime = 10f;
    bool triggerLevelFinished = false;

    void Update()
    {
        if(triggerLevelFinished)
        {
            return;
        }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / leveltime;
        bool timerfinished = (Time.timeSinceLevelLoad >= leveltime);

        if(timerfinished)
        {
            FindObjectOfType<LevelController>().LevelTimerfinished();
            triggerLevelFinished = true;

        }
    }

}
