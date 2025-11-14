using AppMAUIGallery.Models;
using AppMAUIGallery.Views.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Repository
{
    internal class CategoryRepository
    {
        public CategoryRepository() { }
        public List<Models.Category> GetCategories()
        {
            List<Category>categories = new List<Category>();
            categories.Add(new Category
            {
                Name = "Layout",
                Components = new List<Models.Component>
                {
                    new Models.Component {
                        Title = "StackLayout",
                        Description = "Organização sequencial dos elementos",
                        Page = typeof(StackLayoutPage)
                    },
                    new Models.Component {
                        Title = "Grid",
                        Description = "Organização os elementos dentro de uma tabela",
                        Page = typeof(GridLayoutPage)
                    }
                }
            });
            return categories;
        }
    }
}
