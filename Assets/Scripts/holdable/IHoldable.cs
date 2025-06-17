using UnityEngine;

public interface IHoldable
{
    // Method to pick up the Item
    // equi
    void Hold(Transform holderPosition);

    // Method that is called when the item is about to be used
    void Use();

    // Method to unequipt the Item
    void Drop();


}
