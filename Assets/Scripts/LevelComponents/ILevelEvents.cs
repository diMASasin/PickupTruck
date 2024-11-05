using System;

namespace LevelComponents
{
    public interface ILevelEvents
    {
        public event Action LevelComplete;
    }
}