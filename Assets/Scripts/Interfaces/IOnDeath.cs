using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The interface used with the health tracker class.
/// The OnDeath method gets called when the objects health reaches zero - thus dying.
/// </summary>
public interface IOnDeath
{

    void OnDeath();

}
