using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "Enemy/State")]
    public class State : ScriptableObject
    {
        public Action[] actions;
        public Transition[] transitions;

        public void UpdateState(Controller c)
        {
            DoActions(c);
            CheckTransitions(c);
        }

        private void DoActions(Controller c)
        {
            foreach (Action action in actions)
            {
                action.Act(c);
            }
        }
        private void CheckTransitions(Controller c)
        {
            foreach(Transition transition in transitions)
            {
                bool decision = transition.decision.Decide(c);
                if (decision)
                {
                    c.Transition(transition.trueState);
                    return;
                }
                else
                {
                    c.Transition(transition.falseState);
                }
            }
        }
    }
}
