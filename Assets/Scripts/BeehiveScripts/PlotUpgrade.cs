using UnityEngine;

public class PlotUpgrade : MonoBehaviour, IUpgradeable
{

    public GameObject hiveBasePrefab;
    public GameObject hiveTopPrefab;

    public int BaseCost { get; set; }
    public int MaxUpgradeLevel { get; set; }
    [HideInInspector]
    public int CurrentUpgradeLevel { get; set; }

    public void Upgrade()
    {

    }

    public void SetActive()
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCost()
    {
        return BaseCost * (CurrentUpgradeLevel + 1);
    }
}
