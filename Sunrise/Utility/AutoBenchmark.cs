using System.Diagnostics;

namespace Sunrise.Utility;

internal class AutoBenchmark(string targetName, float reportInterval = 10)
{
    readonly Stopwatch _consumedTime = new();
    readonly Stopwatch _totalTime = new();
    int _count;

    static bool Enabled => Config.Instance.Benchmark;

    public void Start()
    {
        if (!Enabled)
            return;

        _consumedTime.Start();
        _totalTime.Start();
    }

    public void Stop()
    {
        if (!Enabled)
            return;

        _consumedTime.Stop();

        if (_totalTime.Elapsed.TotalSeconds >= reportInterval)
            Report();
    }

    void Report()
    {
        double precentage = _consumedTime.Elapsed.TotalSeconds / _totalTime.Elapsed.TotalSeconds;

        var message = $"Time consumed by {targetName} in last {_totalTime.Elapsed.TotalSeconds:F}: {_consumedTime.Elapsed.TotalSeconds:F} ({precentage:P2}).";

        if (_count > 0)
            message += $" Counter: {_count}.";

        Debug.Log(message);

        _consumedTime.Reset();
        _totalTime.Restart();
        _count = 0;
    }

    public void Increment(int amount = 1) => _count += amount;
}