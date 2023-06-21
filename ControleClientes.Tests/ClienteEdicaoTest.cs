using Bogus;
using Bogus.Extensions.Brazil;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace ControleClientes.Tests
{
    public class ClienteEdicaoTest
    {
        [Fact]
        public void EditarClienteComSucesso()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost:4200/consulta-clientes");

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            var botaoEditar = driver.FindElement(By.XPath("//table/tbody/tr[1]/td[5]/div/button[contains(text(),'Editar')]"));
            botaoEditar.Click();

            var faker = new Faker("pt_BR");

            var nome = driver.FindElement(By.Id("nome"));
            nome.Clear();
            nome.SendKeys($"{faker.Name.FirstName()}");

            var cpf = driver.FindElement(By.Id("cpf"));
            cpf.Clear();
            cpf.SendKeys(string.Join("", faker.Random.Digits(11)));

            var email = driver.FindElement(By.Id("email"));
            email.Clear();
            email.SendKeys(faker.Person.Email);

            var dataNascimento = driver.FindElement(By.Id("dataNascimento"));
            dataNascimento.Clear();
            dataNascimento.SendKeys(faker.Person.DateOfBirth.ToShortDateString());

            var botaoConfirmar = driver.FindElement(By.CssSelector("button[type='submit']"));
            botaoConfirmar.Click();

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            var tituloPagina = driver.FindElement(By.CssSelector("h5.card-title")).Text;
            var resultadoEsperado = "Consulta de Clientes";
            Assert.Equal(resultadoEsperado, tituloPagina);

            driver.Close();
            driver.Quit();
        }
    }
}