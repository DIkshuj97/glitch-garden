using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winlabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;
    int NoOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winlabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        NoOfAttackers++;
    }

    public void AttackerKilled()
    {
        NoOfAttackers--;
        if(NoOfAttackers<=0 && levelTimerFinished )
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winlabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoad>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        winlabel.SetActive(false);
        Time.timeScale = 0;
    }

    public void LevelTimerfinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerarray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerarray)
        {
            spawner.StopSpawning();
        }
    }
}
