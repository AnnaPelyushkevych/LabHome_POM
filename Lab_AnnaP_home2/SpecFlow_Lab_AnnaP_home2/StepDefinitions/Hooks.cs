using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowRozetkaTest.StepDefinitions
{
    [Binding]
    class Hooks
    {
        static ExtentReports extent;
        static ExtentTest feature;
        ExtentTest scenario, step;
        static string reportpath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar
            + "\\report.html";

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var htmlreport = new ExtentV3HtmlReporter(reportpath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlreport);
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario(ScenarioContext context, FeatureContext context1)
        {
            feature = extent.CreateTest("Test Feature");
            scenario = feature.CreateNode("Test Scenario");

        }
        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }
        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}
