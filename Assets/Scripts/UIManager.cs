using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;

    private KuroController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<KuroController>();

        playerHealthBar.maxValue = player.maxHealth;

        playerHealthBar.value = playerHealthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePlayerHealth(float amount)
    {
        playerHealthBar.value = amount;
    }
}
