using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APIRegistro.Controllers;
using APIRegistro.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace admRegistro.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetPrueba()
        {
            //Arrange
            RegistroesController registroesController = new RegistroesController();
            //Act
            var ListaPrueba = registroesController.GetRegistroes();
            //Asser
            Assert.IsNotNull(ListaPrueba);
        }
        [TestMethod]
        public void TestPostPrueba()
        {
            //Arrange
            RegistroesController registroesController = new RegistroesController();
            Registro registroesperado = new Registro()
            {
                FriendofSalmon = "Adriana Salmon",
                SalmonID = 1,
                Email = "a2019116341@estudiantes.upsa.edu.bo",
                Birthdate = DateTime.Today,
                Place = CategoryType.Administrativo
            };
            //Act
            IHttpActionResult actionResult = registroesController.PostRegistro(registroesperado);
            var PruebaActual = actionResult as CreatedAtRouteNegotiatedContentResult<Registro>;
            //Asser
            Assert.IsNotNull(PruebaActual);
            Assert.AreEqual("DefaulApi", PruebaActual.RouteName);
            Assert.AreEqual(registroesperado.FriendofSalmon, PruebaActual.Content.FriendofSalmon);
            Assert.AreEqual(registroesperado.Email, PruebaActual.Content.Email);
            Assert.AreEqual(registroesperado.Birthdate, PruebaActual.Content.Birthdate);
            Assert.AreEqual(registroesperado.Place, PruebaActual.Content.Place);
        }

        [TestMethod]
        public void TestDeletePrueba()
        {
            //Arrange
            RegistroesController registroesController = new RegistroesController();
            Registro registroesperado = new Registro()
            {
                FriendofSalmon = "Adriana Salmon",
                SalmonID = 1,
                Email = "a2019116341@estudiantes.upsa.edu.bo",
                Birthdate = DateTime.Today,
                Place = CategoryType.Administrativo
            };
            //Act
            IHttpActionResult actionResult = registroesController.DeleteRegistro(registroesperado.SalmonID);
            //Asser
            Assert.IsNotInstanceOfType(actionResult, typeof(OkResult));
        }
        [TestMethod]
        public void TestPutPrueba()
        {
            //Arrange
            RegistroesController registroesController = new RegistroesController();
            Registro registroesperado = new Registro()
            {
                FriendofSalmon = "Adriana Salmon",
                SalmonID = 1,
                Email = "a2019116341@estudiantes.upsa.edu.bo",
                Birthdate = DateTime.Today,
                Place = CategoryType.Administrativo
            };
            string newname = "Fernanda Salmon";
            //Act
            var actionResult = registroesController.PostRegistro(registroesperado);
            registroesperado.FriendofSalmon = newname;
            var actionResultPut = registroesController.PutRegistro(registroesperado.SalmonID, registroesperado) as StatusCodeResult;
            //Asser
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.NoContent, actionResultPut.StatusCode);
            Assert.IsInstanceOfType(actionResultPut, typeof(StatusCodeResult));
        }
    }
}
