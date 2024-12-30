using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BankingSystem.Api.Application.Models;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class FromHeaderModelAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
{
    public BindingSource BindingSource => BindingSource.Query;
    public string Name { get; set; }
}
