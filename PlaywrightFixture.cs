using Microsoft.Playwright;
using System.Threading.Tasks;
using NUnit.Framework;

[SetUpFixture]
public class PlaywrightFixture
{
    public static IPlaywright? Playwright { get; private set; }
    public static IBrowser? Browser { get; private set; }

    [OneTimeSetUp]
    public async Task InitializeAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
    }

    [OneTimeTearDown]
    public async Task DisposeAsync()
    {
        if (Browser != null)
        {
            await Browser.CloseAsync();
        }
        if (Playwright != null)
        {
            Playwright.Dispose();
        }
    }
}