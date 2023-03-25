using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratulationWritings : MonoBehaviour
{
    public List<GameObject> writings;

    void Start()
    {
        GameEvents.ShowCongratulationWritings += ShowCongratulationWritings;
    }

    private void OnDisable()
    {
        GameEvents.ShowCongratulationWritings -= ShowCongratulationWritings;
    }

    private void ShowCongratulationWritings()
    {
        var index = UnityEngine.Random.Range(0, writings.Count);
        writings[index].gameObject.SetActive(true);
    }

}
