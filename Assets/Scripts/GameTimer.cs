using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Game time in seconds")]
    [SerializeField] float levelTime = 10f;

    bool triggerLevelEnd = false;

    void Update()
    {
        if(triggerLevelEnd) { return; }

        float percentComplete = Time.timeSinceLevelLoad / levelTime;
        GetComponent<Slider>().value = percentComplete;

        bool levelComplete = (Time.timeSinceLevelLoad > levelTime);

        if (levelComplete)
        {
            FindObjectOfType<LevelController>().LevelTimerHasFinished();
            triggerLevelEnd = true;
        }
    }
}
