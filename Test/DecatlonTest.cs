using NUnit.Framework;

namespace autotests.Test
{
    public class DecatlonTest : BaseTest
    {
        
        [Test, Order(1)]
        public static void TestDecatlonSearchOrderByValue()
        {
            decatlonPage.NavigateToPage();
            decatlonPage.AcceptCookies();
            decatlonPage.SearchForItemByText("Kuprinė");
            decatlonPage.SelectValueFromOrderDropdown("prod_lt_price_asc");
            decatlonPage.VerifyMostExpencivePriceResult("€600.00");
        }
        [Test, Order(2)]
        public static void TestIncorrectLogin()
        {
            decatlonPage.NavigateToPage();
            decatlonPage.OpenLoginWindow();
            decatlonLoginPage.EmailInput("test@test.net");
            decatlonLoginPage.VerifyResult("Negalime surasti tokios Decathlon paskyros Pabandykite kitą el. paštą arba susikurkite naują paskyrą!");
        }
        [Test, Order(3)]
        public static void TestCheckboxSelection()
        {
            decatlonPage.NavigateToPage();
            decatlonPage.SearchForItemByText("striukė");
            decatlonSearchFilter.ClickFirstCheckbox();
            decatlonSearchFilter.ClickOnJacket();
            decatlonItemPage.VerifyItemNameContainsSearchText("striukė");
        }
    }
}
