using Microsoft.Playwright;
using System.Threading.Tasks;
using Xunit;

public class LoginTests : IClassFixture<PlaywrightFixture>
{
    private readonly IPlaywright? _playwright;
    private readonly IBrowser? _browser;

    public LoginTests(PlaywrightFixture fixture)
    {
        _playwright = fixture.Playwright;
        _browser = fixture.Browser;
    }

    [Fact]
    public async Task Login_Success()
    {
        if (_browser == null) throw new Exception("Browser is not initialized.");
        var page = await _browser.NewPageAsync();
        await page.GotoAsync("https://www.saucedemo.com/");
        await page.FillAsync("#user-name", "standard_user");
        await page.FillAsync("#password", "secret_sauce");
        await page.ClickAsync("#login-button");
        await page.WaitForURLAsync("https://www.saucedemo.com/inventory.html");
        var pageTitle = await page.TitleAsync();
        Assert.Equal("Swag Labs", pageTitle);
    }
}