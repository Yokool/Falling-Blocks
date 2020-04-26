using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ActionDeterminator
{
    bool IsActionPossible();
    void SetActionPossible(bool action);
}
