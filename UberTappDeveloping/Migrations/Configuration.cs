namespace UberTappDeveloping.Migrations
{
    using System;
	using System.Collections.Generic;
	using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using UberTappDeveloping.Models;

	internal sealed class Configuration : DbMigrationsConfiguration<UberTappDeveloping.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UberTappDeveloping.DAL.ApplicationDbContext context)
        {
            //var beers = new List<Beer>
            //{
            //    new Beer {Name = "Buzz",  Description= "A light, crisp and bitter IPA brewed with English and American hops. A small batch brewed only once.", ABV = 4.5, IBU= 60, EBC = 20},
            //    new Beer {Name = "Trashy Blonde",  Description= "A titillating, neurotic, peroxide punk of a Pale Ale. Combining attitude, style, substance, and a little bit of low self esteem for good measure; what would your mother say? The seductive lure of the sassy passion fruit hop proves too much to resist. All that is even before we get onto the fact that there are no additives, preservatives, pasteurization or strings attached. All wrapped up with the customary BrewDog bite and imaginative twist.", ABV = 4.1, IBU= 41, EBC = 15},
            //    new Beer {Name = "Berliner Weisse With Yuzu - B-Sides",  Description= "Japanese citrus fruit intensifies the sour nature of this German classic.", ABV = 4.2, IBU= 8, EBC = 8},
            //    new Beer {Name = "Pilsen Lager",  Description= "Our Unleash the Yeast series was an epic experiment into the differences in aroma and flavour provided by switching up your yeast. We brewed up a wort with a light caramel note and some toasty biscuit flavour, and hopped it with Amarillo and Centennial for a citrusy bitterness. Everything else is down to the yeast. Pilsner yeast ferments with no fruity esters or spicy phenols, although it can add a hint of butterscotch.", ABV = 6.3, IBU= 55, EBC = 30},
            //    new Beer {Name = "Avery Brown Dredge",  Description= "An Imperial Pilsner in collaboration with beer writers. Tradition. Homage. Revolution. We wanted to showcase the awesome backbone of the Czech brewing tradition, the noble Saaz hop, and also tip our hats to the modern beers that rock our world, and the people who make them.", ABV = 7.2, IBU= 59, EBC = 10},
            //    new Beer {Name = "Electric India",  Description= "Re-brewed as a spring seasonal, this beer – which appeared originally as an Equity Punk shareholder creation – retains its trademark spicy, fruity edge. A perfect blend of Belgian Saison and US IPA, crushed peppercorns and heather honey are also added to produce a genuinely unique beer.", ABV = 5.2, IBU= 38, EBC = 15},
            //    new Beer {Name = "AB:12",  Description= "An Imperial Black Belgian Ale aged in old Invergordon Scotch whisky barrels with mountains of raspberries, tayberries and blackberries in each cask. Decadent but light and dry, this beer would make a fantastic base for ageing on pretty much any dark fruit - we used raspberries, tayberries and blackberries beause they were local.", ABV = 11.2, IBU= 35, EBC = 80},
            //    new Beer {Name = "Fake Lager",  Description= "Fake is the new black. Fake is where it is at. Fake Art, fake brands, fake breasts, and fake lager. We want to play our part in the ugly fallout from the Lager Dream. Say hello to Fake Lager – a zesty, floral 21st century faux masterpiece with added BrewDog bitterness.", ABV = 4.7, IBU= 40, EBC = 12},
            //    new Beer {Name = "AB:07",  Description= "Whisky cask-aged imperial scotch ale. Beer perfect for when the rain is coming sideways. Liquorice, plum and raisin temper the warming alcohol, producing a beer capable of holding back the Scottish chill.", ABV = 12.5, IBU= 30, EBC = 84},
            //    new Beer {Name = "Bramling X",  Description= "Good old Bramling Cross is elegant, refined, assured, (boring) and understated. Understated that is unless you hop the living daylights out of a beer with it. This is Bramling Cross re-invented and re-imagined, and shows just what can be done with English hops if you use enough of them. Poor Bramling Cross normally gets lost in a woeful stream of conformist brown ales made by sleepy cask ale brewers. But not anymore. This beer shows that British hops do have some soul, and is a fruity riot of blackberries, pears, and plums. Reminds me of the bramble, apple and ginger jam my grandmother used to make.", ABV = 7.5, IBU= 75, EBC = 22},
            //    new Beer {Name = "Misspent Youth",  Description= "The brainchild of our small batch brewer, George Woods. A dangerously drinkable milk sugar- infused Scotch Ale.", ABV = 7.3, IBU= 30, EBC = 120},
            //    new Beer {Name = "Arcade Nation",  Description= "Running the knife-edge between an India Pale Ale and a Stout, this particular style is one we truly love. Black IPAs are a great showcase for the skill of our brew team, balancing so many complex and twisting flavours in the same moment. The citrus, mango and pine from the hops – three of our all-time favourites – play off against the roasty dryness from the malt bill at each and every turn.", ABV = 5.3, IBU= 60, EBC = 200},
            //    new Beer {Name = "Movember",  Description= "A deliciously robust, black malted beer with a decadent dark, dry cocoa flavour that provides an enticing backdrop to the Cascade hops.", ABV = 4.5, IBU= 50, EBC = 140},
            //    new Beer {Name = "Alpha Dog",  Description= "A fusion of caramel malt flavours and punchy New Zealand hops. A session beer you can get your teeth into.", ABV = 4.5, IBU= 42, EBC = 62},
            //    new Beer {Name = "Mixtape 8",  Description= "This recipe is for the Belgian Tripel base. A blend of two huge oak aged beers – half a hopped up Belgian Tripel, and half a Triple India Pale Ale. Both aged in single grain whisky barrels for two years and blended, each beer brings its own character to the mix. The Belgian Tripel comes loaded with complex spicy, fruity esters, and punchy citrus hop character.", ABV = 14.5, IBU= 50, EBC = 40},
            //    new Beer {Name = "Libertine Porter",  Description= "An avalanche of cross-continental hop varieties give this porter a complex spicy, resinous and citrusy aroma, with a huge malt bill providing a complex roasty counterpoint. Digging deeper into the flavour draws out cinder toffee, bitter chocolate and hints of woodsmoke.", ABV = 6.1, IBU= 45, EBC = 219},
            //    new Beer {Name = "AB:06",  Description= "Our sixth Abstrakt, this imperial black IPA combined dark malts with a monumental triple dry-hop, using an all-star team of some of our favourite American hops. Roasty and resinous.", ABV = 11.2, IBU= 150, EBC = 70},
            //    new Beer {Name = "Russian Doll – India Pale Ale",  Description= "The levels of hops vary throughout the range. We love hops, so all four beers are big, bitter badasses, but by tweaking the amount of each hop used later in the boil and during dry- hopping, we can balance the malty backbone with some unexpected flavours. Simcoe is used in the whirlpool for all four beers, and yet still lends different characters to each", ABV = 6, IBU = 70, EBC = 25},
            //    new Beer {Name = "Hello My Name Is MetteMarit",  Description= "A light, crisp and bitter IPA brewed with English and American hops. A small batch brewed only once.", ABV = 8.2, IBU= 70},
            //    new Beer {Name = "Rabiator",  Description= "Imperial Wheat beer / Weizenbock brewed by a homesick German in leather trousers. Think banana bread, bubble gum and David Hasselhoff.", ABV = 10.27, IBU= 26, EBC = 24},
            //    new Beer {Name = "Vice Bier",  Description= "Our take on the classic German Kristallweizen. A clear German wheat beer, layers of bubblegum and vanilla perfectly balanced with the American and New Zealand hops.", ABV = 4.3, IBU= 25, EBC = 30},
            //    new Beer {Name = "Devine Rebel (w/ Mikkeller)",  Description= "Two of Europe's most experimental, boundary-pushing brewers, BrewDog and Mikkeller, combined forces to produce a rebellious beer that combined their respective talents and brewing skills. The 12.5% Barley Wine fermented well, and the champagne yeast drew it ever closer to 12.5%. The beer was brewed with a single hop variety and was going to be partially aged in oak casks.", ABV = 12.5, IBU = 100, EBC = 36},
            //    new Beer {Name = "Storm",  Description= "Dark and powerful Islay magic infuses this tropical sensation of an IPA. Using the original Punk IPA as a base, we boosted the ABV to 8% giving it some extra backbone to stand up to the peated smoke imported directly from Islay.", ABV = 8, IBU= 60, EBC = 12},
            //    new Beer {Name = "The End Of History",  Description= "The End of History: The name derives from the famous work of philosopher Francis Fukuyama, this is to beer what democracy is to history. Complexity defined. Floral, grapefruit, caramel and cloves are intensified by boozy heat.", ABV = 55},
            //    new Beer {Name = "Bad Pixie",  Description= "2008 Prototype beer, a 4.7% wheat ale with crushed juniper berries and citrus peel.", ABV = 4.7, IBU= 45, EBC = 8}
            //};


            //beers.ForEach(b => context.Beers.AddOrUpdate(kv => kv.Name, b));
            //context.SaveChanges();
        }
    }
}
