using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    //public Inventory inventory;
    private bool cursorLocked = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cursorLocked = !cursorLocked;

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
}
