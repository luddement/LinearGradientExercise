using System;
using Nancy;

namespace LinearGradientExerciseTests.Setup
{
    /// <summary>
    /// To run the nancy integration tests we need to specify the root directory for the viewengine to find the views.
    /// </summary>
    public class CustomPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            var currentDirectory = Environment.CurrentDirectory;

            return @"..\..\..\LinearGradientExercise";
        }
    }
}
