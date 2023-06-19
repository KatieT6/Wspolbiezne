using System.Numerics;

namespace Data
{
    public interface BallInterface : IDisposable
    {
        int Id { get; }
        int Diameter { get; }


        Vector2 Position { get; }
        Vector2 Velocity { get; }

        int Mass { get; }

        event EventHandler? BallChanged;
    }
}
