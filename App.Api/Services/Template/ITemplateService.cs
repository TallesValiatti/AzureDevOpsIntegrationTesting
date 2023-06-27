namespace  App.Api.Services.Template;

public interface ITemplateService
{
   public string GetTemplateAsString(string templateName, object model);
}