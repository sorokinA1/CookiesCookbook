namespace CookiesCookBook.Recipes.Ingredients;

public abstract class Spice : Ingredient
{
    public override string PreparationInstructions => $"Take a half a teaspoon. {base.PreparationInstructions} ";
}