using UnityEngine;

public class BeeSuit : MonoBehaviour
{
    int suitLevel = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Upgrade()
    {
        suitLevel++;
    }

    public int GetSuitlevel()
    {
        return suitLevel;
    }
}
