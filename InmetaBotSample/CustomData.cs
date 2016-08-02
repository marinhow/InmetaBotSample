using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
#pragma warning disable 649

// The SandwichOrder is the simple form you want to fill out.  It must be serializable so the bot can be stateless.
// The order of fields defines the default order in which questions will be asked.
// Enumerations shows the legal options for each field in the SandwichOrder and the order is the order values will be presented 
// in a conversation.
namespace InmetaBotSample
{
    public enum PizzaOptions
    {
      DEN_ENKLE,KVESS,DRØMMEN,PIZZABAKEREN_SPESIAL,SNADDER,MIX,MEKSIKANEREN,BIFFEN,DEN_MARINERTE,
      PEPPERSVENNEN,FLAMMEN,TACOKYLLINGEN,KOKKENS_KYLLING,KOKKENS_FAVORITT,GNISTEN,LUKSUSKYLLING,
      KYLLINGFARMEN,VEGETARIANEREN,KEBABEN,DRENGEN,MR_X,CHORIZO_SPESIAL,DOBBELDEKKER,HEIT_KYLLING,
      CHORIZOEN,HOTTENTOTTEN
    };
    public enum LengthOptions {[Description("20 cm")]small, [Description("30 cm")]medium, [Description("40 cm")]large};
    public enum BreadOptions { NineGrainWheat, NineGrainHoneyOat, Italian, ItalianHerbsAndCheese, Flatbread };
    public enum CheeseOptions { American, MontereyCheddar, Pepperjack };
    public enum ToppingOptions
    {
        Avocado, Cucumbers, Jalapenos,
        Lettuce, Olives, Pickles, RedOnion, Spinach, Tomatoes
    };
    public enum SauceOptions
    {
        Garlic, HoneyMustard, Mayonnaise,
        Mustard, Oil, Pepper
    };

    //public class GetCustomDataFromXML
    //{
    //    public GetCustomDataFromXML()
    //    {
    //        Dictionary<int, string> Options1 = new Dictionary<int, string>();
    //        Options1.Add(1, "limao");

    //        PizzaOptions = Options1;
    //    }
    //}

    [Serializable]
    public class SandwichOrder
    {
        public PizzaOptions? Pizza;
        public LengthOptions? Size;
        public BreadOptions? Bread;
        public CheeseOptions? Cheese;
        public List<ToppingOptions> Toppings;
        public List<SauceOptions> Sauce;

        public static IForm<SandwichOrder> BuildForm()
        {
            return new FormBuilder<SandwichOrder>()
                    .Message("Welcome to the PIZZABAKEREN order bot!")
                    .Build();
        }
    };
}