using UnityEngine;

public class SuitUpgrade : MonoBehaviour, IUpgradeable
{
    [field: SerializeField]
    public float BaseCost { get; set; }
    [field: SerializeField]
    public int MaxUpgradeLevel { get; set; }
    public int CurrentUpgradeLevel { get; set; }

    public float GetCost()
    {
        return BaseCost * (CurrentUpgradeLevel + 1);
    }

    public void Upgrade()
    {
        CurrentUpgradeLevel++;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
