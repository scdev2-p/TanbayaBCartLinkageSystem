using Bcart受注管理.Models;

namespace Bcart受注管理.Dtos
{
    internal class CustomerCreateDto
    {
        public class CustomerCreate()
        {
            public CustomerCreate(Customer createValue) : this()
            {
                ExtId = createValue.ExtId;
                CompName = createValue.CompName;
                CompNameKana = createValue.CompNameKana;
                TantoLastName = createValue.TantoLastName;
                TantoFirstName = createValue.TantoFirstName;
                Zip = createValue.Zip;
                Pref = createValue.Pref;
                Address1 = createValue.Address1;
                Address2 = createValue.Address2;
                Address3 = createValue.Address3;
                Email = createValue.Email;
                Tel = createValue.Tel;
                Fax = createValue.Fax;
                Payment = createValue.Payment;
                SpecialShippingCost = createValue.SpecialShippingCost;
                PriceGroupId = createValue.PriceGroupId;
                ViewGroupId = createValue.ViewGroupId;
                Customs = createValue.Customs;
                CreditLimit = createValue.CreditLimit;
                Password = createValue.Password;
                CutoffDate = createValue.CutoffDate;
            }

            public string? ExtId { get; set; }
            public string? CompName { get; set; }
            public string? CompNameKana { get; set; }
            public string? TantoLastName { get; set; }
            public string? TantoFirstName { get; set; }
            public string? Zip { get; set; }
            public string? Pref { get; set; }
            public string? Address1 { get; set; }
            public string? Address2 { get; set; }
            public string? Address3 { get; set; }
            public string? Email { get; set; }
            public string? Tel { get; set; }
            public string? Fax { get; set; }
            public string? Payment { get; set; }
            public string? SpecialShippingCost { get; set; }
            public long? PriceGroupId { get; set; }
            public long? ViewGroupId { get; set; }
            public List<CustomerCustom>? Customs { get; set; }
            public decimal? CreditLimit { get; set; }
            public string? Password { get; set; }
            public string? CutoffDate { get; set; }
        }

        public List<CustomerCreate> Customers { get; set; }

        public CustomerCreateDto(Customer customer)
        {
            Customers = [new(customer)];
        }
    }
}
