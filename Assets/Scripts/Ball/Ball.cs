using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
    public abstract class Ball : MonoBehaviour
    {
        /// <summary>
        /// Overall reference to ball settings.
        /// </summary>
        protected BallsSettings SETTINGS { get; private set; }

        private BallState state;
        /// <summary>
        /// Current ball state. Null by default.
        /// </summary>
        public BallState State
        {
            get => state;
            protected set
            {
                StatesHistory.Add(state);

                state = value;

                OnBallStateChange?.Invoke(this, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public readonly List<BallState> StatesHistory = new List<BallState>();
        /// <summary>
        /// Event invoke after ball state change.
        /// </summary>
        public event EventHandler<BallState> OnBallStateChange;

        /// <summary>
        /// Invoke to construct the ball.
        /// </summary>
        public virtual void Construct(BallsSettings settings)
        {
            if (SETTINGS != null)
                return;

            SETTINGS = settings != null ? settings : throw new ArgumentNullException(nameof(settings));
        }

        protected abstract void Move();
    }
}