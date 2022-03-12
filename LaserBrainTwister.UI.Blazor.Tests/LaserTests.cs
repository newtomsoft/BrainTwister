using System.Linq;

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
        btn.ClassName!.ShouldContain(Laser.NodeDisable);
        btn.ClassName!.ShouldNotContain(Laser.NodeEnabled);

        btn.Click();
        btn.ClassName!.ShouldContain(Laser.NodeEnabled);
        btn.ClassName!.ShouldNotContain(Laser.NodeDisable);

        component.Find("#exportGrid").Attributes.Select(a => a.Name).ShouldContain("disabled");
    }

    [Fact]
    public void GridWithBadNodes()
    {
        using var testContext = new TestContext();
        var jsrMock = new Mock<IJSRuntime>();
        testContext.Services.AddSingleton(jsrMock.Object);
        var component = testContext.RenderComponent<Laser>();
        const string btnInErrorId = "#btn5_5";
        component.Find("#btn0_0").Click();
        component.Find("#btn1_0").Click();
        component.Find(btnInErrorId).Click();
        component.Find("#generateTwoWayTree").Click();
        var elementInError = component.Find(btnInErrorId);
        elementInError.ClassName!.ShouldContain(Laser.NodeError);
        component.Find("#exportGrid").Attributes.Select(a => a.Name).ShouldContain("disabled");
    }

    [Fact]
    public void GridWithGoodNodes()
    {
        using var testContext = new TestContext();
        var jsrMock = new Mock<IJSRuntime>();
        testContext.Services.AddSingleton(jsrMock.Object);
        var component = testContext.RenderComponent<Laser>();

        component.Find("#btn0_0").Click();
        component.Find("#btn1_0").Click();
        component.Find("#btn1_1").Click();

        component.Find("#generateTwoWayTree").Click();
        component.Find("#exportGrid").Attributes.Select(a => a.Name).ShouldNotContain("disabled");

        var canvas = component.Find("#canvas");

        //cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
    }
}