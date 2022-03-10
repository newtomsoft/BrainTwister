namespace LaserBrainTwister.UI.Blazor.Tests;
public class LaserTests
{
    [Fact]
    public void DisableCoordinate()
    {
        using var testContext = new TestContext();
        var jsrMock = new Mock<IJSRuntime>();
        testContext.Services.AddSingleton(jsrMock.Object);
        var component = testContext.RenderComponent<Laser>();

        const string btnId = "#btn0_0";
        var btn = component.Find(btnId);
        btn.ClassName!.ShouldContain(Laser.BtnDisable);
        btn.ClassName!.ShouldNotContain(Laser.BtnEnabled);

        btn.Click();
        btn.ClassName!.ShouldContain(Laser.BtnEnabled);
        btn.ClassName!.ShouldNotContain(Laser.BtnDisable);
    }

    [Fact]
    public void Test1()
    {
        using var testContext = new TestContext();
        var jsrMock = new Mock<IJSRuntime>();
        testContext.Services.AddSingleton(jsrMock.Object);
        var component = testContext.RenderComponent<Laser>();

        component.Find("#btn0_0").Click();
        component.Find("#btn1_0").Click();
        component.Find("#btn1_1").Click();

        component.Find("#generateTwoWayTree").Click();
        var canvas = component.Find("#canvas");

        //cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
    }
}