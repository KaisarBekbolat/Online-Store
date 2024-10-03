using System;
using System.Text.Json;

namespace SporteStore___2nd_try.Infrastructure;

public static class SessionExtensions
{
    public static void SetJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }
    public static T? GetJson<T>(this ISession session, string key)
    {
        var sessionData = session.GetString(key);
        return sessionData == null
        ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
    }

}
