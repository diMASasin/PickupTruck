using System;

namespace LevelComponents
{
    public class Level : IDisposable, ILevelEvents
    {
        private readonly EndCondition _endCondition;

        public event Action LevelComplete;

        public Level(EndCondition endCondition)
        {
            _endCondition = endCondition;
            _endCondition.End += OnEnd;
        }

        public void Dispose()
        {
            _endCondition.End -= OnEnd;
        }

        private void OnEnd()
        {
            LevelComplete?.Invoke();
        }
    }
}