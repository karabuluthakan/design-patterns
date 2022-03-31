#pragma warning disable CS8603
#pragma warning disable CS8618

namespace Structural.Decorator.Caching;

public class RedisCacheProvider : ICacheProvider
{
    private ConnectionMultiplexer _connection;
    private IDatabase _database;
    private readonly SemaphoreSlim _asyncLock;
    private readonly object _lock;
    private readonly string _connectionString;
    private readonly IntPtr _unmanagedPointer;
    private bool _alreadyDisposed;

    public RedisCacheProvider(string connectionString)
    {
        _connectionString = Guard.Against.NullOrEmpty(connectionString?.Trim());
        _unmanagedPointer = Marshal.AllocHGlobal(1000 * 1024 * 1024);
        _asyncLock = new SemaphoreSlim(1, 1);
        _lock = new object();
        Connect();
    }

    public async ValueTask<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        await ConnectAsync(cancellationToken);
        var data = await _database.StringGetAsync(key);
        return data.HasValue
            ? data.ToString().FromJson<T>()
            : default;
    }

    public bool Set(string key, object data, TimeSpan? expiry = null)
    {
        Connect();

        lock (_lock)
        {
            return _database.StringSet(key, data.AsJson(), expiry, When.Always);
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
    }

    ~RedisCacheProvider()
    {
        Dispose(disposing: false);
    }

    private void Dispose(bool disposing)
    {
        if (_alreadyDisposed)
        {
            return;
        }

        if (disposing)
        {
            _connection.Dispose();
            _alreadyDisposed = true;
            Marshal.FreeHGlobal(_unmanagedPointer);
            GC.SuppressFinalize(this);
        }
    }

    private void Connect()
    {
        if (_database is not null)
        {
            return;
        }

        _asyncLock.Wait();

        try
        {
            _connection = ConnectionMultiplexer.Connect(_connectionString);

            _database = _connection.GetDatabase();
        }
        finally
        {
            _asyncLock.Release();
        }
    }

    private async Task ConnectAsync(CancellationToken token = default)
    {
        if (_database is not null)
        {
            return;
        }

        token.ThrowIfCancellationRequested();
        await _asyncLock.WaitAsync(token);

        try
        {
            _connection = await ConnectionMultiplexer.ConnectAsync(_connectionString);
            _database = _connection.GetDatabase();
        }
        finally
        {
            _asyncLock.Release();
        }
    }
}