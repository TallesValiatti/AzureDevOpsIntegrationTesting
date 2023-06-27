namespace  App.Api.Services.Template;
using RazorEngineCore;

public class TemplateService : ITemplateService
{
       public string GetTemplateAsString(string templateName, object model)
       {
              var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, templateName);
            
              IRazorEngine razorEngine = new RazorEngine();
              IRazorEngineCompiledTemplate template = razorEngine.Compile(File.ReadAllText(path));

            return template.Run(model);
       }
}