
using System;
public class RecipeApp
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }

        public Recipe(string name, List<Ingredient> ingredients, string instructions)
        {
            Name = name;
            Ingredients = ingredients;
            Instructions = instructions;
        }
    }

    private List<Recipe> recipes;

    public RecipeApp()
    {
        recipes = new List<Recipe>();
    }

    public void AddRecipe(Recipe recipe)
    {
        recipes.Add(recipe);
    }

    public List<Recipe> FindRecipes(string searchTerm)
    {
        return recipes.Where(r => r.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
    }

    public Recipe GetRecipe(string name)
    {
        return recipes.FirstOrDefault(r => r.Name.Equals(name));
    }

    public static void Main(string[] args)
    {
        var recipeApp = new RecipeApp();

        // Defining the Ingredient
        var ingredient1 = new RecipeApp.Ingredient("Flour", 2.0, "cups");
        var ingredient2 = new RecipeApp.Ingredient("Eggs", 3, "pcs");
        var ingredients = new List<RecipeApp.Ingredient>() { ingredient1, ingredient2 };

        var recipe = new RecipeApp.Recipe("Pancakes", ingredients, "Mix ingredients, cook on pan...");

        recipeApp.AddRecipe(recipe);

        // Search and retrieve pancake
        var foundRecipes = recipeApp.FindRecipes("pancake");
        if (foundRecipes.Any())
        {
            Console.WriteLine("Found Recipes:");
            foreach (Recipe var in foundRecipes)
            {
                Console.WriteLine($"- {recipe.Name}");
            }
        }
        else
        {
            Console.WriteLine("No recipes found for your search term.");
        }

        var retrievedRecipe = recipeApp.GetRecipe("Pancakes");
        if (retrievedRecipe != null)
        {
            Console.WriteLine($"\nRecipe Details for {retrievedRecipe.Name}:");
            Console.WriteLine($"  Ingredients:");
            foreach (var ingredient in retrievedRecipe.Ingredients)
            {
                Console.WriteLine($"    - {ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }
            Console.WriteLine($"  Instructions: {retrievedRecipe.Instructions}");
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }
}