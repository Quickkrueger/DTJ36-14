using UnityEngine;

public class HoneyBuildup : MonoBehaviour
{
    public int honeyLevel = 0;
    public float honeyValue = 0.1f;
    private int maxHoneyLevel = 100;

    public float chancePerTick = 0.9f;
    public float TickPerSecond = 4f;
    private float lastHoneyAttempt = 0f;

    private Renderer beehiveRenderer;

    private void Start()
    {
        beehiveRenderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        if (Time.time - lastHoneyAttempt >= (1f / TickPerSecond))
        {
            if (Random.value < chancePerTick)
            {
                honeyLevel = Mathf.Min(maxHoneyLevel, honeyLevel + 1);
            }

            lastHoneyAttempt = Time.time;
        }

        if (honeyLevel >= maxHoneyLevel / 4)
        {
            ActiveShimmer();
        }
        else
        {
            beehiveRenderer.material.SetFloat("_ShimmerProgress", 0f);
        }
    }

    private void ActiveShimmer()
    {
        float shimmerProgress = Time.time % 2f;
        beehiveRenderer.material.SetFloat("_ShimmerProgress", shimmerProgress);
    }
}
