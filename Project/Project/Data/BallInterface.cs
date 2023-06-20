using System.Numerics;

namespace Data
{
    public interface BallInterface : IDisposable
    {
        int Id { get; }
        int Diameter { get; }


        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }

        float X { get; }
        float Y { get; }

        int Mass { get; }

        event EventHandler? BallChanged;
    }
}
