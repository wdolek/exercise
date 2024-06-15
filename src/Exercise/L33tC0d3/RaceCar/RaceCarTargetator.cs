using System;
using System.Collections.Generic;

namespace Exercise.L33tC0d3.RaceCar;

// https://leetcode.com/problems/race-car/ (818)
// (based on available solution)
public class RaceCarTargetator
{
    public int Racecar(int target)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(target, 10_000, nameof(target));

        // BFS: Enqueue initial state (position = 0), then add possible moves with each "level"
        var steps = new Queue<StepState>();
        steps.Enqueue(new StepState(0, 1, 0));

        var visited = new HashSet<State>();

        while (steps.Count > 0)
        {
            var current = steps.Dequeue();
            if (current.Position == target)
            {
                return current.Steps;
            }

            // try adding to visited set, if visited, skip
            if (!visited.Add(current))
            {
                continue;
            }

            // Accelerate always - even if we are already after the target
            var accelerated = current.Accelerate();
            steps.Enqueue(accelerated);

            // Reverse only if the car is moving away from the target
            // (NB! We compare the position of the car after acceleration intentionally - it might already have speed `-1`)
            if ((accelerated.IsBeyondTarget(target) && current.IsMovingForward())
                || (accelerated.IsBeforeTarget(target) && !current.IsMovingForward()))
            {
                var reversed = current.Reverse();
                steps.Enqueue(reversed);
            }
        }

        return -1;
    }

    private record State(int Position, int Speed);

    private record StepState(int Position, int Speed, int Steps) : State(Position, Speed)
    {
        public StepState Accelerate() => new(
            Position + Speed,
            Speed * 2,
            Steps + 1);

        public StepState Reverse() => new(
            Position,
            Speed > 0 ? -1 : 1,
            Steps + 1);

        public bool IsMovingForward() => Speed > 0;

        public bool IsBeforeTarget(int target) => Position < target;
        public bool IsBeyondTarget(int target) => Position > target;
    }
}
