using System.Collections.Generic;
using UnityEngine;

public class FarmUpgrade : MonoBehaviour, IUpgradeable
{
    public List<GameObject> plots;
    [field: SerializeField]
    public float BaseCost { get; set; }
    public int MaxUpgradeLevel { get; set; }
    public int CurrentUpgradeLevel { get; set; }

    void Start()
    {
        CurrentUpgradeLevel = 0;

        foreach (var plot in plots)
        {
            plot.SetActive(false);
        }

        plots[0].SetActive(true);

        plots[0].GetComponent<IUpgradeable>().Upgrade();

        MaxUpgradeLevel = plots.Count - 1;
    }

    public float GetCost()
    {
        return BaseCost * (CurrentUpgradeLevel + 1);
    }

    public void Upgrade()
    {
        CurrentUpgradeLevel++;
        plots[CurrentUpgradeLevel].SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    
}
