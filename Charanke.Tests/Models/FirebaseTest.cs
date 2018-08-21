using NUnit.Framework;
using System;
using Charanke.Models;
using System.Threading.Tasks;

namespace Charanke.Tests.Models
{
  [TestFixture()]
  public class FirebaseTest
  {
    [Test()]
    public async Task SignUpByEmailAndPasswordAsyncTest()
    {
      var model = new FirebaseModel();
      model.Email = "test@test.com";
      model.Password = "hogehoge";
      await model.SignUpByEmailAndPasswordAsync();
      Assert.AreEqual("ユーザー作成に成功しました。", model.AuthMessage);
    }

    [Test()]
    public async Task SignInByEmailAndPasswordAsyncTest()
    {
      var model = new FirebaseModel();
      model.Email = "test@test.com";
      model.Password = "hogehoge";
      await model.SignInByEmailAndPasswordAsync();
      Assert.AreEqual("サインインに成功しました。", model.AuthMessage);
    }
  }
}
