using CookiesCookBook.Recipes;
using CookiesCookBook.Recipes.Ingredients;

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(),
    new RecipesConsoleUserInteraction());

cookiesRecipesApp.Run("recipes.txt");


public class CookiesRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(
        IRecipesRepository recipesRepository,
        IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        // _recipesUserInteraction.PromptToCreateRecipe();
        //
        // var ingredients = _recipesUserInteraction.ReadIngredientsFromUser;
        //
        // if (ingredients.Count > 0)
        // {
        //     var recipe = new Recipe(ingredients);
        //     allRecipes.Add(recipe);
        //     _recipesRepository.Write(filePath, allRecipes);
        //
        //     _recipesUserInteraction.ShowMessage($"Recipe added: {recipe.ToString()}");
        //     // _recipesUserInteraction.ShowMessage(recipe.ToString());
        // }
        // else
        // {
        //     _recipesUserInteraction.ShowMessage(
        //         "No ingredients have been selected. Recipe will not be saved");
        // }

        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close");
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Any())
        {
            Console.WriteLine($"Existing recipes are: {Environment.NewLine}");

            var counter = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"*****{counter}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                counter++;
            }
        }
    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(object filePath);
}

public class RecipesRepository : IRecipesRepository
{
    public List<Recipe> Read(object filePath)
    {
        return new List<Recipe>
        {
            new Recipe(new List<Ingredient>
            {
                new WheatFlour(),
                new Butter(),
                new Sugar()
            }),
            new Recipe(new List<Ingredient>
            {
                new CocoaPowder(),
                new SpeltFlour(),
                new Cinnamon()
            })
        };
    }
}