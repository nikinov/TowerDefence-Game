using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    private GameObject selectedObj;
    private IBuildable obj;

    [SerializeField]
    private Material canBuildMat;
    [SerializeField]
    private Material canNotBuildMat;
    [SerializeField]
    private LayerMask buildLayer;

    bool isBuildable;

    private float mouseWeelRotation;

    private void Update()
    {
        if(selectedObj != null)
        {
            mouseWeelRotation = Input.mouseScrollDelta.y;
            selectedObj.transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedObj.transform.Rotate(0f, 0f, mouseWeelRotation * 10f);
            chekIfCanBuild();

            if (Input.GetMouseButtonDown(0)) {
                Build();
            }
        }
    }


    private void chekIfCanBuild()
    {
        Bounds objBounds = obj.getBounds();
        Collider2D[] collider2D = Physics2D.OverlapAreaAll(objBounds.min, objBounds.max,buildLayer);

        foreach(Collider2D col in collider2D)
        {
            isBuildable = (col.gameObject == selectedObj.gameObject);
            if (!isBuildable) break;
        }
        
        if (isBuildable) obj.chengMat(canBuildMat);
        else obj.chengMat(canNotBuildMat);

        
    }

    public void Select(GameObject inst)
    {
        if (inst == null) return;

        selectedObj = inst;
        obj = inst.GetComponent<IBuildable>();
        obj.OnSelected();
    }

    public void Build()
    {
        if (selectedObj == null || !isBuildable) return;

        selectedObj = null;
        obj.OnBuild();
        obj = null;
    }
}
