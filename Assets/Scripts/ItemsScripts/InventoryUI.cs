using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    public GameObject inventoryUI;

    private bool cursorLocked = true;

    private Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.Instance;
        inventory.OnItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            cursorLocked = !cursorLocked;

            if (GameState.Instance.IsPaused)
            {
                GameState.Instance.Resume();
            }
            else
            {
                GameState.Instance.Pause();
            }

            if (cursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.GetCount())
            {
                slots[i].AddItem(inventory.Get(i));
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
