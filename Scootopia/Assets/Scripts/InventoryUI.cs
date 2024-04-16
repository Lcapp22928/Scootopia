
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI collectableText;

    // Start is called before the first frame update
    void Start()
    {
        collectableText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCollectableText(PlayerInventory playerInventory)
    {
        collectableText.text = playerInventory.NumberOfCollectables.ToString();
    }
}


