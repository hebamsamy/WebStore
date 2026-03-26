using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EmptyMVC.Helper.TagHelpers
{
    public class FileLengthAttribute : ValidationAttribute
    {
        public int Count { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFileCollection  formFiles = value as IFormFileCollection;
            if (formFiles != null) { 
                if(formFiles.Count >= Count)
                    return ValidationResult.Success;
                else return new ValidationResult($"Must Add At least Provide {Count} images");
                
            }

            return new ValidationResult($"Must Add At least Provide {Count} images");
        }
    }
}
