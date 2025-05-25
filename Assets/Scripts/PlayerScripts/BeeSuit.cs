using UnityEngine;

public class BeeSuit : MonoBehaviour
{
    int suitLevel = 0;
    public Renderer renderer;
    public Material shirtMaterial;
    public Material pantsMaterial;
    public GameObject hat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Upgrade()
    {
        suitLevel++;
        if (suitLevel == 1)
        {
            renderer.material = shirtMaterial;
        }
        else if (suitLevel == 2)
        {
            renderer.material = pantsMaterial;
        }
        else if (suitLevel == 3)
        {
            hat.SetActive(true);
        }
    }

    public int GetSuitlevel()
    {
        return suitLevel;
    }
}
