using System;
using Nancy;

namespace LinearGradientExerciseTests.IntegrationTests
{
    public class CustomPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            var assd = Environment.CurrentDirectory;

            return @"..\..\..\LinearGradientExercise";
        }
    }
}
