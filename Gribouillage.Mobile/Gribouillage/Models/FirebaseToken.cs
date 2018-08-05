using System;
using System.Collections.Generic;
using System.Text;

namespace Gribouillage.Models
{
  public static class FirebaseToken
  {
    /// <summary>
    /// API Key
    /// </summary>
    public static string ApiKey => Environment.GetEnvironmentVariable("FirebaseApiKey");

    /// <summary>
    /// Auth Domain
    /// </summary>
    public static string AuthDomain => Environment.GetEnvironmentVariable("FirebaseAuthDomain");

    /// <summary>
    /// Database URL
    /// </summary>
    public static string DatabaseUrl => Environment.GetEnvironmentVariable("FirebaseDatabaseUrl");

    /// <summary>
    /// Storage Bucket
    /// </summary>
    public static string StorageBucket => Environment.GetEnvironmentVariable("FirebaseStorageBucket");

    /// <summary>
    /// Message Sender ID
    /// </summary>
    public static string MessagingSenderId => Environment.GetEnvironmentVariable("FirebaseMessagingSenderId");

  }
}
