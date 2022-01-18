using System.Collections.Generic;

namespace Trivia
{
    public class Categories
    {
        public readonly string[] Names = { "Pop", "Science", "Sports", "Rock" };
        private readonly Dictionary<int, Category> categories = new Dictionary<int, Category>();

        public Categories()
        {
            CreateCategories();
        }

        private void CreateCategories()
        {
            var i = 0;
            foreach (var category in Names)
            {
                this.categories.Add(i, new Category(category));
                this.categories.Add(i + 4, new Category(category));
                this.categories.Add(i + 8, new Category(category));
                i++;
            }
        }

        public string CurrentCategory(int place)
        {
            return categories.TryGetValue(place, out var category)
                ? category.Name
                : "Rock";
        }

        private class Category
        {
            public string Name { get; private set; }

            public Category(string name)
            {
                this.Name = name;
            }
        }
    }
}