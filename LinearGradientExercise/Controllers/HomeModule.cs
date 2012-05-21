using LinearGradientExercise.Models;
using LinearGradientExercise.Svg;
using LinearGradientExercise.Validators;
using Nancy;

namespace LinearGradientExercise.Controllers
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            var colorValidator = new ColorValidator();
            var verticalLinearGradientFactory = new VerticalLinearGradientFactory();


            Get["/"] = x => { return View["index"]; };

            Get["/verticalLinearGradient/{selectedColor}"] = x =>
                                    {
                                        string selectedColor = (string)x.selectedColor;
                                        if (!colorValidator.IsHexadecimalRgbColor(selectedColor))
                                        {
                                            return 500;
                                        }

                                        Color color = new Color(selectedColor);

                                        var model = verticalLinearGradientFactory.CreateSvgStops(color);

                                        return View["verticalLinearGradient", model]
                                            .WithContentType("image/svg+xml");
                                    };
        }
    }
}