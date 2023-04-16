using System.Collections;
using UnityEngine;

public class Droppable : Interactible
{
    public Item Item;

    public float cooldown = 0.75f;

    private int hp = 2;

    private bool canAttack = true;

    private void Awake()
    {
        radius = 0.2f;
    }

    public override void Interact()
    {
        if (canAttack && Input.GetKeyDown(KeyCode.Mouse0))
        {
            canAttack = false;

            if (--hp <= 0)
            {
                CreateItem();

                Destroy(gameObject);
            }

            StartCoroutine(ResetCooldown());
        }
    }

    private void CreateItem()
    {
        // Create the object that can be picked after the current droppable object is destroyed
        GameObject pickableItem = Instantiate(Item.model);
        pickableItem.name = Item.name;
        pickableItem.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        ItemPickup itemPickup = pickableItem.AddComponent<ItemPickup>();
        itemPickup.Item = Item;
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
