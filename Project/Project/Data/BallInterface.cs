using System.Numerics;

namespace Data
{
    public interface BallInterface : IDisposable
    {
        int id { get; }
        int diameter { get; }


        Vector2 position { get; }
        Vector2 velocity { get; }

        int mass { get; }

        event EventHandler? BallChanged;
    }
}
