using System;
using System.Collections.Generic;
using System.Text;
using dotenv.net;

namespace Gribouillage.Models
{
    static class FirebaseToken
    {

    public FirebaseToken(){
      DotEnv.Config(true, "../../.env");
    }

        /// <summary>
        /// APIキー
        /// </summary>
    public static string ApiKey => Environment.GetEnvironmentVariable("ApiKey");

        /// <summary>
        /// 認証ドメイン
        /// </summary>
    public static string AuthDomain => Environment.GetEnvironmentVariable("AuthDomain");

        /// <summary>
        /// データベースのURL
        /// </summary>
    public static string DatabaseUrl => Environment.GetEnvironmentVariable("DatabaseUrl");

        /// <summary>
        /// ストレージバケット
        /// </summary>
    public static string StorageBucket => Environment.GetEnvironmentVariable("StorageBucket");

    }
}
