using NUnit.Framework;
using WebsiteAutomate.Utility;

[SetUpFixture]
class GlobalSetup
{
    static public BaseTest bt;

    public GlobalSetup()
    {
        bt = new BaseTest();
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        bt.OneTimeSetUp();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        bt.OneTimeTearDown();
    }
}
