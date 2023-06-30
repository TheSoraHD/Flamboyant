using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "Enemy/DecisionHealthLessThan")]
    public class DecisionHealthLessThan : FSM.Decision
    {
        public float value;
        public override bool Decide(Controller c)
        {
            return c.GetComponent<HealthBehaviour>().currentHealth < value;
        }
    }
}
