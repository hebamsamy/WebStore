using EmptyMVC.Helper.TagHelpers;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddProductViewModel
    {
        [Required (ErrorMessage ="Must add Product Name")]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]
        [Range(1, 100000)]
        public decimal Price { get; set; }
        [Required]
        [Display(Name ="Aviable Items")]
        public int Stock { get; set; }


        public int ProviderID { get; set; } = 1;
        [Required]
        [Display(Name = "Choose Product Catagory")]
        public int CategoryID { get; set; }

        [Display(Name = "Select Product Image")]
        //[Required(ErrorMessage ="Must Add At least 2 images")]

        [FileLength(Count =2)]
        public IFormFileCollection Attachment { get; set; }
        public List<string> ImagePaths { get; set; } = new();

        //input type file muitple

    }
}
