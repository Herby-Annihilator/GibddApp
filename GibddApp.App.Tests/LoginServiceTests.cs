using GibddApp.App.Exceptions;
using GibddApp.App.Interfaces;
using GibddApp.App.Services;
using GibddApp.App.Tests.TestMiddleware;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace GibddApp.App.Tests
{
    [TestClass]
    public class LoginServiceTests
    {
        // arrange - подготовка данных
        // act - запуск тестируемого метода
        // assert - проверка результата

        // TestMethodName - <Название тестируемого метода>_<условия>_<результат>

        [TestMethod]
        public void Login_AccountIsAlreadyExistsInSessionPool_ShouldThrowLoginServiceException()
        {
            //
            // arrange
            //
            IDataStorage storage = new TestDataStorage();
            LoginService loginService = new LoginService(storage, Privilege.All);
            loginService.Login("user1", "123").Wait();
            //
            // act
            //

            //
            // assert
            //
            Assert.ThrowsExceptionAsync<LoginServiceException>(() => loginService.Login("user1", "123"));
        }

        [TestMethod]
        public void Login_ThereIsNoSuchAccount_ShouldThrowLoginServiceException()
        {
            //
            // arrange
            //
            IDataStorage storage = new DataStorageReturnsNullAccount();
            LoginService loginService = new LoginService(storage, Privilege.All);
            //
            // act
            //

            //
            // assert
            //
            Assert.ThrowsExceptionAsync<LoginServiceException>(() => loginService.Login("user1", "123"));
        }
    }
}