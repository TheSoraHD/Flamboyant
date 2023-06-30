using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Action")]

public class ChangeAnimation : FSM.Action
{
    public string animationName;
    public override void Act(Controller c)
    {
        Debug.Log("Change Animation To " + animationName);
    }
}
