using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 5;
    protected override void OnCollect()
    {
        if (!collected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Grant " + pesosAmount + " pesos!");
        }
        // base.OnCollect();
        // Debug.Log("Grant pesos");
    }
}
