using les70.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using Xunit;

public class HomeControllerTestPageTests
{
    private readonly HomeController _controller = new HomeController();

    [Fact]
    public void TestPage_ReturnsViewResult()
    {
        var result = _controller.TestPage(0);

        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void TestPage_UsesDefaultView()
    {
        var result = _controller.TestPage(0) as ViewResult;

        Assert.NotNull(result);
        Assert.Null(result.ViewName);
    }

    [Fact]
    public void TestPage_ReturnsTestPageViewModel()
    {
        var result = _controller.TestPage(0) as ViewResult;

        Assert.NotNull(result);
        Assert.NotNull(result.Model);
        Assert.IsType<TestPageViewModel>(result.Model);
    }

    [Fact]
    public void TestPage_ZeroInput_ModelPageIsOne()
    {
        var result = (ViewResult)_controller.TestPage(0);
        var model = Assert.IsType<TestPageViewModel>(result.Model);

        Assert.Equal(1, model.Page);
    }

    [Fact]
    public void TestPage_PositiveInput_ModelPageIsIncremented()
    {
        var result = (ViewResult)_controller.TestPage(41);
        var model = Assert.IsType<TestPageViewModel>(result.Model);

        Assert.Equal(42, model.Page);
    }

    [Fact]
    public void TestPage_NegativeInput_ModelPageIsIncremented()
    {
        var result = (ViewResult)_controller.TestPage(-10);
        var model = Assert.IsType<TestPageViewModel>(result.Model);

        Assert.Equal(-9, model.Page);
    }

    [Fact]
    public void TestPage_SetsPageIncrementInViewBag()
    {
        var result = (ViewResult)_controller.TestPage(7);

        Assert.Equal(8, (int)result.ViewData["PageIncrement"]);
    }

    [Fact]
    public void TestPage_ViewBagValueEqualsModelPage()
    {
        var result = (ViewResult)_controller.TestPage(3);
        var model = Assert.IsType<TestPageViewModel>(result.Model);

        Assert.Equal(model.Page, (int)result.ViewData["PageIncrement"]);
    }
}