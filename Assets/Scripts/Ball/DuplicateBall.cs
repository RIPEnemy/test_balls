using UnityEngine;

namespace Game
{
    public class DuplicateBall : Ball
    {
        // Overall duplicate balls reference to player
        protected static PlayerBall PLAYER;

        private int stateIndex = -1;

        public override void Construct(BallsSettings settings)
        {
            base.Construct(settings);

            if (PLAYER != null)
                return;

            CachePlayer();
        }

        private void Update()
        {
            stateIndex++;

            SimulateState();
        }

        protected override void Move()
        {
            transform.position = State.Position;
        }

        private void SimulateState()
        {
            State = PLAYER.StatesHistory[stateIndex];

            Move();
        }

        protected void CachePlayer()
        {
            PLAYER = FindObjectOfType<PlayerBall>();
        }
    }
}