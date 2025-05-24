using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlotUpgrade : MonoBehaviour, IUpgradeable
{

    public GameObject hiveBasePrefab;
    public GameObject hiveTopPrefab;
    private List<GameObject> objects;

    [field: SerializeField]
    public float BaseCost { get; set; }
    [field: SerializeField]
    public int MaxUpgradeLevel { get; set; }
    [HideInInspector]
    public int CurrentUpgradeLevel { get; set; }

    void Start()
    {
        objects = new List<GameObject>();
    }

    public void Upgrade()
    {
        if (CurrentUpgradeLevel == 0)
        {
            objects.Add(Instantiate(hiveTopPrefab, transform.position, transform.rotation));
        }
        else
        {
            foreach(GameObject obj in objects)
            {
                obj.transform.position += Vector3.up * hiveBasePrefab.GetComponent<Renderer>().bounds.max.y;
            }
            objects.Add(Instantiate(hiveBasePrefab, transform.position, transform.rotation));
        }
            CurrentUpgradeLevel++;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetCost()
    {
        return BaseCost * (CurrentUpgradeLevel + 1);
    }
}
