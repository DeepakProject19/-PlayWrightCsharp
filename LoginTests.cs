using Microsoft.Playwright;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class LoginTests
{
    private IPage? _page;

    [SetUp]
    public async Task SetUp()
    {
        if (PlaywrightFixture.Browser == null) throw new Exception("Browser is not initialized.");
        _page = await PlaywrightFixture.Browser.NewPageAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        if (_page != null)
        {
            await _page.CloseAsync();
        }
    }

    [Test]
    public async Task Login_Success()
    {
        if (_page == null) throw new Exception("Page is not initialized.");
        await _page.GotoAsync("https://www.saucedemo.com/");
        await _page.FillAsync("#user-name", "standard_user");
        await _page.FillAsync("#password", "secret_sauce");
        await _page.ClickAsync("#login-button");
        await _page.WaitForURLAsync("https://www.saucedemo.com/inventory.html");
        var pageTitle = await _page.TitleAsync();
        Assert.That(pageTitle, Is.EqualTo("Swag Labs"));
    }
}