using Microsoft.Playwright;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;

[Binding]
public class LoginSteps
{
    private IPage? _page;

    [BeforeScenario]
    public async Task SetUp()
    {
        if (PlaywrightFixture.Browser == null) throw new Exception("Browser is not initialized.");
        _page = await PlaywrightFixture.Browser.NewPageAsync();
    }

    [AfterScenario]
    public async Task TearDown()
    {
        if (_page != null)
        {
            await _page.CloseAsync();
        }
    }

    [Given(@"I am on the SauceDemo login page")]
    public async Task GivenIAmOnTheSauceDemoLoginPage()
    {
        if (_page == null) throw new Exception("Page is not initialized.");
        await _page.GotoAsync("https://www.saucedemo.com/");
    }

    [When(@"I enter ""(.*)"" as username and ""(.*)"" as password")]
    public async Task WhenIEnterAsUsernameAndAsPassword(string username, string password)
    {
        if (_page == null) throw new Exception("Page is not initialized.");
        await _page.FillAsync("#user-name", username);
        await _page.FillAsync("#password", password);
    }

    [When(@"I click the login button")]
    public async Task WhenIClickTheLoginButton()
    {
        if (_page == null) throw new Exception("Page is not initialized.");
        await _page.ClickAsync("#login-button");
    }

    [Then(@"I should be on the products page")]
    public async Task ThenIShouldBeOnTheProductsPage()
    {
        if (_page == null) throw new Exception("Page is not initialized.");
        await _page.WaitForURLAsync("https://www.saucedemo.com/inventory.html");
        var pageTitle = await _page.TitleAsync();
        Assert.That(pageTitle, Is.EqualTo("Swag Labs"));
    }
}