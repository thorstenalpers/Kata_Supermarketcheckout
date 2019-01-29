using SupermarketCheckout.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Contracts
{
    public interface ISupermarketCheckout
    {
        Bill CreateBill(Basket baket);
    }
}
