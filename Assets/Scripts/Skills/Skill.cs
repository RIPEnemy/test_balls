using UnityEngine;
using System;

namespace Game
{
    public abstract class Skill : MonoBehaviour
    {
        protected Ball Owner { get; private set; }

        /// <summary>
        /// Construct the ball skill.
        /// </summary>
        /// <param name="owner">Reference to skill owner (ball).</param>
        public virtual void Construct(Ball owner)
        {
            Owner = owner != null ? owner : throw new ArgumentNullException(nameof(owner));

            Owner.OnBallStateChange += HandleBallState;
        }

        private void OnDestroy()
        {
            if (Owner == null)
                return;

            Owner.OnBallStateChange -= HandleBallState;
        }

        private void HandleBallState(object _, BallState state)
        {
            ProcessState(state);
        }

        protected abstract void ProcessState(BallState state);
    }
}