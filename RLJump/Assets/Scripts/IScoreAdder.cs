using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreAdder
{
    void addScore(int score);

    int getScore();
}
