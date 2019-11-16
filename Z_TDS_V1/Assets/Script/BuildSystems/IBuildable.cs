using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildable 
{
    void OnSelected();

    void OnBuild();

    Bounds getBounds();

    void chengMat(Material material);
}
