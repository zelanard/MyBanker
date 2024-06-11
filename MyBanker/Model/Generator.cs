using MyBanker.Model.Cards;
using MyBanker.Util;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace MyBanker.Model
{
    /// <summary>
    /// 
    /// </summary>
    public static class Generator
    {
        public static readonly string[] PrefixVisaElectron = { "4026", "417500", "4508", "4844", "4913", "4917" };
        public static readonly string PrefixVisa = "4";
        public static readonly string[] PrefixMasterCard = { "51", "52", "53", "54", "55" };
        public static readonly string[] Prefixmaestro = { "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763" };
        public static readonly string WithdrawalCard = "2400";
        public static readonly string AccountPrefix = "3520";
        public static readonly Dictionary<CardList, float> ExpirationDates = new Dictionary<CardList, float>()
        {
            {CardList.Mastercard, 5f},
            {CardList.VISACard, 5f },
            {CardList.VISAElectronCard, 5f },
            {CardList.MaestroCard, 5+(8/12) },
            {CardList.WithdrawalCard, 0 },
            {CardList.GiftCard, 1 }
        };
        private static readonly string[] FirstNames = { "James", "Mary", "Robert", "Patricia", "John", "Jennifer", "Michael", "Linda", "David", "Elizabeth", "William", "Barbara", "Richard", "Susan", "Joseph", "Jessica", "Charles", "Sarah", "Thomas", "Karen", "Christopher", "Nancy", "Daniel", "Lisa", "Matthew", "Betty", "Anthony", "Margaret", "Mark", "Sandra", "Donald", "Ashley", "Steven", "Kimberly", "Paul", "Emily", "Andrew", "Donna", "Joshua", "Michelle", "Kenneth", "Carol", "Kevin", "Amanda", "Brian", "Dorothy", "George", "Melissa", "Edward", "Deborah", "Ronald", "Stephanie", "Timothy", "Rebecca", "Jason", "Sharon", "Jeffrey", "Laura", "Ryan", "Cynthia", "Jacob", "Kathleen", "Gary", "Amy", "Nicholas", "Angela", "Eric", "Shirley", "Stephen", "Anna", "Jonathan", "Brenda", "Larry", "Pamela", "Justin", "Emma", "Scott", "Nicole", "Brandon", "Helen", "Benjamin", "Samantha", "Samuel", "Katherine", "Gregory", "Christine", "Frank", "Debra", "Alexander", "Rachel", "Raymond", "Carolyn", "Patrick", "Janet", "Jack", "Catherine", "Dennis", "Maria", "Jerry", "Heather", "Tyler", "Diane", "Aaron", "Ruth", "Jose", "Julie", "Adam", "Olivia", "Henry", "Joyce", "Nathan", "Virginia", "Douglas", "Victoria", "Zachary", "Lauren", "Peter", "Kelly", "Kyle", "Christina", "Walter", "Joan", "Ethan", "Evelyn", "Jeremy", "Judith", "Harold", "Megan", "Keith", "Cheryl", "Christian", "Andrea", "Roger", "Hannah", "Noah", "Martha", "Gerald", "Jacqueline", "Carl", "Frances", "Terry", "Gloria", "Sean", "Ann", "Austin", "Teresa", "Arthur", "Sara", "Lawrence", "Janice", "Jesse", "Jean", "Dylan", "Alice", "Bryan", "Madison", "Joe", "Doris", "Jordan", "Abigail", "Billy", "Julia", "Bruce", "Judy", "Albert", "Grace", "Willie", "Denise", "Gabriel", "Amber", "Logan", "Marilyn", "Alan", "Beverly", "Juan", "Danielle", "Wayne", "Rose", "Ralph", "Theresa", "Roy", "Sophia", "Eugene", "Marie", "Randy", "Diana", "Vincent", "Brittany", "Russell", "Natalie", "Louis", "Isabella", "Philip", "Charlotte", "Bobby", "Alexis" };
        private static readonly string[] SurNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores", "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts", "Gomez", "Phillips", "Evans", "Turner", "Diaz", "Parker", "Cruz", "Edwards", "Collins", "Reyes", "Stewart", "Morris", "Morales", "Murphy", "Cook", "Rogers", "Gutierrez", "Ortiz", "Morgan", "Cooper", "Peterson", "Bailey", "Reed", "Kelly", "Howard", "Ramos", "Kim", "Cox", "Ward", "Richardson", "Watson", "Brooks", "Chavez", "Wood", "James", "Bennett", "Gray", "Mendoza", "Ruiz", "Hughes", "Price", "Alvarez", "Castillo", "Sanders", "Patel", "Myers", "Long", "Ross", "Foster", "Jimenez", "Powell", "Jenkins", "Perry", "Russell", "Sullivan", "Bell", "Coleman", "Butler", "Henderson", "Barnes", "Gonzales", "Fisher", "Vasquez", "Simmons", "Romero", "Jordan", "Patterson", "Alexander", "Hamilton", "Graham", "Reynolds", "Griffin", "Wallace", "Moreno", "West", "Cole", "Hayes", "Bryant", "Herrera", "Gibson", "Ellis", "Tran", "Medina", "Aguilar", "Stevens", "Murray", "Ford", "Castro", "Marshall", "Owens", "Harrison", "Fernandez", "McDonald", "Woods", "Washington", "Kennedy", "Wells", "Vargas", "Henry", "Chen", "Freeman", "Webb", "Tucker", "Guzman", "Burns", "Crawford", "Olson", "Simpson", "Porter", "Hunter", "Gordon", "Mendez", "Silva", "Shaw", "Snyder", "Mason", "Dixon", "Munoz", "Hunt", "Hicks", "Holmes", "Palmer", "Wagner", "Black", "Robertson", "Boyd", "Rose", "Stone", "Salazar" };
        private static readonly string[] StoreNames = { "Walmart", "Target", "Costco", "Kroger", "Walgreens", "Home Depot", "CVS", "Lowe's", "Best Buy", "Macy's", "Kohl's", "Dollar General", "Nordstrom", "Sam's Club", "Rite Aid", "BJ's Wholesale Club", "Aldi", "Trader Joe's", "Publix", "Meijer", "Whole Foods Market", "Safeway", "Sprouts Farmers Market", "H-E-B", "Winn-Dixie", "Hy-Vee", "ShopRite", "Food Lion", "Giant Eagle", "Fred Meyer", "Ralphs", "Harris Teeter", "Stop & Shop", "Piggly Wiggly", "Save-A-Lot", "Food 4 Less", "Vons", "Albertsons", "King Soopers", "Jewel-Osco", "ACME Markets", "Shaw's", "Hannaford", "Wegmans", "Stater Bros.", "Giant Food", "Fry's", "Smith's", "QFC", "Bashas'", "Food City", "Price Chopper", "Market Basket", "Schnucks", "Weis Markets", "Festival Foods", "Brookshire's", "Ingles", "Sprout's", "Central Market", "Dierbergs", "Cub Foods", "Lucky Supermarkets", "Raley's", "Nob Hill Foods", "Mariano's", "Fresh Thyme", "Smart & Final", "Fairway Market", "C-Town", "Associated Supermarkets", "Foodtown", "Key Food", "IGA", "Pavilions", "Andronico's", "Mollie Stone's", "Gelson's", "Bristol Farms", "Greenwise Market", "Balducci's", "Kings Food Markets", "Tops Friendly Markets", "Big Y", "Redner's", "Woodman's Markets", "Roche Bros.", "Super One Foods", "Hyland's Market", "Fiesta Mart", "El Super", "Superior Grocers", "Cardenas Markets", "Northgate Market", "Vallarta Supermarkets", "Mi Pueblo", "Compare Foods", "Bravo Supermarkets", "Fresco y Más", "Sedano's", "Presidente Supermarket", "La Michoacana Meat Market", "Supermercado El Rancho", "Rouses Markets", "H-Mart", "99 Ranch Market", "Seafood City", "Mitsuwa Marketplace", "Marukai Market", "Nijiya Market", "Woori Market", "Zion Market", "Hanaro Market", "Pacific Supermarket", "Island Pacific", "Uwajimaya", "MT Supermarket", "Fiesta Supermarket", "Cardenas Market", "Cash & Carry", "Smart Foodservice", "Chef'Store", "Chef Central", "Restaurant Depot", "US Foods Chef'Store", "Gordon Food Service Store", "Sysco", "PFG Customized", "Shamrock Foods", "The Restaurant Store", "True Value", "Ace Hardware", "Do it Best", "Menards", "Orchard Supply Hardware", "84 Lumber", "Lowe's Home Improvement", "The Home Depot", "Harbor Freight Tools", "Northern Tool + Equipment", "Tractor Supply Company", "Family Farm & Home", "Rural King", "Southern States Cooperative", "Agri Supply", "Big R Stores", "Coastal Farm & Ranch", "Atwoods Ranch & Home", "Bomgaars", "Blain's Farm & Fleet", "Fleet Farm", "Buchheit", "Farm & Home Supply", "Runnings", "Orscheln Farm & Home", "Cal Ranch Stores", "Wilco", "Groves Hardware", "House-Hasson Hardware", "Wallace Hardware", "Emigh Hardware", "Crown Ace Hardware", "Bay Ace Hardware", "Center Hardware", "Ganahl Lumber", "Friedman’s Home Improvement", "Hartville Hardware", "McCoy’s Building Supply", "Sutherlands", "McLendon Hardware", "Payless Cashways", "TruValue Hardware", "Westlake Ace Hardware", "Jerry's Home Improvement", "E&H Hardware Group", "McGuckin Hardware", "Busy Beaver", "Hechinger", "Grossman's Bargain Outlet", "Schaedler Yesco", "Graybar Electric" };
        
        /// <summary>
        /// get a random card prefix in accordance with the cardlist
        /// </summary>
        /// <param name="card"></param>
        /// <returns>a random number from the relevant list</returns>
        private static string getPrefix(CardList card)
        {
            Random rnd = new Random();
            switch (card)
            {
                case CardList.VISAElectronCard:
                    return PrefixVisaElectron[rnd.Next(0, 6)];
                case CardList.VISACard:
                    return PrefixVisa;
                case CardList.Mastercard:
                    return PrefixMasterCard[rnd.Next(0, 5)];
                case CardList.MaestroCard:
                    return Prefixmaestro[rnd.Next(0, 9)];
                case CardList.WithdrawalCard:
                    return WithdrawalCard;
                case CardList.GiftCard:
                    return "0000";
                default:
                    return null;
            }
        }

        /// <summary>
        /// get a random card number
        /// </summary>
        /// <param name="card"></param>
        /// <returns>a random number with a <see cref="prefix"/></returns>
        public static string getCardNumber(CardList card)
        {
            Random rnd = new Random();
            string cardnumber = getPrefix(card);
            int anl = 16;
            if (card == CardList.MaestroCard)
            {
                anl = 19;
            }

            while (cardnumber.Length < anl)
            {
                cardnumber += rnd.Next(0, 10).ToString();
            }
            return cardnumber;
        }

        public static string GetAccountNumber()
        {
            Random rnd = new Random();
            string cardnumber = AccountPrefix;
            int anl = 14;

            while (cardnumber.Length < anl)
            {
                cardnumber += rnd.Next(0, 10).ToString();
            }
            return cardnumber;
        }

        /// <summary>
        /// get a random cardholder name
        /// </summary>
        /// <returns>a random name from the <see cref="FirstNames"/> paired with a random name from the <see cref="SurNames"/> lists</returns>
        public static string getName()
        {
            Random rnd = new Random();
            return FirstNames[rnd.Next(0, FirstNames.Length - 1)] + " " + SurNames[rnd.Next(0, SurNames.Length - 1)];
        }

        /// <summary>
        /// get a random secirty number
        /// todo: make this a string
        /// </summary>
        /// <returns>a random number between 100 and 999</returns>
        public static short getSecurityNumber()
        {
            Random rnd = new Random();
            return (short)rnd.Next(100, 999);
        }

        /// <summary>
        /// get a random passcode
        /// todo: make this a string
        /// </summary>
        /// <returns>a random number between 1000 and 9999</returns>
        public static string getPassword()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 9999).ToString();
        }

        /// <summary>
        /// Get a random store name
        /// </summary>
        /// <returns>a random name from <see cref="StoreNames"/></returns>
        public static string getRandomStore()
        {
            Random rnd = new Random();
            return StoreNames[rnd.Next(0, StoreNames.Length - 1)];
        }
    }
}
