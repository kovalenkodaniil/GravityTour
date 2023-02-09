using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Planet))]

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private RaycastHit2D[] result;

    private Vector3 MousePositionOffset;
    private Planet _planet;

    private void Awake()
    {
        _planet = GetComponent<Planet>();
    }

    private Vector3 GetWorldMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        MousePositionOffset = gameObject.transform.position - GetWorldMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetWorldMousePosition() + MousePositionOffset;
    }

    private void OnMouseUp()
    {
        RaycastHit2D[] result = Physics2D.RaycastAll(transform.position, new Vector2(0, 0), 20);

        List<RaycastHit2D> hits = result.ToList();

        foreach (var hit in hits)
        {
            Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.TryGetComponent<Planet>(out Planet planetForMerge))
            {
                _planet.TryMerge(planetForMerge);
            }
        }
    }
}
