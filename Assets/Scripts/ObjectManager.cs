using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Destroy(this.gameObject);
    }
}
