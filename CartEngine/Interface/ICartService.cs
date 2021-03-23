using CartEngine.Model;
using System;
using System.Text;

namespace CartEngine.Interface
{
    public interface ICartService
    {
        void CalculateTotalPrice(Cart cart);
    }
}
