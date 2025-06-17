using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    private IHoldable _currentlyHolding;
    
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Transform _holdablePosition;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Hold"))
        {
            // Can only hold one item
            if (_currentlyHolding != null)
                return;


            Debug.Log("Eqiopts");
            Vector3 position = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);

                IHoldable holdable = hit.collider.GetComponent<IHoldable>();
                if (holdable != null)
                {
                    holdable.Hold(_holdablePosition);
                    _currentlyHolding = holdable;
                }
            }
        }
        
        if (Input.GetButtonDown("Drop"))
        {
            if (_currentlyHolding == null)
                return;

            Debug.Log("Drop");
        }
    }
}
